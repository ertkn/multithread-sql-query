
namespace TwoCustomerThread
{
    partial class ThreadWindow
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
            this.txtStat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtStat
            // 
            this.txtStat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStat.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtStat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStat.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtStat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(94)))), ((int)(((byte)(108)))));
            this.txtStat.Location = new System.Drawing.Point(12, 12);
            this.txtStat.Multiline = true;
            this.txtStat.Name = "txtStat";
            this.txtStat.ReadOnly = true;
            this.txtStat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStat.Size = new System.Drawing.Size(580, 351);
            this.txtStat.TabIndex = 0;
            // 
            // ThreadWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(600, 375);
            this.Controls.Add(this.txtStat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1050, 300);
            this.Name = "ThreadWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Thread Status";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtStat;
    }
}