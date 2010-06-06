using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SqlGenerator
{
    public static class G
    {
        public static ISqlGenerator SqlGenerator = new UnknownSqlGenerator();
    }

    public class Table
    {
        public string Name { get; set; }

        public string EscapedName
        {
            get
            {
                bool needEscape = G.SqlGenerator.IsReservedWord(Name);
                string escapedName = needEscape ? G.SqlGenerator.EscapeName(Name) : Name;
                return escapedName;
            }
        }

        public List<TableColumn> Columns { get; set; }
        public List<TableRow> Rows { get; set; }

        public string ToCreateScript()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(G.SqlGenerator.SqlDropIfExists(Name));

            result.AppendLine(string.Format("CREATE TABLE {0} ({1});",
                 EscapedName,
                 string.Join(", ", Columns.Select(column => column.ToCreateScript()).ToArray())));

            string columnNames = string.Join(", ", Columns.Select(column => column.EscapedName).ToArray());

            if (Rows.Count > 0)
            {
                result.Append(string.Format("INSERT INTO {0} ({1}) VALUES" + Environment.NewLine,
                    EscapedName, columnNames));

                List<string> lines = new List<string>();
                foreach (TableRow row in Rows)
                {
                    string[] values = new string[Columns.Count];
                    for (int i = 0; i < Columns.Count; ++i)
                        values[i] = Columns[i].ValueToLiteral(row.Cells[i].Data);
                    lines.Add(string.Format("({0})",
                        string.Join(", ", values)));
                }

                result.AppendLine(string.Join("," + Environment.NewLine, lines.ToArray()) + ";");
            }

            result.AppendLine(string.Format("SELECT {0} FROM {1};", columnNames, EscapedName));
            return result.ToString();
        }
    }

    public class TableColumn
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public string EscapedName
        {
            get
            {
                bool needEscape = G.SqlGenerator.IsReservedWord(Name);
                string escapedName = needEscape ? G.SqlGenerator.EscapeName(Name) : Name;
                return escapedName;
            }
        }

        public string ToCreateScript()
        {
            return string.Format("{0} {1}", EscapedName, Type);
        }

        public string ValueToLiteral(string value)
        {
            if (value == "NULL" || value == "")
            {
                return "NULL";
            }
            else if (Type.Contains("DATE") || Type.Contains("TIME") || Type.Contains("CHAR"))
            {
                return "'" + value.Replace("'", "''") + "'";
            }
            else
            {
                return value;
            }
        }
    }

    public class TableRow
    {
        public List<TableCell> Cells = new List<TableCell>();
    }

    public class TableCell
    {
        public string Data { get; set; }
    }

    public class ParseTable
    {
        public class ErrorEventArgs : EventArgs
        {
           public string Error {get; set;}
        }

        public event EventHandler<ErrorEventArgs> ErrorOccured;

        private void onError(ErrorEventArgs e)
        {
            if (ErrorOccured != null)
            {
                ErrorOccured(this, e);
            }
        }

        private void raiseError(string error)
        {
            onError(new ErrorEventArgs { Error = error });
        }

        private static string stripSingleQuotes(string s)
        {
            if (s.Length < 2) return s;

            if (s[0] == '\'' && s[s.Length - 1] == '\'')
                return s.Substring(1, s.Length - 2);

            return s;
        }

        private IEnumerable<string> getPartsUsingRegex(Regex regex, bool doStripSingleQuotes, string line)
        {
            var result = regex.Matches(line.Trim('|', ' '))
                              .OfType<Match>()
                              .Select(match => match.Value.Trim());

            if (doStripSingleQuotes)
            {
                result = result.Select(x => stripSingleQuotes(x));
            }
            return result;
        }

        public Table ParseTableData(string text)
        {
            StringReader stringReader = new StringReader(text);

            Table table = new Table();

            // Read table name (optional).
            string line = stringReader.ReadLine();

            if (line == null)
            {
                raiseError("No table information found");
                return null;
            }

            line = line.Trim();
            if (line.Contains(' ') || line.Contains('|') || line.Contains('\t') || line.Contains(',') || line == string.Empty)
            {
                table.Name = "Table1";
            }
            else
            {
                table.Name = line;
                line = stringReader.ReadLine();
                if (line == null)
                {
                    raiseError("No columns found.");
                    return null;
                }

                line = line.Trim();
            }

            // Guess the separator.
            bool doStripSingleQuotes = false;
            Regex columnDataMatcher;

            if (line.Contains('\t'))
            {
                columnDataMatcher = new Regex(@"[^\t]+");
            }
            else if (line.Contains('|'))
            {
                columnDataMatcher = new Regex(@"[^|\s](?:[^|]*[^|\s])?");
            }
            else if (line.Contains(';'))
            {
                columnDataMatcher = new Regex(@"[^;]+");
            }
            else if (line.Contains(','))
            {
                columnDataMatcher = new Regex(@"[^,]+");
            }
            else
            {
                columnDataMatcher = new Regex(@"[^'\s]+|'[^']*'");
                doStripSingleQuotes = true;
            }

            // Read column names.
            table.Columns = columnDataMatcher.Matches(line.Trim('|', ' '))
                .OfType<Match>()
                .Select(match => new TableColumn { Name = match.Value.Trim() })
                .ToList();

            table.Rows = new List<TableRow>();

            line = stringReader.ReadLine();

            // Remove optional extra line between column names and data.
            if (line != null && Regex.IsMatch(line, @"(\+\-+)+", RegexOptions.IgnoreCase))
            {
                line = stringReader.ReadLine();
            }

            // Read table data.
            while (true)
            {
                if (line == null)
                    break;
                line = line.Trim();
                if (line == string.Empty)
                    break;

                IEnumerable<string> data =
                    getPartsUsingRegex(columnDataMatcher, doStripSingleQuotes, line);

                if (data.Count() != table.Columns.Count)
                {
                    raiseError(
                        string.Format("Line contains {0} columns instead of {1}: {2}",
                        data.Count(),
                        table.Columns.Count,
                        line));
                    return null;
                }

                TableRow row = new TableRow();
                foreach (string cellData in data)
                    row.Cells.Add(new TableCell { Data = cellData });
                table.Rows.Add(row);

                line = stringReader.ReadLine();
            }

            guessColumnTypes(table);

            return table;
        }

        private void guessColumnTypes(Table table)
        {
            for (int i = 0; i < table.Columns.Count; ++i)
            {
                guessColumnType(table, i);
            }
        }

        private void guessColumnType(Table table, int i)
        {
            if (isColumnInteger(table, i))
            {
                table.Columns[i].Type = "INT";
            }
            else if (isColumnDate(table, i))
            {
                table.Columns[i].Type = "DATE";
            }
            else if (isColumnDatetime(table, i))
            {
                table.Columns[i].Type = "DATETIME";
            }
            else
            {
                table.Columns[i].Type = "VARCHAR(100)";
            }

            bool nullable = isColumnNullable(table, i);
            if (!nullable)
                table.Columns[i].Type += " NOT";
            table.Columns[i].Type += " NULL";

        }

        private bool isColumnNullable(Table table, int i)
        {
            foreach (TableRow row in table.Rows)
            {
                if (row.Cells[i].Data == "NULL")
                    return true;
            }
            return false;
        }

        private bool isColumnInteger(Table table, int i)
        {
            foreach (TableRow row in table.Rows)
            {
                if (row.Cells[i].Data == "NULL")
                    continue;

                int unused;
                if (!int.TryParse(row.Cells[i].Data, out unused))
                    return false;
            }
            return true;
        }

        private bool isColumnDate(Table table, int i)
        {
            foreach (TableRow row in table.Rows)
            {
                if (row.Cells[i].Data == "NULL")
                    continue;

                DateTime unused;
                if (!DateTime.TryParseExact(row.Cells[i].Data,
                                            "yyyy-MM-dd",
                                            null,
                                            DateTimeStyles.None,
                                            out unused))
                {
                    return false;
                }
            }
            return true;
        }

        private bool isColumnDatetime(Table table, int i)
        {
            foreach (TableRow row in table.Rows)
            {
                if (row.Cells[i].Data == "NULL")
                    continue;

                DateTime unused;
                if (!DateTime.TryParse(row.Cells[i].Data, out unused))
                    return false;
            }
            return true;
        }
    
    }
}
