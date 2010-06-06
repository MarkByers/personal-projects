namespace SqlGenerator
{
    partial class SqlGeneratorForm
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.radioButtonMySQL = new System.Windows.Forms.RadioButton();
            this.radioButtonSqlServer = new System.Windows.Forms.RadioButton();
            this.radioButtonUnknown = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBoxSql = new System.Windows.Forms.TextBox();
            this.buttonFormat = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(591, 190);
            this.textBox.TabIndex = 2;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // radioButtonMySQL
            // 
            this.radioButtonMySQL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonMySQL.AutoSize = true;
            this.radioButtonMySQL.Location = new System.Drawing.Point(532, 271);
            this.radioButtonMySQL.Name = "radioButtonMySQL";
            this.radioButtonMySQL.Size = new System.Drawing.Size(60, 17);
            this.radioButtonMySQL.TabIndex = 5;
            this.radioButtonMySQL.Text = "MySQL";
            this.radioButtonMySQL.UseVisualStyleBackColor = true;
            this.radioButtonMySQL.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonSqlServer
            // 
            this.radioButtonSqlServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonSqlServer.AutoSize = true;
            this.radioButtonSqlServer.Location = new System.Drawing.Point(532, 294);
            this.radioButtonSqlServer.Name = "radioButtonSqlServer";
            this.radioButtonSqlServer.Size = new System.Drawing.Size(80, 17);
            this.radioButtonSqlServer.TabIndex = 6;
            this.radioButtonSqlServer.Text = "SQL Server";
            this.radioButtonSqlServer.UseVisualStyleBackColor = true;
            this.radioButtonSqlServer.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonUnknown
            // 
            this.radioButtonUnknown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonUnknown.AutoSize = true;
            this.radioButtonUnknown.Checked = true;
            this.radioButtonUnknown.Location = new System.Drawing.Point(532, 248);
            this.radioButtonUnknown.Name = "radioButtonUnknown";
            this.radioButtonUnknown.Size = new System.Drawing.Size(71, 17);
            this.radioButtonUnknown.TabIndex = 7;
            this.radioButtonUnknown.TabStop = true;
            this.radioButtonUnknown.Text = "Unknown";
            this.radioButtonUnknown.UseVisualStyleBackColor = true;
            this.radioButtonUnknown.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 324);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(615, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // textBoxSql
            // 
            this.textBoxSql.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSql.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSql.Location = new System.Drawing.Point(12, 208);
            this.textBoxSql.Multiline = true;
            this.textBoxSql.Name = "textBoxSql";
            this.textBoxSql.Size = new System.Drawing.Size(514, 113);
            this.textBoxSql.TabIndex = 9;
            // 
            // buttonFormat
            // 
            this.buttonFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFormat.Location = new System.Drawing.Point(532, 208);
            this.buttonFormat.Name = "buttonFormat";
            this.buttonFormat.Size = new System.Drawing.Size(75, 23);
            this.buttonFormat.TabIndex = 10;
            this.buttonFormat.Text = "&Format";
            this.buttonFormat.UseVisualStyleBackColor = true;
            this.buttonFormat.Click += new System.EventHandler(this.buttonFormat_Click);
            // 
            // SqlGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 346);
            this.Controls.Add(this.buttonFormat);
            this.Controls.Add(this.textBoxSql);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.radioButtonUnknown);
            this.Controls.Add(this.radioButtonSqlServer);
            this.Controls.Add(this.radioButtonMySQL);
            this.Controls.Add(this.textBox);
            this.Name = "SqlGeneratorForm";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.RadioButton radioButtonMySQL;
        private System.Windows.Forms.RadioButton radioButtonSqlServer;
        private System.Windows.Forms.RadioButton radioButtonUnknown;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TextBox textBoxSql;
        private System.Windows.Forms.Button buttonFormat;
    }
}

