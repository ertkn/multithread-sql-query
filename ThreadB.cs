﻿using System;
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
        //private TimeSpan _elapseTime;
        private int _cntDead;
        private int _cntQuery;
        
        private int _cntAfterQuery;
        static public int sttcAfterQuery;

        public static int[] deadList = new int[100];
        public static int sttcQueryCount;        
        private static TimeSpan _totTime;
        private static int sttcDeadLock;
        private static bool _isfinished = false;
        Random rand = new Random();

        public ThreadB(int thrNum)
        {
            this._thread = new Thread(new ThreadStart(ThrQuery));
            this._thread.Name = "Thread" + thrNum;
            thread.Start();
        }

        public Thread thread { get { return _thread; } set { _thread = value; } }

        public DateTime bgnTime { get { return _bgnTime; } set { _bgnTime = value; } }

        public DateTime endTime { get { return _endTime; } set { _endTime = value; } }

        //public TimeSpan elapseTime { get { return _elapseTime; } set { _elapseTime = value; } }

        public int cntDead { get { return _cntDead; } set { _cntDead = value; } }

        public static TimeSpan totTime { get { return _totTime; } set { _totTime = value; } }

        public static int deadLock { get { return sttcDeadLock; } set { sttcDeadLock = value; } }

        public static bool isFinished { get { return _isfinished; } set { _isfinished = value; } }

/*        public void SqlSelectQuery(int fromDate, int toDate, SqlCommand command)
        {
                       try
                       {
                           if (this.rand.NextDouble() < 0.5)
                           {
                               //cntExe++;
                               command.CommandText = "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                           "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                           "AND Sales.SalesOrderHeader.OrderDate BETWEEN '" + fromDate + "' AND '" + toDate + "' Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                               command.ExecuteNonQuery();
                               //MessageBox.Show("sorgu gerçekleşti.");
                           }
                       }
                       catch (SqlException e)
                       {
                           if (e.Number == 1205)
                           {
                               try
                               {
                                   cntDead += 1;
                               }
                               catch (SqlException ex)
                               {

                               }
                           }
                       }

            if (this.rand.NextDouble() < 0.5)
            {
                _cntQuery += 1;
                command.CommandText = "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                            "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                            "AND Sales.SalesOrderHeader.OrderDate BETWEEN '" + fromDate + "' AND '" + toDate + "' Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                command.ExecuteNonQuery();
                _cntAfterQuery += 1;
                //MessageBox.Show("sorgu gerçekleşti.");
            }
        }
*/
        public void ThrQuery()
        {
            string strConn = "Data Source= DESKTOP-704N33C;Initial Catalog=AdventureWorks2012;Integrated Security=True;Max Pool Size=200;";
            this.bgnTime = DateTime.Now;
            //MessageBox.Show(beginTime.ToString("T"));
            //string cmd = "";
            for (int count = 0; count < 100; count++)
            {
                isFinished = false;

                using (SqlConnection sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();
                    using (SqlCommand sqlCommand = sqlConn.CreateCommand())
                    {

                        SqlTransaction sqlTran = sqlConn.BeginTransaction(IsolationLevel.ReadUncommitted);

                        sqlCommand.Connection = sqlConn;
                        sqlCommand.Transaction = sqlTran;

                        try
                        {

                            /*                            SqlSelectQuery(20110101, 20111231, sqlCommand);
                                                        SqlSelectQuery(20120101, 20121231, sqlCommand);
                                                        SqlSelectQuery(20130101, 20131231, sqlCommand);
                                                        SqlSelectQuery(20140101, 20141231, sqlCommand);
                                                        SqlSelectQuery(20150101, 20151231, sqlCommand);*/

                            if (rand.NextDouble() < 0.5)
                            {
                                _cntQuery += 1;
                                sqlCommand.CommandText =
                                    "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                        "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                        "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20110101' AND '20111231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                                //cmd += Convert.ToString(sqlCommand.ExecuteScalar()) + "//";
                                //sqlCommand.CommandTimeout = 1200;
                                sqlCommand.ExecuteNonQuery();
                                _cntAfterQuery += 1;
                                //MessageBox.Show(count + ". cycle--First query:" + a);
                            }
                            if (rand.NextDouble() < 0.5)
                            {
                                _cntQuery += 1;
                                sqlCommand.CommandText =
                                    "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                        "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                        "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20120101' AND '20121231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                                //cmd += Convert.ToString(sqlCommand.ExecuteScalar()) + "//";
                                //sqlCommand.CommandTimeout = 1200;
                                sqlCommand.ExecuteNonQuery();
                                _cntAfterQuery += 1;
                                //MessageBox.Show(count + ". cycle--Second query:" + a);
                            }
                            if (rand.NextDouble() < 0.5)
                            {
                                _cntQuery += 1;
                                sqlCommand.CommandText =
                                    "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                        "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                        "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20130101' AND '20131231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                                //cmd += Convert.ToString(sqlCommand.ExecuteScalar()) + "//";
                                //sqlCommand.CommandTimeout = 1200;
                                sqlCommand.ExecuteNonQuery();
                                _cntAfterQuery += 1;
                                //MessageBox.Show(count + ". cycle--Fourth query:" + a);
                            }
                            if (rand.NextDouble() < 0.5)
                            {
                                _cntQuery += 1;
                                sqlCommand.CommandText =
                                    "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                        "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                        "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20140101' AND '20141231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                                //cmd += Convert.ToString(sqlCommand.ExecuteScalar()) + "//";
                                //sqlCommand.CommandTimeout = 1200;
                                sqlCommand.ExecuteNonQuery();
                                _cntAfterQuery += 1;
                                //MessageBox.Show(count + ". cycle--Fourth query:" + a);
                            }
                            if (rand.NextDouble() < 0.5)
                            {
                                _cntQuery += 1;
                                sqlCommand.CommandText =
                                    "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                        "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                        "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20150101' AND '20151231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                                //cmd += Convert.ToString(sqlCommand.ExecuteScalar());
                                //sqlCommand.CommandTimeout = 1200;
                                sqlCommand.ExecuteNonQuery();
                                _cntAfterQuery += 1;
                                //MessageBox.Show(count + ". cycle--Fifth query:" + a);
                            }

                            sqlTran.Commit();
                        }
                        catch (SqlException e)
                        {

                            if (e.Number == 1205)
                            {
                                ShowException(e.Message);
                                deadList[count] += 1;
                                //MessageBox.Show("Exception Given 1205B: " + e.Message);
                                _cntDead += 1;
                                try
                                {
                                    sqlTran.Rollback();
                                }
                                catch
                                {
                                    ShowException(e.Message);
                                }
                            }

                            else if (e.Number == 233)
                            {
                                SqlConnection.ClearPool(sqlConn);
                                ShowException(e.Message);
                                //SqlConnection.ClearAllPools();
                            }
                            else
                            {
                                _cntDead += 1;
                                ShowException(e.Message);
                                //MessageBox.Show("Exception Given: " + e);
                            }
                        }
                        finally
                        {
                            //sqlCommand.Connection.Close();
                            //sqlTran.Dispose();
                            sqlCommand.Dispose();
                            sqlConn.Close();
                            sqlConn.Dispose();
                            //cmd += "["+count+"]. \t\t";
                        }
                    }
                }
            }
            //MessageBox.Show(cmd);
            endTime = DateTime.Now;

            /*MessageBox.Show(endTime.ToString("T"));
            MessageBox.Show(elapsed.ToString("T"));*/

            //elapseTime = endTime.Subtract(bgnTime); // Record this value for reporting.

            totTime += endTime.Subtract(bgnTime);
            sttcDeadLock += _cntDead;
            sttcQueryCount +=  _cntQuery;
            sttcAfterQuery += this._cntAfterQuery;

            /*            if (_cntDead > 0)
                        {
                            MessageBox.Show(thread.Name + "'s deadlock: " + _cntDead + "Total Deadlock: " + _deadLock);
                        }*/
            isFinished = true;
            MainWindow.window.ThreadStatus("["+thread.Name + "B] finished in: " + endTime.Subtract(bgnTime) + " time. Query: " + _cntQuery + " Deadlock count: " + cntDead);
        }

        public void ShowException(string exception)
        {
            MainWindow.window.ThreadStatus("[" + thread.Name + "B] --> " + exception + ". Query: " + _cntQuery + " Deadlock: " + cntDead);
        }
    }
}





/*using System;
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
                try
                {
                    isFinished = false;
                    SqlConnection sqlConn = new SqlConnection(@"Data Source= DESKTOP-704N33C;Initial Catalog=AdventureWorks2012;Integrated Security=True;Connection Timeout=30;");
                    sqlConn.Open();
                    
                    SqlCommand sqlCommand = sqlConn.CreateCommand();
                    SqlTransaction sqlTran = sqlConn.BeginTransaction(IsolationLevel.ReadUncommitted);

                    sqlCommand.Connection = sqlConn;
                    sqlCommand.Transaction = sqlTran;

               
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


                }


                finally
                {
                    sqlCommand.Connection.Close();
                    sqlTran.Dispose();
                    sqlCommand.Dispose();
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


        }
    }
}

*/


/*
                if ((count + 1) == 1 || (count + 1) == 100)
                {
                    MessageBox.Show((count + 1) + ". Thread B bağlantısı açıldı...");
                }*/

/*            MessageBox.Show("B-" + thread.Name + " START: " + bgnTime.ToString("T") + "\nB-" + thread.Name + " END: " + endTime.ToString("T") + "\nB-" + thread.Name + " TIME ELAPSE: " + elapseTime.ToString("T") +
                "\nTransaction " + cntExe + " times executed" + "\nTransaction " + cntExc + " times get exception" + "\nTransaction has " + cntDead + " times deadlock");*/
//thread.Abort();

/*                    MessageBox.Show(thread.Name + " : An exception of type " + e.GetType() +
                        " was encountered while inserting the data.\nNeither record was written to database." +
                        "\nTransaction " + cntExe + " Times Executed" + "\nTransaction " + "\nTransaction " + cntExc + " times get exception");*/
//Console.WriteLine("Neither record was written to database.");

/*
                catch (SqlException ex) when (ex.Number == 1205)
                {
                    cntDead++;
                }*/