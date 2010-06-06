using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;

namespace SqlGenerator
{
    public partial class SqlGeneratorForm : Form
    {
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMySQL.Checked)
            {
                G.SqlGenerator = new MySqlGenerator();
            }
            else if (radioButtonSqlServer.Checked)
            {
                G.SqlGenerator = new SqlServerGenerator();
            }
            else
            {
                G.SqlGenerator = new UnknownSqlGenerator();
            }
            updateSql();
        }

        ParseTable parseTable = new ParseTable();

        public SqlGeneratorForm()
        {
            InitializeComponent();
            parseTable.ErrorOccured += (sender, e) => errors.Add(e.Error);
        }

        List<string> errors;

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            updateSql();
        }

        void updateSql()
        {
            errors = new List<string>();
            string text = textBox.Text;
            Table table = parseTable.ParseTableData(text);
            string createScript = "";
            if (table != null)
            {
                createScript = table.ToCreateScript();
            }
            textBoxSql.Text = createScript;
            toolStripStatusLabel.Text = errors.DefaultIfEmpty("").First();
        }

        private void buttonFormat_Click(object sender, EventArgs e)
        {
            string text = textBox.Text;
            Table table = parseTable.ParseTableData(text);
            if (table != null)
            {
                // Get the strings which will be written back to the form.
                var strings = 
                    new IEnumerable<string>[]{table.Columns.Select(c => c.Name)}
                    .Concat(table.Rows.Select(row => row.Cells.Select(cell => cell.Data)));

                // Calculate the minimum width of each column.
                List<int> width =
                    Enumerable.Range(0, strings.First().Count())
                    .Select(i => strings.Select(row => row.ToArray()[i].Length)
                                        .OrderByDescending(x => x)
                                        .FirstOrDefault())
                                        .ToList();

                TextWriter textWriter = new StringWriter();

                if (table.Name != "Table1") // TODO: Add property table.IsAnonymous?
                {
                    textWriter.WriteLine(table.Name);
                }

                foreach (var row in strings)
                {
                    string[] cells = row.ToArray();
                    for (int i = 0; i < cells.Length; ++i)
                    {
                        if (i != 0)
                        {
                            textWriter.Write("  ");
                        }
                        textWriter.Write(cells[i].PadRight(width[i]));
                    }
                    textWriter.WriteLine();
                }

                textBox.Text = textWriter.ToString();
            }
        }

        /*
        private void buttonAddQuery_Click(object sender, EventArgs e)
        {
            string text = textBox.Text;
            parseSql(text);
        }

        private void parseSql(string sql)
        {
            Regex regex = new Regex(
                @"\w+" + "|" +         // Word.
                @"`[^`]+`" + "|" +     // Quoted with backticks.
                @"'[^']+'" + "|" +     // Quoted with single quotes.
                @"""[^""]+""" + "|" +  // Quoted with double quotes.
                @"\[[^\]]+\]" + "|" +  // Quoted with square brackets.
                @"\S");                // Single non-whitespace character.

            string[] tokens = regex
                .Matches(sql)
                .OfType<Match>()
                .Select(match => match.Value)
                .ToArray();

            switch (tokens[0].ToUpper())
            {
                case "SELECT":
                    parseSelect(tokens);
                    break;
                default:
                    throw new ApplicationException("Unsupported SQL: " + tokens[0]);
            }
        }

        class Selections
        {
            public string Selection { get; set; }
            public string Alias { get; set; }
        }

        private void parseSelect(string[] tokens)
        {
            int i = 1;

            List<Selections> selections = new List<Selections>();
            string selection = "<unknown>";
            string alias = null;

            while (true)
            {

                if (tokens[i].ToUpper() == "FROM")
                    break;

                if (tokens[i].ToUpper() == "AS")
                {
                    alias = tokens[i + 1];
                }
            }
        }
        */
    }
}
