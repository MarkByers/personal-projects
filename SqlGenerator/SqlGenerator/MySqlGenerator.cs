using System;
using System.Linq;

namespace SqlGenerator
{
    public class MySqlGenerator : ISqlGenerator
    {
        public string SqlDropIfExists(string tableName)
        {
            string escapedName = IsReservedWord(tableName) ? EscapeName(tableName) : tableName;
            return string.Format("DROP TABLE IF EXISTS {0};", escapedName);
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
            return "`" + name + "`";
        }
    }
}
