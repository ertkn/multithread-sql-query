using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TwoCustomerThread
{
    public partial class ThreadWindow : Form
    {
        public ThreadWindow()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public void ThreadStatus(string threadInfo)
        {
            this.Invoke(new EventHandler(delegate
            {
                txtStat.AppendText(Environment.NewLine + threadInfo);
                //rtxtStat.AppendText(threadInfo);
            }));
        }

    }
}
