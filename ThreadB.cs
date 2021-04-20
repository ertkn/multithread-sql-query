using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TwoCustomerThread
{
    class ThreadB
    {
        private Thread _thread;
        private DateTime _bgnTime;
        private DateTime _endTime;
        private TimeSpan _elapseTime;
        static private TimeSpan _totTime;
        static private int _deadLock;
        static private bool _isfinished = false;

        public ThreadB(int thrNum)
        {
            this._thread = new Thread(new ThreadStart(ThrQuery));
            this._thread.Name = "Thread" + thrNum;
        }

        public Thread thread
        {
            get { return _thread; }
            set { _thread = value; }
        }

        public DateTime bgnTime
        {
            get { return _bgnTime; }
            set { _bgnTime = value; }
        }

        public DateTime endTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        public TimeSpan elapseTime
        {
            get { return _elapseTime; }
            set { _elapseTime = value; }
        }

        public static TimeSpan totTime
        {
            get { return _totTime; }
            set { _totTime = value; }
        }

        public static int deadLock
        {
            get { return _deadLock; }
            set { _deadLock = value; }
        }

        public static bool isFinished
        {
            get { return _isfinished; }
            set { _isfinished = value; }
        }

        public void ThrQuery()
        {
            int cntDead = 0, cntExe = 0, cntExc = 0;
            var rand = new Random();
            bgnTime = DateTime.Now;
            //MessageBox.Show("A-" + thread.Name + " START: " + bgnTime.ToString("T"));

            for (int count = 0; count < 100; count++)
            {
                isFinished = false;
                SqlConnection sqlConn = new SqlConnection(@"Data Source= DESKTOP-704N33C;Initial Catalog=AdventureWorks2012;Integrated Security=True;");
                sqlConn.Open();
                SqlCommand sqlCommand = sqlConn.CreateCommand();
                /*
                                if ((count + 1) == 1 || (count + 1) == 100)
                                {
                                    MessageBox.Show((count + 1) + ". Thread B bağlantısı açıldı...");
                                }*/

                SqlTransaction sqlTran = sqlConn.BeginTransaction(IsolationLevel.ReadUncommitted);

                sqlCommand.Connection = sqlConn;
                sqlCommand.Transaction = sqlTran;

                try
                {
                    if (rand.NextDouble() < 0.5)
                    {
                        cntExe++;
                        sqlCommand.CommandText =
                            "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20110101' AND '20111231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                        sqlCommand.ExecuteNonQuery();
                    }
                    if (rand.NextDouble() < 0.5)
                    {
                        cntExe++;
                        sqlCommand.CommandText =
                            "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20120101' AND '20121231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                        sqlCommand.ExecuteNonQuery();
                    }
                    if (rand.NextDouble() < 0.5)
                    {
                        cntExe++;
                        sqlCommand.CommandText =
                            "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20130101' AND '20131231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                        sqlCommand.ExecuteNonQuery();
                    }
                    if (rand.NextDouble() < 0.5)
                    {
                        cntExe++;
                        sqlCommand.CommandText =
                            "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20140101' AND '20141231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                        sqlCommand.ExecuteNonQuery();
                    }
                    if (rand.NextDouble() < 0.5)
                    {
                        cntExe++;
                        sqlCommand.CommandText =
                            "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20150101' AND '20151231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                        sqlCommand.ExecuteNonQuery();
                    }
                    sqlTran.Commit();

                    //MessageBox.Show("Bağlantı kapatıldı.");
                    //Console.WriteLine("Both records are written to database.");
                }


                catch (SqlException e)
                {
                    try
                    {
                        sqlTran.Rollback();
                        if(e.Number == 1205)
                        {
                            cntDead++;
                        }
                    }
                    catch (SqlException ex)
                    {
                        if (sqlTran.Connection != null)
                        {
                            MessageBox.Show("THREAD-B: An exception of type " + ex.GetType() +
                                " was encountered while attempting to roll back the transaction.");
                        }
                    }

                    cntExc++;
/*                    MessageBox.Show(thread.Name + " : An exception of type " + e.GetType() +
                        " was encountered while inserting the data.\nNeither record was written to database." +
                        "\nTransaction " + cntExe + " Times Executed" + "\nTransaction " + "\nTransaction " + cntExc + " times get exception");*/
                    //Console.WriteLine("Neither record was written to database.");

                }
/*
                catch (SqlException ex) when (ex.Number == 1205)
                {
                    cntDead++;
                }*/

                finally
                {
                    sqlConn.Close();
                }
            }

            endTime = DateTime.Now;
            //MessageBox.Show("thread B END: " + endTime.ToString("T"));
            elapseTime = endTime.Subtract(bgnTime); // Record this value for reporting.
                                                    //MessageBox.Show("thread B TIME ELAPSE: " + elapsed.ToString("T"));
            totTime += elapseTime;
            deadLock += cntDead;
            isFinished = true; 

/*            MessageBox.Show("B-" + thread.Name + " START: " + bgnTime.ToString("T") + "\nB-" + thread.Name + " END: " + endTime.ToString("T") + "\nB-" + thread.Name + " TIME ELAPSE: " + elapseTime.ToString("T") +
                "\nTransaction " + cntExe + " times executed" + "\nTransaction " + cntExc + " times get exception" + "\nTransaction has " + cntDead + " times deadlock");*/
            //thread.Abort();
        }
    }
}