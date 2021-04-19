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
                /*int thName = count;
                Thread thread = new Thread(new ThreadStart(ThreadA));
                thread.Name = "thread" + thName;
                thread.Start();
                MessageBox.Show(Convert.ToString(threadNum));*/

                ThreadA threadA = new ThreadA((count + 1));
                threadA.thread.Start();
            }
        }
        public void UserDefinedThreadB(int threadNum)
        {
            for (int count = 0; count < threadNum; count++)
            {
                /*int thName = count;
                Thread thread = new Thread(new ThreadStart(ThreadB));
                thread.Name = "thread" + thName;
                thread.Start();*/

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

/*        public static Boolean IsFinished()
        {
            MessageBox.Show(Convert.ToString(ThreadA.isFinished ? true : false));
            do
            {
                return ThreadA.isFinished ? true : false;
            } while (!ThreadA.isFinished);
            MessageBox.Show(Convert.ToString(ThreadB.isFinished ? true : false));
            do
            {
                MessageBox.Show(Convert.ToString(ThreadB.isFinished ? true : false));
                return ThreadB.isFinished ? true : false;
            } while (!ThreadB.isFinished);
        }*/

        public void AddColumn(SqlDataReader reader)
        {
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //sqlGrid.ColumnCount = reader.FieldCount;
            //MessageBox.Show("Column Count: " + Convert.ToString(reader.FieldCount));

            /*            String Output = "";
                        while (reader.Read())
                        {
                            Output = Output + reader.GetValue(0) + " - " + reader.GetValue(1)
                                + " - " + reader.GetValue(2) + " - " + reader.GetValue(3) + " - " + reader.GetValue(4) + "\n";
                        }
                        MessageBox.Show(Output);*/

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
           /* SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                    "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader" +
                                                "WHERE Sales.SalesOrderHeader.SalesOrderID =" +
                                                    "Sales.SalesOrderDetail.SalesOrderID" +
                                                "AND Sales.SalesOrderHeader.OrderDate" +
                                                    "BETWEEN ‘20150101’ AND ‘20151231’" +
                                                "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)", sqlConnenction);*/

            SqlCommand sqlCommand = new SqlCommand("SELECT TOP 10 * FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20140101' AND '20151231' " +
                "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)", sqlConnenction);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            
            /*            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(sqlDataReader);
                        int numRows = dt.Rows.Count;
                        MessageBox.Show("Number of Rows: " + numRows);*/
/*
            "UPDATE Sales.SalesOrderDetail" +
                                    "SET UnitPrice = UnitPrice * 10.0 / 10.0" +
                                "WHERE UnitPrice > 100 " +
                                    "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader" +
                                                "WHERE Sales.SalesOrderHeader.SalesOrderID =" +
                                                    "Sales.SalesOrderDetail.SalesOrderID" +
                                                "AND Sales.SalesOrderHeader.OrderDate" +
                                                    "BETWEEN @BeginDate = ‘20150101’ AND @EndDate = ‘20151231’" +
                                                "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)"*/


            try
            {

                //sqlDataReader.Read();
                GetRowNum(sqlDataReader);
                //ReaderAssign(sqlDataReader,sqlCommand);
                //sqlDataReader = sqlCommand.ExecuteReader();
                AddColumn(ReaderAssign(sqlDataReader,sqlCommand));
                AddRow(ReaderAssign(sqlDataReader, sqlCommand));

                /*                String Output = "";
                                while (sqlDataReader.Read())
                                {
                                    Output = Output + sqlDataReader.GetValue(0) + " - " + sqlDataReader.GetValue(1)
                                        + " - " + sqlDataReader.GetValue(2) + " - " + sqlDataReader.GetValue(3) + "\n";
                                }
                                MessageBox.Show(Output);*/

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
            if (IsAssigned())
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
                        lblFillWarning.Text = "Record save is accomplished.";
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
            /*for (int cnt=0; cnt< CntLine(path,reportTable); cnt++)
            {
                //s
            }*/

            /*while
            if (IsAssigned() && ThreadA.isFinished && ThreadB.isFinished)
                {

                }

            string path = @"C:\Users\ozclk\source\repos\TwoCustomerThread\TextFile1.txt";
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    reportTable.RowCount = 1;
                    reportTable.Rows[0].Cells[0].Value = s;
                    reportTable.Rows[0].Cells[1].Value = int.Parse(textBox2.Text);
                    reportTable.Rows[0].Cells[2].Value = TwoCustomerThread.ThreadA.totTime;
                    reportTable.Rows[0].Cells[3].Value = TwoCustomerThread.ThreadA.deadLock;
                    reportTable.Rows[0].Cells[4].Value = TwoCustomerThread.ThreadB.totTime;
                    reportTable.Rows[0].Cells[5].Value = TwoCustomerThread.ThreadB.deadLock;
                    reportTable.Rows[0].Cells[6].Value = TwoCustomerThread.ThreadA.isoLevel;
                }
            }*/
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

/*
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    int count = reader.VisibleFieldCount;
                    MessageBox.Show(Convert.ToString(count));
                }
            }*

/*        public void CreateCommand(String sqlTrn)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = sqlTrn;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.ExecuteNonQuery();
        }*/

/*        public class ThreadType
        {

            // Static method for thread a
            

            // static method for thread b
            

        }*/

/*
                Thread thread1 = new Thread(new ThreadStart(ThreadA));
                Thread thread2 = new Thread(new ThreadStart(ThreadA));
                Thread thread3 = new Thread(new ThreadStart(ThreadA));
                Thread thread4 = new Thread(new ThreadStart(ThreadA));
                Thread thread5 = new Thread(new ThreadStart(ThreadA));
                Thread thread6 = new Thread(new ThreadStart(ThreadB));
                thread1.Start();
                thread2.Start();
                thread3.Start();
                thread4.Start();
                thread5.Start();
                thread6.Start();*/

/*int threadTypeA = int.Parse(textBox1.Text);
ThreadA(threadTypeA);
int threadTypeB = int.Parse(textBox2.Text);
ThreadB(threadTypeA);

ThreadType.threadA(threadTypeA);
ThreadType.threadB(threadTypeB);
System.Windows.Forms.Application.ExitThread();
this.Close();



public void ThreadA()
{
    int cntExe = 0, cntTran = 0, cntEx = 0;
    var rand = new Random();
    DateTime beginTime = DateTime.Now;
    MessageBox.Show("thread A START: " + beginTime.ToString("T"));
    MessageBox.Show(beginTime.ToString("T"));
    for (int count = 0; count < 100; count++)
    {

        SqlConnection sqlConn = new SqlConnection(@"Data Source=DESKTOP-704N33C;Initial Catalog=AdventureWorks2012;Integrated Security=True;");
        sqlConn.Open();

        if ((count + 1) == 100)
        {
            MessageBox.Show((count + 1) + ". Thread A bağlantısı açıldı...");
        }

        SqlTransaction sqlTran = sqlConn.BeginTransaction(IsolationLevel.ReadUncommitted);

        SqlCommand sqlCommand = sqlConn.CreateCommand();

        sqlCommand.Connection = sqlConn;
        sqlCommand.Transaction = sqlTran;

        try
        {
            if (rand.NextDouble() < 0.5)
            {
                cntTran++;
                sqlCommand.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                    "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20110101' AND '20111231' " +
                    "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                sqlCommand.ExecuteNonQuery();
                cntExe++;
                MessageBox.Show("sorgu gerçekleşti.");
            }
            if (rand.NextDouble() < 0.5)
            {
                cntTran++;
                sqlCommand.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                    "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20120101' AND '20121231' " +
                    "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                sqlCommand.ExecuteNonQuery();
                cntExe++;
                MessageBox.Show("sorgu gerçekleşti.");
            }
            if (rand.NextDouble() < 0.5)
            {
                cntTran++;
                sqlCommand.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                    "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20130101' AND '20131231' " +
                    "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                sqlCommand.ExecuteNonQuery();
                cntExe++;
                MessageBox.Show("sorgu gerçekleşti.");
            }
            if (rand.NextDouble() < 0.5)
            {
                cntTran++;
                sqlCommand.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                    "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20140101' AND '20141231' " +
                    "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                sqlCommand.ExecuteNonQuery();
                cntExe++;
                MessageBox.Show("sorgu gerçekleşti.");
            }
            if (rand.NextDouble() < 0.5)
            {
                cntTran++;
                sqlCommand.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                    "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20150101' AND '20151231' " +
                    "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                sqlCommand.ExecuteNonQuery();
                cntExe++;
                MessageBox.Show("sorgu gerçekleşti.");
            }

            sqlTran.Commit();

            MessageBox.Show("Bağlantı kapatıldı.");
            Console.WriteLine("Both records are written to database.");
        }
        catch (Exception e)
        {
            try
            {
                sqlTran.Rollback();
            }
            catch (SqlException ex)
            {
                if (sqlTran.Connection != null)
                {
                    MessageBox.Show("THREAD-A: An exception of type " + ex.GetType() +
                        " was encountered while attempting to roll back the transaction.");
                }
            }
            cntEx++;
            MessageBox.Show("THREAD-A: An exception of type " + e.GetType() +
                " was encountered while inserting the data.\nNeither record was written to database.");
            MessageBox.Show("Neither record was written to database.");
        }
        finally
        {
            sqlConn.Close();
        }
    }

    DateTime endTime = DateTime.Now;
    MessageBox.Show(endTime.ToString("T"));
    TimeSpan elapsed = endTime.Subtract(beginTime); // Record this value for reporting.
    MessageBox.Show(elapsed.ToString("T"));
    MessageBox.Show("thread A START: " + beginTime.ToString("T") + "\nthread A END: " + endTime.ToString("T") + "\nthread A TIME ELAPSE: " + elapsed.ToString("T") +
        "\nTransaction " + cntTran + " times executed" + "\nTransaction " + (cntTran - cntExe) + " times get exception" + "\nTransaction " + (cntEx) + " times get exception");

}

public void ThreadB()
{
    int cntTran = 0;
    var rand = new Random();
    DateTime beginTime = DateTime.Now;
    MessageBox.Show("thread B START: " + beginTime.ToString("T"));
    for (int count = 0; count < 100; count++)
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=DESKTOP-704N33C;Initial Catalog=AdventureWorks2012;Integrated Security=True;");
        sqlConn.Open();
        SqlCommand sqlCommand = sqlConn.CreateCommand();

        if ((count + 1) == 1 || (count + 1) == 100)
        {
            MessageBox.Show((count + 1) + ". Thread B bağlantısı açıldı...");
        }

        SqlTransaction sqlTran = sqlConn.BeginTransaction(IsolationLevel.ReadUncommitted);

        sqlCommand.Connection = sqlConn;
        sqlCommand.Transaction = sqlTran;

        try
        {
            if (rand.NextDouble() < 0.5)
            {
                cntTran++;
                sqlCommand.CommandText =
                    "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                        "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                        "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20110101' AND '20111231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                sqlCommand.ExecuteNonQuery();
            }
            if (rand.NextDouble() < 0.5)
            {
                cntTran++;
                sqlCommand.CommandText =
                    "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                        "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                        "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20120101' AND '20121231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                sqlCommand.ExecuteNonQuery();
            }
            if (rand.NextDouble() < 0.5)
            {
                cntTran++;
                sqlCommand.CommandText =
                    "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                        "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                        "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20130101' AND '20131231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                sqlCommand.ExecuteNonQuery();
            }
            if (rand.NextDouble() < 0.5)
            {
                cntTran++;
                sqlCommand.CommandText =
                    "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                        "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                        "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20140101' AND '20141231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                sqlCommand.ExecuteNonQuery();
            }
            if (rand.NextDouble() < 0.5)
            {
                cntTran++;
                sqlCommand.CommandText =
                    "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                        "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                        "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20150101' AND '20151231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                sqlCommand.ExecuteNonQuery();
            }

            sqlTran.Commit();
            sqlConn.Close();
            MessageBox.Show("Bağlantı kapatıldı.");
            Console.WriteLine("Both records are written to database.");
        }
        catch (Exception e)
        {
            try
            {
                sqlTran.Rollback();
            }
            catch (SqlException ex)
            {
                if (sqlTran.Connection != null)
                {
                    MessageBox.Show("THREAD-B: An exception of type " + ex.GetType() +
                        " was encountered while attempting to roll back the transaction.");
                }
            }

            MessageBox.Show("THREAD-B: An exception of type " + e.GetType() +
                " was encountered while inserting the data.\nNeither record was written to database." + "\nTransaction " + cntTran + " Times Executed");
            Console.WriteLine("Neither record was written to database.");
        }
    }

    DateTime endTime = DateTime.Now;
    MessageBox.Show("thread B END: " + endTime.ToString("T"));
    TimeSpan elapsed = endTime.Subtract(beginTime); // Record this value for reporting.
    MessageBox.Show("thread B TIME ELAPSE: " + elapsed.ToString("T"));

    MessageBox.Show("thread B START: " + beginTime.ToString("T") + "\nthread B END: " + endTime.ToString("T") + "\nthread B TIME ELAPSE: " + elapsed.ToString("T"));
}
*/

/*            "UPDATE Sales.SalesOrderDetail SET Address = @add, City = @cit Where FirstName = @fn and LastName = @add";
            command.ExecuteNonQuery();
            command.CommandText =
                "Insert into Region (RegionID, RegionDescription) VALUES (101, 'Description')";
            command.ExecuteNonQuery();
            transaction.Commit();*/