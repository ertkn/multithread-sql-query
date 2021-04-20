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
    public partial class ThreadForm : Form
    {
        public ThreadForm()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {
                lblWarning.Hide();
                btnExecute.Enabled = false;

                btnFill.Enabled = true;
                btnLoad.Enabled = true;
                btnSave.Enabled = true;

                //ThreadType thread = new ThreadType();

                UserDefinedThreadA(int.Parse(textBox1.Text));
                UserDefinedThreadB(int.Parse(textBox2.Text));

            }

            else
                lblWarning.Show();
            //this.Close();
        }

        public void UserDefinedThreadA(int threadNum)
        {
            for(int count = 0; count < threadNum; count++)
            {
                ThreadA threadA = new ThreadA((count + 1));
                threadA.thread.Start();
            }
        }
        public void UserDefinedThreadB(int threadNum)
        {
            for (int count = 0; count < threadNum; count++)
            {
                ThreadB threadB = new ThreadB((count + 1));
                threadB.thread.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("loaded...");
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

        public static Boolean IsVerified()
        {
            var rand = new Random();
            double randNum = rand.NextDouble();
            var condition = randNum < 0.5;
            //MessageBox.Show(condition ? "Condition True: " + condition + i : "Condition False: " + condition + i);
            return condition;
        }

        public static Boolean IsAssigned()
        {
            if (ThreadA.isoLevel == null)
                return false;
            else
                return true;
        }

        public void AddColumn(SqlDataReader reader)
        {
            sqlGrid.ColumnCount = reader.FieldCount;
            for (int cntClmn = 0; cntClmn < reader.FieldCount; cntClmn++)
            {
                sqlGrid.Columns[cntClmn].Name = reader.GetName(cntClmn);
            }
            reader.Close();
        }
        public void AddRow(SqlDataReader reader)
        {

            //String outputMessage = "outputMessage\n";
            int cntRow = 0;

            String output = "output\n";

            //reader = command.ExecuteReader();

            while (reader.Read())
            {

                output = output + " [ " + reader.GetValue(0) + " , " + reader.GetValue(1)
                + " ,  " + reader.GetValue(2) + "  , " + reader.GetValue(3) + " , " + reader.GetValue(4) + "]\n";
                //MessageBox.Show(output);

                //outputMessage += reader.GetValue(cntRow);
                for (int cntCell = 0; cntCell < reader.FieldCount; cntCell++)
                {
                    //outputMessage += reader.GetValue(cntCell) + " - ";
                    //MessageBox.Show(outputMessage);
                    sqlGrid.Rows[cntRow].Cells[cntCell].Value = reader.GetValue(cntCell);
                }

                //sqlGrid.Rows.Add(outputMessage);
                cntRow++;
                //sqlGrid.Rows.Add();
                //outputMessage += "\n";
            }
            reader.Close();

        }

        public int GetRowNum(SqlDataReader reader)
        {
            DataTable dt = new DataTable();
            dt.Load(reader);
            int numRows = dt.Rows.Count;
            sqlGrid.RowCount = numRows;
            //MessageBox.Show("Number of Rows: " + numRows);
            reader.Close();
            return numRows;
            //MessageBox.Show("Number of Rows: " + numRows);
        }

        private SqlDataReader ReaderAssign (SqlDataReader reader, SqlCommand command)
        {
            /*if (!reader.IsClosed)
            {
                reader.Close();
            }*/
            return reader = command.ExecuteReader();
            
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnenction = new SqlConnection(@"Data Source=DESKTOP-704N33C;Initial Catalog=AdventureWorks2012;Integrated Security=True;");
            sqlConnenction.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT TOP 10 * FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20140101' AND '20151231' " +
                "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)", sqlConnenction);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            
            try
            {

                //sqlDataReader.Read();
                GetRowNum(sqlDataReader);
                //ReaderAssign(sqlDataReader,sqlCommand);
                //sqlDataReader = sqlCommand.ExecuteReader();
                AddColumn(ReaderAssign(sqlDataReader,sqlCommand));
                AddRow(ReaderAssign(sqlDataReader, sqlCommand));

                // Call Close when done reading.

                //sqlDataReader.Close();
                sqlCommand.Dispose();
                sqlConnenction.Close();

            }

            catch (SqlException ex)
            {
                MessageBox.Show("An exception of type " + ex.GetType() + " was encountered while attempting to select from table.");
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
            int cntRow = 0;
            using (StreamReader reader = File.OpenText(path))
            {
                while (reader.ReadLine() != null)
                {
                    cntLine++;
                }
            }
            return cntLine;
        }

        public void FillTable()
        {
            if (IsAssigned() && ThreadA.isFinished && ThreadB.isFinished)
            {

                try
                {
                    reportTable.RowCount = 1;
                    reportTable.Rows[0].Cells[0].Value = int.Parse(textBox1.Text);
                    reportTable.Rows[0].Cells[1].Value = int.Parse(textBox2.Text);
                    reportTable.Rows[0].Cells[2].Value = (TwoCustomerThread.ThreadA.totTime.Divide(int.Parse(textBox1.Text)));
                    reportTable.Rows[0].Cells[3].Value = TwoCustomerThread.ThreadA.deadLock;
                    reportTable.Rows[0].Cells[4].Value = (TwoCustomerThread.ThreadB.totTime.Divide(int.Parse(textBox1.Text)));
                    reportTable.Rows[0].Cells[5].Value = TwoCustomerThread.ThreadB.deadLock;
                    reportTable.Rows[0].Cells[6].Value = TwoCustomerThread.ThreadA.isoLevel;

                    lblFillWarning.Hide();
                }
                catch
                {
                    lblFillWarning.Text = "Threads are working. Please wait...";
                    lblFillWarning.Show();
                    reportTable.Rows.Clear();
                    /*reportTable.DataSource = null;
                    reportTable.Refresh();
                    MessageBox.Show("Wait until the thread queries end!\nException Type is :" + e);*/
                }
            }
            lblFillWarning.Text = "Threads are working. Please wait...";
            lblFillWarning.Show();
        }

        public void SaveTableData()
        {
            if (IsAssigned() && ThreadA.isFinished && ThreadB.isFinished)
            {
                try
                {
                    string path = @"C:\Users\ozclk\source\repos\TwoCustomerThread\TextFile1.txt";
                    if (!File.Exists(path))
                    {
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            string saveString = Convert.ToString(textBox1.Text) + " - " + Convert.ToString(textBox2.Text) + " - " +
                                                 Convert.ToString((TwoCustomerThread.ThreadA.totTime.Divide(int.Parse(textBox1.Text)))) + " - " +
                                                  Convert.ToString(TwoCustomerThread.ThreadA.deadLock) + " - " +
                                                   Convert.ToString((TwoCustomerThread.ThreadB.totTime.Divide(int.Parse(textBox1.Text)))) + " - " +
                                                    Convert.ToString(TwoCustomerThread.ThreadB.deadLock) + " - " +
                                                     Convert.ToString(ThreadA.isoLevel);
                            sw.WriteLine(saveString);

                            /*                            File.WriteAllText(@"C:\Users\ozclk\source\repos\TwoCustomerThread\TextFile1.txt", saveString);
                                                        MessageBox.Show(saveString);*/
                        }
                    }

                    using (StreamWriter sw = File.AppendText(path))
                    {
                        string saveString = Convert.ToString(textBox1.Text) + " - " + Convert.ToString(textBox2.Text) + " - " +
                                             Convert.ToString((TwoCustomerThread.ThreadA.totTime.Divide(int.Parse(textBox1.Text)))) + " - " +
                                              Convert.ToString(TwoCustomerThread.ThreadA.deadLock) + " - " +
                                               Convert.ToString((TwoCustomerThread.ThreadB.totTime.Divide(int.Parse(textBox1.Text)))) + " - " +
                                                Convert.ToString(TwoCustomerThread.ThreadB.deadLock) + " - " +
                                                 Convert.ToString(ThreadA.isoLevel);
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
                lblFillWarning.Text = "Threads are working. Please wait...";
                lblFillWarning.Show();
        }
        
        public void LoadTableData(string textPath, DataGridView loadGrid)
        {
            int cntLine = 0;
            //int cntCell = 0;
            loadGrid.RowCount = CntLineFromTxt(textPath, reportTable);

            using (StreamReader reader = File.OpenText(textPath))
            {
                string row;
                while ((row = reader.ReadLine()) != null)
                {
                    string[] cells = row.Split('-');
                    for(int cntCell=0; cntCell<cells.Length; cntCell++)
                    {
                        loadGrid.Rows[cntLine].Cells[cntCell].Value = cells[cntCell];
                    }
                    /*string row = Convert.ToString(reader.ReadLineAsync());
                    while (reader.ReadLine().Split('-') == null)
                    {
                        cntCell++;
                    }
                    */
                    cntLine++;
                }
            }
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            FillTable();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveTableData();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            reportTable.Rows.Clear();
            string path = @"C:\Users\ozclk\source\repos\TwoCustomerThread\TextFile1.txt";
            LoadTableData(path, reportTable);
            //LoadTableData();
        }
    }
}
