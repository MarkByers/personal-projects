using System;
using System.Windows.Forms;
using SqlGenerator;

namespace SqlGeneratorTest
{
    public partial class SqlGeneratorTest : Form
    {
        public SqlGeneratorTest()
        {
            InitializeComponent();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            new TestGenerateSql().TestAll();
            label1.Text = "Success";
        }
    }
}
