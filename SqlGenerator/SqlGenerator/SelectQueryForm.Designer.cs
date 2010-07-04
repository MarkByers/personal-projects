namespace SqlGenerator
{
    partial class SelectQueryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.labelSelect = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGroupBy = new System.Windows.Forms.TextBox();
            this.textBoxWhereMaxMin = new System.Windows.Forms.TextBox();
            this.textBoxSelect = new System.Windows.Forms.TextBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTable = new System.Windows.Forms.TextBox();
            this.listViewColumns = new System.Windows.Forms.ListView();
            this.comboBoxDatabase = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxVersion = new System.Windows.Forms.ComboBox();
            this.comboBoxMethod = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Group By";
            // 
            // labelSelect
            // 
            this.labelSelect.AutoSize = true;
            this.labelSelect.Location = new System.Drawing.Point(59, 159);
            this.labelSelect.Name = "labelSelect";
            this.labelSelect.Size = new System.Drawing.Size(37, 13);
            this.labelSelect.TabIndex = 6;
            this.labelSelect.Text = "Select";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Where Max/Min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "All Columns";
            // 
            // textBoxGroupBy
            // 
            this.textBoxGroupBy.AllowDrop = true;
            this.textBoxGroupBy.Location = new System.Drawing.Point(102, 38);
            this.textBoxGroupBy.Multiline = true;
            this.textBoxGroupBy.Name = "textBoxGroupBy";
            this.textBoxGroupBy.Size = new System.Drawing.Size(117, 53);
            this.textBoxGroupBy.TabIndex = 3;
            this.textBoxGroupBy.TextChanged += new System.EventHandler(this.updateQuery);
            this.textBoxGroupBy.DragDrop += new System.Windows.Forms.DragEventHandler(this.columnList_DragDrop);
            this.textBoxGroupBy.DragEnter += new System.Windows.Forms.DragEventHandler(this.columnList_DragEnter);
            // 
            // textBoxWhereMaxMin
            // 
            this.textBoxWhereMaxMin.AllowDrop = true;
            this.textBoxWhereMaxMin.Location = new System.Drawing.Point(102, 97);
            this.textBoxWhereMaxMin.Multiline = true;
            this.textBoxWhereMaxMin.Name = "textBoxWhereMaxMin";
            this.textBoxWhereMaxMin.Size = new System.Drawing.Size(117, 53);
            this.textBoxWhereMaxMin.TabIndex = 5;
            this.textBoxWhereMaxMin.TextChanged += new System.EventHandler(this.updateQuery);
            this.textBoxWhereMaxMin.DragDrop += new System.Windows.Forms.DragEventHandler(this.columnList_DragDrop);
            this.textBoxWhereMaxMin.DragEnter += new System.Windows.Forms.DragEventHandler(this.columnList_DragEnter);
            // 
            // textBoxSelect
            // 
            this.textBoxSelect.AllowDrop = true;
            this.textBoxSelect.Location = new System.Drawing.Point(102, 156);
            this.textBoxSelect.Multiline = true;
            this.textBoxSelect.Name = "textBoxSelect";
            this.textBoxSelect.Size = new System.Drawing.Size(117, 98);
            this.textBoxSelect.TabIndex = 7;
            this.textBoxSelect.TextChanged += new System.EventHandler(this.updateQuery);
            this.textBoxSelect.DragDrop += new System.Windows.Forms.DragEventHandler(this.columnList_DragDrop);
            this.textBoxSelect.DragEnter += new System.Windows.Forms.DragEventHandler(this.columnList_DragEnter);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResult.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResult.Location = new System.Drawing.Point(15, 260);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxResult.Size = new System.Drawing.Size(546, 152);
            this.textBoxResult.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Result";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Table";
            // 
            // textBoxTable
            // 
            this.textBoxTable.Location = new System.Drawing.Point(102, 12);
            this.textBoxTable.Name = "textBoxTable";
            this.textBoxTable.Size = new System.Drawing.Size(117, 20);
            this.textBoxTable.TabIndex = 1;
            this.textBoxTable.TextChanged += new System.EventHandler(this.updateQuery);
            // 
            // listViewColumns
            // 
            this.listViewColumns.Location = new System.Drawing.Point(243, 31);
            this.listViewColumns.Name = "listViewColumns";
            this.listViewColumns.Size = new System.Drawing.Size(121, 223);
            this.listViewColumns.TabIndex = 11;
            this.listViewColumns.UseCompatibleStateImageBehavior = false;
            this.listViewColumns.View = System.Windows.Forms.View.List;
            this.listViewColumns.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewColumns_ItemDrag);
            // 
            // comboBoxDatabase
            // 
            this.comboBoxDatabase.FormattingEnabled = true;
            this.comboBoxDatabase.Items.AddRange(new object[] {
            "Any",
            "SQL Server"});
            this.comboBoxDatabase.Location = new System.Drawing.Point(459, 38);
            this.comboBoxDatabase.Name = "comboBoxDatabase";
            this.comboBoxDatabase.Size = new System.Drawing.Size(99, 21);
            this.comboBoxDatabase.TabIndex = 12;
            this.comboBoxDatabase.SelectedIndexChanged += new System.EventHandler(this.updateQuery);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(397, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Database:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(408, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Version:";
            // 
            // comboBoxVersion
            // 
            this.comboBoxVersion.FormattingEnabled = true;
            this.comboBoxVersion.Items.AddRange(new object[] {
            "Any",
            "2005"});
            this.comboBoxVersion.Location = new System.Drawing.Point(459, 65);
            this.comboBoxVersion.Name = "comboBoxVersion";
            this.comboBoxVersion.Size = new System.Drawing.Size(99, 21);
            this.comboBoxVersion.TabIndex = 15;
            this.comboBoxVersion.SelectedIndexChanged += new System.EventHandler(this.updateQuery);
            // 
            // comboBoxMethod
            // 
            this.comboBoxMethod.FormattingEnabled = true;
            this.comboBoxMethod.Items.AddRange(new object[] {
            "ROW_NUMBER",
            "variables - ROW_NUMBER"});
            this.comboBoxMethod.Location = new System.Drawing.Point(459, 92);
            this.comboBoxMethod.Name = "comboBoxMethod";
            this.comboBoxMethod.Size = new System.Drawing.Size(99, 21);
            this.comboBoxMethod.TabIndex = 16;
            this.comboBoxMethod.SelectedIndexChanged += new System.EventHandler(this.updateQuery);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(407, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Method:";
            // 
            // SelectQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 424);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxMethod);
            this.Controls.Add(this.comboBoxVersion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxDatabase);
            this.Controls.Add(this.listViewColumns);
            this.Controls.Add(this.textBoxTable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.textBoxSelect);
            this.Controls.Add(this.textBoxWhereMaxMin);
            this.Controls.Add(this.textBoxGroupBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelSelect);
            this.Controls.Add(this.label1);
            this.Name = "SelectQueryForm";
            this.Text = "Generate Select Query";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGroupBy;
        private System.Windows.Forms.TextBox textBoxWhereMaxMin;
        private System.Windows.Forms.TextBox textBoxSelect;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTable;
        private System.Windows.Forms.ListView listViewColumns;
        private System.Windows.Forms.ComboBox comboBoxDatabase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxVersion;
        private System.Windows.Forms.ComboBox comboBoxMethod;
        private System.Windows.Forms.Label label8;
    }
}