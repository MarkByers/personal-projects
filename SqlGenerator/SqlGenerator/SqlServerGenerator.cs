using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlGenerator
{
    class SqlServerGenerator : ISqlGenerator
    {
        public string SqlDropIfExists(string tableName)
        {
            string escapedName = IsReservedWord(tableName) ? EscapeName(tableName) : tableName;
            return string.Format(
                "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}') AND type in (N'U'))\r\n" +
                "DROP TABLE {0};\r\n" + 
                "GO",
                escapedName);
        }

        public bool IsReservedWord(string word)
        {
            string[] reserved = { "order", "values" };
            if (reserved.Any(x => word.Equals(x, StringComparison.InvariantCultureIgnoreCase)))
                return true;
            return false;
        }

        public string EscapeName(string name)
        {
            return "[" + name + "]";
        }
    }
}
