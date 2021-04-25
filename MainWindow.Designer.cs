
namespace TwoCustomerThread
{
    partial class MainWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblTypeA = new System.Windows.Forms.Label();
            this.lblTypeB = new System.Windows.Forms.Label();
            this.txtBoxA = new System.Windows.Forms.TextBox();
            this.txtBoxB = new System.Windows.Forms.TextBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.reportTable = new System.Windows.Forms.DataGridView();
            this.ClmnNumA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnNumB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnAvgTimeA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnDLockA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnAvgTimeB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnDLockB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmIsoType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnQuery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.btnResult = new System.Windows.Forms.Button();
            this.lblFillWarning = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtStat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.reportTable)).BeginInit();
            this.grpBox.SuspendLayout();
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
            // txtBoxA
            // 
            this.txtBoxA.Location = new System.Drawing.Point(7, 37);
            this.txtBoxA.Name = "txtBoxA";
            this.txtBoxA.PlaceholderText = "Enter user value";
            this.txtBoxA.Size = new System.Drawing.Size(99, 23);
            this.txtBoxA.TabIndex = 3;
            this.txtBoxA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // txtBoxB
            // 
            this.txtBoxB.Location = new System.Drawing.Point(7, 83);
            this.txtBoxB.Name = "txtBoxB";
            this.txtBoxB.PlaceholderText = "Enter a value";
            this.txtBoxB.Size = new System.Drawing.Size(99, 23);
            this.txtBoxB.TabIndex = 4;
            this.txtBoxB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
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
            this.reportTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.ClmIsoType,
            this.clmnQuery});
            this.reportTable.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.reportTable.EnableHeadersVisualStyles = false;
            this.reportTable.GridColor = System.Drawing.SystemColors.HotTrack;
            this.reportTable.Location = new System.Drawing.Point(130, 12);
            this.reportTable.Name = "reportTable";
            this.reportTable.ReadOnly = true;
            this.reportTable.RowHeadersVisible = false;
            this.reportTable.RowTemplate.Height = 25;
            this.reportTable.Size = new System.Drawing.Size(847, 480);
            this.reportTable.TabIndex = 6;
            // 
            // ClmnNumA
            // 
            dataGridViewCellStyle2.NullValue = "0";
            this.ClmnNumA.DefaultCellStyle = dataGridViewCellStyle2;
            this.ClmnNumA.HeaderText = "Number of Type A Users";
            this.ClmnNumA.Name = "ClmnNumA";
            this.ClmnNumA.ReadOnly = true;
            this.ClmnNumA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ClmnNumB
            // 
            dataGridViewCellStyle3.NullValue = "0";
            this.ClmnNumB.DefaultCellStyle = dataGridViewCellStyle3;
            this.ClmnNumB.HeaderText = "Number of Type B Users";
            this.ClmnNumB.Name = "ClmnNumB";
            this.ClmnNumB.ReadOnly = true;
            this.ClmnNumB.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ClmnAvgTimeA
            // 
            dataGridViewCellStyle4.NullValue = "0";
            this.ClmnAvgTimeA.DefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.NullValue = "0";
            this.ClmnAvgTimeB.DefaultCellStyle = dataGridViewCellStyle5;
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
            this.ClmIsoType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clmnQuery
            // 
            this.clmnQuery.HeaderText = "Query Count ";
            this.clmnQuery.Name = "clmnQuery";
            this.clmnQuery.ReadOnly = true;
            this.clmnQuery.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.lblTypeA);
            this.grpBox.Controls.Add(this.lblWarning);
            this.grpBox.Controls.Add(this.btnExecute);
            this.grpBox.Controls.Add(this.txtBoxB);
            this.grpBox.Controls.Add(this.lblTypeB);
            this.grpBox.Controls.Add(this.txtBoxA);
            this.grpBox.Location = new System.Drawing.Point(12, 12);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(112, 180);
            this.grpBox.TabIndex = 0;
            this.grpBox.TabStop = false;
            this.grpBox.Text = "Entry";
            // 
            // btnResult
            // 
            this.btnResult.Enabled = false;
            this.btnResult.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnResult.Location = new System.Drawing.Point(49, 210);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(75, 30);
            this.btnResult.TabIndex = 10;
            this.btnResult.Text = "Result";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // lblFillWarning
            // 
            this.lblFillWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblFillWarning.ForeColor = System.Drawing.Color.Crimson;
            this.lblFillWarning.Location = new System.Drawing.Point(19, 339);
            this.lblFillWarning.Name = "lblFillWarning";
            this.lblFillWarning.Size = new System.Drawing.Size(106, 88);
            this.lblFillWarning.TabIndex = 6;
            this.lblFillWarning.Text = "Threads are not finished!         Please wait...";
            this.lblFillWarning.Visible = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLoad.Location = new System.Drawing.Point(49, 306);
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
            this.btnSave.Location = new System.Drawing.Point(49, 259);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtStat
            // 
            this.txtStat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStat.Location = new System.Drawing.Point(983, 15);
            this.txtStat.Multiline = true;
            this.txtStat.Name = "txtStat";
            this.txtStat.PlaceholderText = "Thread Current Status";
            this.txtStat.ReadOnly = true;
            this.txtStat.Size = new System.Drawing.Size(0, 477);
            this.txtStat.TabIndex = 13;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 504);
            this.Controls.Add(this.txtStat);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblFillWarning);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.reportTable);
            this.Controls.Add(this.grpBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(100, 300);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Thread Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThreadForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.reportTable)).EndInit();
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
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
        private System.Windows.Forms.TextBox txtBoxA;
        public System.Windows.Forms.TextBox txtBoxB;
        private System.Windows.Forms.Button btnResult;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnQuery;
        private System.Windows.Forms.TextBox txtStat;
    }
}

