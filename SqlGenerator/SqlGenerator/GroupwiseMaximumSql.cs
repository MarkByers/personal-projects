using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlGenerator
{
    public interface IGroupwiseMaximumSql
    {
        string GetSql(
            string tableName,
            string[] groupByColumns,
            string[] whereMaxColumns,
            bool[] useMaxForColumns,
            string[] selectColumns);
    }

    public class GroupwiseMaximumSqlServerRowNumber : IGroupwiseMaximumSql
    {
        public string GetSql(
            string tableName,
            string[] groupByColumns,
            string[] whereMaxColumns,
            bool[] useMaxForColumns,
            string[] selectColumns)
        {
            // TODO: If the only columns that need to be returned are 
            //       in the group by and one single maximum or minimum then use
            //       the more simple SELECT x, MAX(y) FROM table GROUP BY x
            // TODO: Escape column names.
            // TODO: Implement useMaxForColumns.
            // TODO: Reformat for optimal readability.

            List<string> orderByColumns = new List<string>();
            for (int i = 0; i < whereMaxColumns.Length; ++i)
            {
                string column = whereMaxColumns[i];
                if (useMaxForColumns[i])
                {
                    column += " DESC";
                }
                orderByColumns.Add(column);
            }

            return
                "SELECT " + string.Join(", ", selectColumns) + Environment.NewLine +
                "FROM (" + Environment.NewLine +
                "    SELECT " + Environment.NewLine +
                "        " + string.Join(", ", selectColumns) + "," + Environment.NewLine +
                "        ROW_NUMBER() OVER (PARTITION BY " + string.Join(", ", groupByColumns) + Environment.NewLine +
                "                           ORDER BY " + string.Join(", ", orderByColumns.ToArray()) + ") AS rn" + Environment.NewLine +
                "    FROM " + tableName + Environment.NewLine +
                ") AS T1" + Environment.NewLine +
                "WHERE rn = 1";
        }
    }

    public class GroupwiseMaximumMySqlVariables : IGroupwiseMaximumSql
    {
        public string GetSql(
            string tableName,
            string[] groupByColumns,
            string[] whereMaxColumns,
            bool[] useMaxForColumns,
            string[] selectColumns)
        {
            // TODO: If the only columns that need to be returned are 
            //       in the group by and one single maximum or minimum then use
            //       the more simple SELECT x, MAX(y) FROM table GROUP BY x
            // TODO: Escape column names.
            // TODO: Implement useMaxForColumns.
            // TODO: Reformat for optimal readability.

            string initPrev = string.Join(
                ", ",
                groupByColumns.Select(x => "@prev_" + x + " := NULL").ToArray());
            string caseWhen = string.Join(
                " AND ",
                groupByColumns.Select(x => "@prev_" + x + " = " + x).ToArray());
            string updatePrev = string.Join(
                "," + Environment.NewLine,
                groupByColumns.Select(x => "        @prev_" + x + " := " + x).ToArray());

            List<string> orderByColumns = new List<string>(groupByColumns);
            for (int i = 0; i < whereMaxColumns.Length; ++i)
            {
                string column = whereMaxColumns[i];
                if (useMaxForColumns[i])
                {
                    column += " DESC";
                }
                orderByColumns.Add(column);
            }
            string orderBy = string.Join(", ", orderByColumns.ToArray());

            return
                "SELECT " + string.Join(", ", selectColumns) + Environment.NewLine +
                "FROM (" + Environment.NewLine +
                "    SELECT" + Environment.NewLine +
                "        " + string.Join(", ", selectColumns) + "," + Environment.NewLine +
                "        @rn := CASE WHEN " + caseWhen + Environment.NewLine + 
                "                    THEN @rn + 1" + Environment.NewLine +
                "                    ELSE 1" + Environment.NewLine +
                "               END AS rn," + Environment.NewLine +
                updatePrev + Environment.NewLine +
                "    FROM (SELECT " + initPrev + ") vars, " + tableName + " T1" + Environment.NewLine +
                "    ORDER BY " + orderBy + Environment.NewLine +
                ") T2" + Environment.NewLine +
                "WHERE rn = 1";
        }
    }

    public class GroupwiseMaximumJoins : IGroupwiseMaximumSql
    {
        public string GetSql(
            string tableName,
            string[] groupByColumns,
            string[] whereMaxColumns,
            bool[] useMaxForColumns,
            string[] selectColumns)
        {
            return "";      
        }
    }
}

/*
SELECT id, grp1, grp2, foo
FROM (
    SELECT
        T1.*,
        @rn := CASE WHEN @prev_grp1 = grp1 AND @prev_grp2 = grp2 THEN @rn + 1 ELSE 1 END AS rn,
        @prev_grp1 := grp1,
        @prev_grp2 := grp2
    FROM (SELECT @prev_grp1 := NULL, @prev_grp2 := NULL) vars, table1 T1
    ORDER BY grp1, grp2, foo
) T2
WHERE rn = 1
*/