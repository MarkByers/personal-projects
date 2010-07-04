using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SqlGenerator
{
    public partial class SelectQueryForm : Form
    {
        public SelectQueryForm()
        {
            InitializeComponent();
        }
        
        public SelectQueryForm(Table table) : this()
        {
            if (table != null)
            {
                textBoxTable.Text = table.Name;
                foreach (var column in table.Columns)
                {
                    listViewColumns.Items.Add(new ListViewItem(column.Name));
                }
            }
        }

        private void updateQuery(object sender, EventArgs e)
        {
            try
            {
                updateQuery();
            }
            catch (Exception exception)
            {
                textBoxResult.Text = exception.ToString();
            }
        }

        private void updateQuery()
        {
            string tableName = textBoxTable.Text;
            string[] groupByColumns = textBoxGroupBy.Lines;
            string[] whereMaxColumns = textBoxWhereMaxMin.Lines;
            string[] selectColumns = textBoxSelect.Lines;

            // Parse the max columns to see if they actually were minimums.
            bool[] useMaxForColumns = new bool[whereMaxColumns.Length];
            Regex regexMinOrMax = new Regex(" (max|min)$", RegexOptions.IgnoreCase);
            for (int i = 0; i < whereMaxColumns.Length; ++i)
            {
                Match match = regexMinOrMax.Match(whereMaxColumns[i]);
                if (match.Success)
                {
                    useMaxForColumns[i] = string.Equals(
                        match.Groups[1].Value,
                        "max",
                        StringComparison.InvariantCultureIgnoreCase); 
                    whereMaxColumns[i] = regexMinOrMax.Replace(whereMaxColumns[i], "");
                }
                else
                {
                    useMaxForColumns[i] = true;
                }
            }

            string[] select = textBoxSelect.Lines;
            IGroupwiseMaximumSql sqlGenerator = getMethod();
            string result = sqlGenerator.GetSql(
                tableName,
                groupByColumns,
                whereMaxColumns,
                useMaxForColumns,
                selectColumns);

            textBoxResult.Text = result;
        }

        private IGroupwiseMaximumSql getMethod()
        {
            switch ((string)comboBoxMethod.SelectedItem)
            {
                case "ROW_NUMBER":
                    return new GroupwiseMaximumSqlServerRowNumber();
                case "variables - ROW_NUMBER":
                    return new GroupwiseMaximumMySqlVariables();
                default:
                    return new GroupwiseMaximumSqlServerRowNumber();
            }
        }

        private void listViewColumns_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ListViewItem item = (ListViewItem)e.Item;
            DoDragDrop(item.Text, DragDropEffects.Copy);
        }

        private void columnList_DragDrop(object sender, DragEventArgs e)
        {
            string columnName = e.Data.GetData(DataFormats.Text) as string;
            if (columnName != null)
            {
                TextBox textBox = (TextBox)sender;
                textBox.Text = textBox.Text.Trim();
                if (textBox.Text.Length > 0)
                {
                    textBox.Text += Environment.NewLine;
                }
                textBox.Text += columnName;
            }
        }

        private void columnList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
