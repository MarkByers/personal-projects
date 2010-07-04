using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlGenerator;

namespace SqlGeneratorTest
{
    class TestGroupwiseMaximum
    {
        public void SqlServerRowNumberTest()
        {
            IGroupwiseMaximumSql sql = new GroupwiseMaximumSqlServerRowNumber();
            string result = sql.GetSql(
                "table1",
                new string[] { "grp" },
                new string[] { "ord" },
                new bool[] { true },
                new string[] { "grp", "ord", "stuffing" });

            string expected = @"
SELECT grp, ord, stuffing
FROM (
    SELECT 
        grp, ord, stuffing,
        ROW_NUMBER() OVER (PARTITION BY grp
                           ORDER BY ord DESC) AS rn
    FROM table1
) AS T1
WHERE rn = 1
".Trim();
            if (result != expected)
                throw new ApplicationException("Test failed");
        }

        public void MySqlRowNumberTest()
        {
            IGroupwiseMaximumSql sql = new GroupwiseMaximumMySqlVariables();
            string result = sql.GetSql(
                "table1",
                new string[] { "grp" },
                new string[] { "ord" },
                new bool[] { true },
                new string[] { "grp", "ord", "stuffing" });

            string expected = @"
SELECT grp, ord, stuffing
FROM (
    SELECT
        grp, ord, stuffing,
        @rn := CASE WHEN @prev_grp = grp
                    THEN @rn + 1
                    ELSE 1
               END AS rn,
        @prev_grp := grp
    FROM (SELECT @prev_grp := NULL) vars, table1 T1
    ORDER BY grp, ord DESC
) T2
WHERE rn = 1
".Trim();
            if (result != expected)
                throw new ApplicationException("Test failed");
        }

        public void JoinsTest()
        {
            IGroupwiseMaximumSql sql = new GroupwiseMaximumJoins();
            string result = sql.GetSql(
                "table1",
                new string[] { "grp" },
                new string[] { "ord1", "ord2" },
                new bool[] { true, false },
                new string[] { "grp", "ord1", "ord2", "stuffing" });

            string expected = @"
SELECT T1.grp, T1.ord1, T1.ord2, T1.stuffing
FROM table1 T1
JOIN
(
    SELECT T1.grp, T1.ord1, MIN(T1.ord2) AS ord2
    FROM table1 T1
    JOIN
    (
        SELECT T1.grp, MAX(T1.ord1) AS ord1
        FROM table1 T1
        GROUP BY T1.grp
    ) T2
    ON T1.grp = T2.grp
    AND T1.ord1 = T2.ord1
    GROUP BY T1.grp, T1.ord1
) T2
ON T1.grp = T2.grp
AND T1.ord1 = T2.ord1
AND T1.ord2 = T2.ord2
".Trim();
            if (result != expected)
                throw new ApplicationException("Test failed");
        }

        public void TestAll()
        {
            SqlServerRowNumberTest();
            MySqlRowNumberTest();
            //JoinsTest();
        }
    }
}
