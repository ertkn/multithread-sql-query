
namespace TwoCustomerThread
{
    partial class ThreadForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblTypeA = new System.Windows.Forms.Label();
            this.lblTypeB = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.reportTable = new System.Windows.Forms.DataGridView();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.sqlGrid = new System.Windows.Forms.DataGridView();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFill = new System.Windows.Forms.Button();
            this.lblFillWarning = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ClmnNumA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnNumB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnAvgTimeA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnDLockA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnAvgTimeB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnDLockB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmIsoType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.reportTable)).BeginInit();
            this.grpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sqlGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.AutoSize = true;
            this.btnExecute.Font = new System.Drawing.Font("Gill Sans MT Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExecute.Location = new System.Drawing.Point(28, 112);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(78, 35);
            this.btnExecute.TabIndex = 0;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblTypeA
            // 
            this.lblTypeA.AutoSize = true;
            this.lblTypeA.Location = new System.Drawing.Point(7, 19);
            this.lblTypeA.Name = "lblTypeA";
            this.lblTypeA.Size = new System.Drawing.Size(68, 15);
            this.lblTypeA.TabIndex = 1;
            this.lblTypeA.Text = "Type A User";
            // 
            // lblTypeB
            // 
            this.lblTypeB.AutoSize = true;
            this.lblTypeB.Location = new System.Drawing.Point(7, 63);
            this.lblTypeB.Name = "lblTypeB";
            this.lblTypeB.Size = new System.Drawing.Size(67, 15);
            this.lblTypeB.TabIndex = 2;
            this.lblTypeB.Text = "Type B User";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Enter user value";
            this.textBox1.Size = new System.Drawing.Size(99, 23);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(7, 83);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "Enter a value";
            this.textBox2.Size = new System.Drawing.Size(99, 23);
            this.textBox2.TabIndex = 4;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblWarning.ForeColor = System.Drawing.Color.Crimson;
            this.lblWarning.Location = new System.Drawing.Point(28, 150);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(78, 22);
            this.lblWarning.TabIndex = 5;
            this.lblWarning.Text = "Only Integer!";
            this.lblWarning.Visible = false;
            // 
            // reportTable
            // 
            this.reportTable.AllowUserToAddRows = false;
            this.reportTable.AllowUserToDeleteRows = false;
            this.reportTable.AllowUserToResizeColumns = false;
            this.reportTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.reportTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.reportTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.reportTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.reportTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmnNumA,
            this.ClmnNumB,
            this.ClmnAvgTimeA,
            this.ClmnDLockA,
            this.ClmnAvgTimeB,
            this.ClmnDLockB,
            this.ClmIsoType});
            this.reportTable.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.reportTable.EnableHeadersVisualStyles = false;
            this.reportTable.Location = new System.Drawing.Point(130, 12);
            this.reportTable.Name = "reportTable";
            this.reportTable.ReadOnly = true;
            this.reportTable.RowHeadersVisible = false;
            this.reportTable.RowTemplate.Height = 25;
            this.reportTable.Size = new System.Drawing.Size(847, 225);
            this.reportTable.TabIndex = 6;
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.lblTypeA);
            this.grpBox.Controls.Add(this.lblWarning);
            this.grpBox.Controls.Add(this.btnExecute);
            this.grpBox.Controls.Add(this.textBox2);
            this.grpBox.Controls.Add(this.lblTypeB);
            this.grpBox.Controls.Add(this.textBox1);
            this.grpBox.Location = new System.Drawing.Point(12, 12);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(112, 180);
            this.grpBox.TabIndex = 0;
            this.grpBox.TabStop = false;
            this.grpBox.Text = "Entry";
            // 
            // sqlGrid
            // 
            this.sqlGrid.AllowUserToAddRows = false;
            this.sqlGrid.AllowUserToDeleteRows = false;
            this.sqlGrid.AllowUserToResizeColumns = false;
            this.sqlGrid.AllowUserToResizeRows = false;
            this.sqlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sqlGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.sqlGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sqlGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sqlGrid.Location = new System.Drawing.Point(130, 314);
            this.sqlGrid.Name = "sqlGrid";
            this.sqlGrid.RowHeadersVisible = false;
            this.sqlGrid.RowTemplate.Height = 25;
            this.sqlGrid.Size = new System.Drawing.Size(847, 186);
            this.sqlGrid.TabIndex = 7;
            // 
            // btnSelect
            // 
            this.btnSelect.AutoSize = true;
            this.btnSelect.Font = new System.Drawing.Font("Gill Sans MT Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSelect.Location = new System.Drawing.Point(40, 339);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(78, 35);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "List";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(40, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Only Integer!";
            this.label2.Visible = false;
            // 
            // btnFill
            // 
            this.btnFill.Enabled = false;
            this.btnFill.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFill.Location = new System.Drawing.Point(130, 243);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(75, 30);
            this.btnFill.TabIndex = 10;
            this.btnFill.Text = "Show";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // lblFillWarning
            // 
            this.lblFillWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblFillWarning.ForeColor = System.Drawing.Color.Crimson;
            this.lblFillWarning.Location = new System.Drawing.Point(130, 276);
            this.lblFillWarning.Name = "lblFillWarning";
            this.lblFillWarning.Size = new System.Drawing.Size(225, 22);
            this.lblFillWarning.TabIndex = 6;
            this.lblFillWarning.Text = "Threads are not finished! Please wait...";
            this.lblFillWarning.Visible = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLoad.Location = new System.Drawing.Point(292, 243);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 30);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(211, 243);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ClmnNumA
            // 
            this.ClmnNumA.HeaderText = "Number of Type A Users";
            this.ClmnNumA.Name = "ClmnNumA";
            this.ClmnNumA.ReadOnly = true;
            this.ClmnNumA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClmnNumA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClmnNumB
            // 
            this.ClmnNumB.HeaderText = "Number of Type B Users";
            this.ClmnNumB.Name = "ClmnNumB";
            this.ClmnNumB.ReadOnly = true;
            this.ClmnNumB.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClmnNumB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClmnAvgTimeA
            // 
            this.ClmnAvgTimeA.HeaderText = "Average Time of Type A Threads";
            this.ClmnAvgTimeA.Name = "ClmnAvgTimeA";
            this.ClmnAvgTimeA.ReadOnly = true;
            this.ClmnAvgTimeA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ClmnDLockA
            // 
            this.ClmnDLockA.HeaderText = "Number of Deadlocks Encounterd by Type A Users";
            this.ClmnDLockA.Name = "ClmnDLockA";
            this.ClmnDLockA.ReadOnly = true;
            this.ClmnDLockA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ClmnAvgTimeB
            // 
            this.ClmnAvgTimeB.HeaderText = "Average Time of Type B Threads";
            this.ClmnAvgTimeB.Name = "ClmnAvgTimeB";
            this.ClmnAvgTimeB.ReadOnly = true;
            this.ClmnAvgTimeB.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ClmnDLockB
            // 
            this.ClmnDLockB.HeaderText = "Number of Deadlocks Encounterd by Type B Users";
            this.ClmnDLockB.Name = "ClmnDLockB";
            this.ClmnDLockB.ReadOnly = true;
            this.ClmnDLockB.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ClmIsoType
            // 
            this.ClmIsoType.HeaderText = "Isolation Type";
            this.ClmIsoType.Name = "ClmIsoType";
            this.ClmIsoType.ReadOnly = true;
            // 
            // ThreadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 504);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblFillWarning);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.sqlGrid);
            this.Controls.Add(this.reportTable);
            this.Controls.Add(this.grpBox);
            this.Location = new System.Drawing.Point(100, 300);
            this.Name = "ThreadForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Thread Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThreadForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.reportTable)).EndInit();
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sqlGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label lblTypeA;
        private System.Windows.Forms.Label lblTypeB;
        private System.Windows.Forms.DataGridView reportTable;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView sqlGrid;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Label lblFillWarning;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnNumA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnNumB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnAvgTimeA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnDLockA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnAvgTimeB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnDLockB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmIsoType;
    }
}

