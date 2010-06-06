using System;
using SqlGenerator;

namespace SqlGeneratorTest
{
    class TestGenerateSql
    {
        void test(string tableText, string expected)
        {
            test(tableText, expected, new UnknownSqlGenerator());
        }

        void test(string tableText, string expected, ISqlGenerator sqlGenerator)
        {
            SqlGenerator.G.SqlGenerator = sqlGenerator;
            ParseTable parseTable = new ParseTable();
            Table table = parseTable.ParseTableData(tableText);
            string result = table.ToCreateScript();
            if (result != expected)
                throw new ApplicationException("Test failed");
        }

        private void testSimpleTable1()
        {
            string table = @"Table1
id name
1 Foo
2 Bar";
            string expected = @"-- DROP TABLE Table1;
CREATE TABLE Table1 (id INT NOT NULL, name VARCHAR(100) NOT NULL);
INSERT INTO Table1 (id, name) VALUES
(1, 'Foo'),
(2, 'Bar');
SELECT id, name FROM Table1;
";
            test(table, expected);
        }

        private void testStringContainingSingleQuote()
        {
            string table = @"Table1
id | name
1 | O'Neale";
            string expected = @"-- DROP TABLE Table1;
CREATE TABLE Table1 (id INT NOT NULL, name VARCHAR(100) NOT NULL);
INSERT INTO Table1 (id, name) VALUES
(1, 'O''Neale');
SELECT id, name FROM Table1;
";
            test(table, expected);
        }

        private void testTabSeperated()
        {
            string table = @"Table1
id\tname
1\tFoo Bar".Replace(@"\t", "\t");
            string expected = @"-- DROP TABLE Table1;
CREATE TABLE Table1 (id INT NOT NULL, name VARCHAR(100) NOT NULL);
INSERT INTO Table1 (id, name) VALUES
(1, 'Foo Bar');
SELECT id, name FROM Table1;
";
            test(table, expected);
        }

        private void testTableCalledValues()
        {
            string table = @"Values
name value
name1 value1";
            string expected = @"DROP TABLE IF EXISTS `Values`;
CREATE TABLE `Values` (name VARCHAR(100) NOT NULL, value VARCHAR(100) NOT NULL);
INSERT INTO `Values` (name, value) VALUES
('name1', 'value1');
SELECT name, value FROM `Values`;
";
            test(table, expected, new MySqlGenerator());
        }

        private void testDateTimes()
        {
            string table = @"Datetimes
id datetime
1 '2010-06-10 00:01:00'";
            string expected = @"DROP TABLE IF EXISTS Datetimes;
CREATE TABLE Datetimes (id INT NOT NULL, datetime DATETIME NOT NULL);
INSERT INTO Datetimes (id, datetime) VALUES
(1, '2010-06-10 00:01:00');
SELECT id, datetime FROM Datetimes;
";
            test(table, expected, new MySqlGenerator());
        }

        public void TestAll()
        {
            testSimpleTable1();
            testStringContainingSingleQuote();
            testTabSeperated();
            testTableCalledValues();
            testDateTimes();
        }
    }
}
