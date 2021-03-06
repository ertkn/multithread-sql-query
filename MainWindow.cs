using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace TwoCustomerThread
{
    public partial class MainWindow : Form
    {
        static public ThreadWindow window = new ThreadWindow();
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("loaded...");
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtBoxA.Text) && !String.IsNullOrEmpty(txtBoxB.Text))
            {
                lblWarning.Hide();
                btnExecute.Enabled = false;

                btnResult.Enabled = true;
                btnLoad.Enabled = true;
                btnSave.Enabled = true;

                UserDefinedThreadA(Int32.Parse(txtBoxA.Text));
                UserDefinedThreadB(Int32.Parse(txtBoxB.Text));

                window.Show();
            }

            else
                lblWarning.Show();
        }

        public void UserDefinedThreadA(int threadNum)
        {
            for(int count = 0; count < threadNum; count++)
            {
                ThreadA threadA = new ThreadA((count + 1));
            }
        }
        public void UserDefinedThreadB(int threadNum)
        {
            for (int count = 0; count < threadNum; count++)
            {
                ThreadB threadB = new ThreadB((count + 1));
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '\x08'))
            {
                e.Handled = true;
                lblWarning.Show();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '\x08'))
            {
                e.Handled = true;
                lblWarning.Show();
            }
        }

        private void ThreadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Environment.Exit(Environment.ExitCode);
            (Process.GetCurrentProcess()).Kill();
        }

        public int CntLineFromTxt(string path, DataGridView dataGrid)
        {
            int cntLine = 0;
            using (StreamReader reader = File.OpenText(path))
            {
                while (reader.ReadLine() != null)
                {
                    cntLine++;
                }
            }
            return cntLine;
        }

        public static Boolean IsAssigned()
        {
            if (ThreadA.isoLevel == null)
                return false;
            else
                return true;
        }

        public void ResultTable()
        {
            if (IsAssigned() && ThreadA.isFinished && ThreadB.isFinished)
            {
                lblFillWarning.Hide();
                try
                {
                    reportTable.RowCount = 1;
                    reportTable.Columns[0].ValueType = typeof(Int32);
                    reportTable.Rows[0].Cells[0].Value = int.Parse(txtBoxA.Text);
                    reportTable.Columns[1].ValueType = typeof(Int32);
                    reportTable.Rows[0].Cells[1].Value = int.Parse(txtBoxB.Text);
                    reportTable.Rows[0].Cells[2].Value = (TwoCustomerThread.ThreadA.totTime.Divide(int.Parse(txtBoxA.Text)));
                    reportTable.Rows[0].Cells[3].Value = TwoCustomerThread.ThreadA.deadLock;
                    reportTable.Rows[0].Cells[4].Value = (TwoCustomerThread.ThreadB.totTime.Divide(int.Parse(txtBoxA.Text)));
                    reportTable.Rows[0].Cells[5].Value = TwoCustomerThread.ThreadB.deadLock;
                    reportTable.Rows[0].Cells[6].Value = TwoCustomerThread.ThreadA.isoLevel;
                    reportTable.Columns[7].ValueType = typeof(Int32);
                    reportTable.Rows[0].Cells[7].Value = (ThreadA.sttcQueryCount + ThreadB.sttcQueryCount);
                }
                catch
                {
                    lblFillWarning.Text = "Threads are working. Please wait...";
                    lblFillWarning.Show();
                    reportTable.Rows.Clear();
                }
            }
            else
            {
                lblFillWarning.Text = "Threads are working. Please wait...";
                lblFillWarning.Show();
            }
                
        }

        public void SaveTableData(string textPath)
        {
            if (IsAssigned() && ThreadA.isFinished && ThreadB.isFinished)
            {
                try
                {                    
                    if (!File.Exists(textPath))
                    {
                        using (StreamWriter sw = File.CreateText(textPath))
                        {
                            string saveString = Convert.ToString(txtBoxA.Text) + " - " + Convert.ToString(txtBoxB.Text) + " - " +
                                                 Convert.ToString((TwoCustomerThread.ThreadA.totTime.Divide(int.Parse(txtBoxA.Text)))) + " - " +
                                                  Convert.ToString(TwoCustomerThread.ThreadA.deadLock) + " - " +
                                                   Convert.ToString((TwoCustomerThread.ThreadB.totTime.Divide(int.Parse(txtBoxA.Text)))) + " - " +
                                                    Convert.ToString(TwoCustomerThread.ThreadB.deadLock) + " - " +
                                                     Convert.ToString(ThreadA.isoLevel) + " - " +
                                                      Convert.ToString(ThreadA.sttcQueryCount + ThreadB.sttcQueryCount);
                                                        
                            sw.WriteLine(saveString);
                        }
                    }

                    using (StreamWriter sw = File.AppendText(textPath))
                    {
                        string saveString = Convert.ToString(txtBoxA.Text) + " - " + Convert.ToString(txtBoxB.Text) + " - " +
                                             Convert.ToString((TwoCustomerThread.ThreadA.totTime.Divide(int.Parse(txtBoxA.Text)))) + " - " +
                                              Convert.ToString(TwoCustomerThread.ThreadA.deadLock) + " - " +
                                               Convert.ToString((TwoCustomerThread.ThreadB.totTime.Divide(int.Parse(txtBoxA.Text)))) + " - " +
                                                Convert.ToString(TwoCustomerThread.ThreadB.deadLock) + " - " +
                                                 Convert.ToString(ThreadA.isoLevel) + " - " +
                                                  Convert.ToString(ThreadA.sttcQueryCount + ThreadB.sttcQueryCount);
                        sw.WriteLine(saveString);
                        btnSave.Enabled = false;
                        lblFillWarning.Text = "Records save is accomplished.";
                        lblFillWarning.Show();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("failing to saving data cause {0} exception!", Convert.ToString(ex));
                }

            }
            else
            {
                lblFillWarning.Text = "Threads are working. Please wait...";
                lblFillWarning.Show();
            }
        }
        
        public void LoadTableData(string textPath, DataGridView loadGrid)
        {
            int cntLine = 0;
            //int cntCell = 0;
            loadGrid.RowCount = CntLineFromTxt(textPath, reportTable);
            
            if (File.Exists(textPath))
            {
                using (StreamReader reader = File.OpenText(textPath))
                {
                    string row;
                    while ((row = reader.ReadLine()) != null)
                    {
                        string[] cells = row.Split('-');
                        for (int cntCell = 0; cntCell < cells.Length; cntCell++)
                        {
                            if (cntCell <= 1 || cntCell == 3 || cntCell == 5 || cntCell == 7 )
                            {
                                loadGrid.Rows[cntLine].Cells[cntCell].Value = Int32.Parse(cells[cntCell]);
                            }
                            else
                                loadGrid.Rows[cntLine].Cells[cntCell].Value = cells[cntCell];
                        }
                        cntLine++;
                    }
                }
            }
            else
            {
                lblFillWarning.Text = "File not exist";
                lblFillWarning.Show();
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            ResultTable();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\ozclk\Documents\GitHub\multithread-sql-query\TwoCustomerThread\ResultText.txt";
            SaveTableData(path);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            reportTable.Rows.Clear();
            string path = @"C:\Users\ozclk\Documents\GitHub\multithread-sql-query\TwoCustomerThread\ResultText.txt";
            LoadTableData(path, reportTable);
        }
    }
}