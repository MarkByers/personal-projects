using System;

namespace SqlGenerator
{
    public class UnknownSqlGenerator : ISqlGenerator
    {
        public string SqlDropIfExists(string tableName)
        {
            return string.Format("-- DROP TABLE {0};", tableName);
        }

        public bool IsReservedWord(string word)
        {
            return false;
        }

        public string EscapeName(string name)
        {
            return name;
        }
    }
}
