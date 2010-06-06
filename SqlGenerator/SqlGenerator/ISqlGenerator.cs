using System;

namespace SqlGenerator
{
    public interface ISqlGenerator
    {
        string SqlDropIfExists(string tableName);
        bool IsReservedWord(string word);
        string EscapeName(string name);
    }
}
