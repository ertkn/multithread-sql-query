using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TwoCustomerThread
{
    class ThreadA 
    {
        private Thread _thread;
        private DateTime _bgnTime;
        private DateTime _endTime;
        //private TimeSpan _elapseTime;
        private int _cntDead = 0;
        private int _cntQuery = 0;
        private int _cntAfterQuery = 0;

        static public int sttcAfterQuery =0;
        static public int[] deadList = new int[100];
        static public int sttcQueryCount = 0;
        static private TimeSpan _totTime;
        static private int sttcDeadLock;
        static private string _isoLevel;
        static private bool _isfinished = false;
        static public Random rand = new Random();

        public ThreadA(int thrNum)
        {
            this._thread = new Thread(new ThreadStart(ThrQuery));
            this._thread.Name = "Thread" + thrNum;
            thread.Start();

        }

        public Thread thread{get { return _thread; } set { _thread = value; }}
        
        public DateTime bgnTime{get { return _bgnTime; } set { _bgnTime = value; }}

        public DateTime endTime{get { return _endTime; } set { _endTime = value; }}

        //public TimeSpan elapseTime{get { return _elapseTime; } set { _elapseTime = value; }}

        public int cntDead { get { return _cntDead; } set { _cntDead = value; } }

        public static TimeSpan totTime{get { return _totTime; } set { _totTime = value; }}

        public static int deadLock {get { return sttcDeadLock; } set { sttcDeadLock = value; }}

        public static string isoLevel {get { return _isoLevel; } set { _isoLevel = value; }}

        public static bool isFinished {get { return _isfinished; } set { _isfinished = value; }}

/*        public void SqlUpdateQuery(int fromDate, int toDate,SqlCommand command)
        {
                        try
                        {
                            if (this.rand.NextDouble() < 0.5)
                            {
                                //cntExe++;
                                command.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                                    "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '" + fromDate + "' AND '" + toDate + "' " +
                                    "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
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
                                    cntDead++;
                                }
                                catch (SqlException ex)
                                {
                                }
                            }
                        }
            if (this.rand.NextDouble() < 0.5)
            {
                _cntQuery += 1;
                command.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                    "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '" + fromDate + "' AND '" + toDate + "' " +
                    "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                command.ExecuteNonQuery();
                _cntAfterQuery += 1;
                //MessageBox.Show("sorgu gerçekleşti.");
            }
        }*/

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
                    using(SqlCommand sqlCommand = sqlConn.CreateCommand())
                    {
                        sqlConn.Open();
                        SqlTransaction sqlTran = sqlConn.BeginTransaction(IsolationLevel.ReadUncommitted);

                        isoLevel = (Convert.ToString(sqlTran.IsolationLevel));

                        sqlCommand.Connection = sqlConn;
                        sqlCommand.Transaction = sqlTran;

                        try
                        {
/*
                            SqlUpdateQuery(20110101, 20111231, sqlCommand);
                            SqlUpdateQuery(20120101, 20121231, sqlCommand);
                            SqlUpdateQuery(20130101, 20131231, sqlCommand);
                            SqlUpdateQuery(20140101, 20141231, sqlCommand);
                            SqlUpdateQuery(20150101, 20151231, sqlCommand);*/

                            if (rand.NextDouble() < 0.5)
                            {
                                _cntQuery += 1;
                                sqlCommand.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                                    "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20110101' AND '20111231' " +
                                    "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                                //cmd += Convert.ToString(sqlCommand.ExecuteNonQuery()) + "//";
                                //sqlCommand.CommandTimeout = 1200;
                                sqlCommand.ExecuteNonQuery();
                                _cntAfterQuery += 1;
                                //MessageBox.Show(count+". cycle--First query:"+a);
                            }
                            if (rand.NextDouble() < 0.5)
                            {
                                _cntQuery += 1;
                                sqlCommand.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                                    "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20120101' AND '20121231' " +
                                    "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                                //cmd += Convert.ToString(sqlCommand.ExecuteNonQuery()) + "//";
                                //sqlCommand.CommandTimeout = 1200;
                                sqlCommand.ExecuteNonQuery();
                                _cntAfterQuery += 1;
                                //MessageBox.Show(count+". cycle--Second query:"+a);
                            }
                            if (rand.NextDouble() < 0.5)
                            {
                                _cntQuery += 1;
                                sqlCommand.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                                    "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20130101' AND '20131231' " +
                                    "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                                //cmd += Convert.ToString(sqlCommand.ExecuteNonQuery()) + "//";
                                //sqlCommand.CommandTimeout = 1200;
                                sqlCommand.ExecuteNonQuery();
                                _cntAfterQuery += 1;
                                //MessageBox.Show(count+". cycle--Third query:"+a);
                            }
                            if (rand.NextDouble() < 0.5)
                            {
                                _cntQuery += 1;
                                sqlCommand.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                                    "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20140101' AND '20141231' " +
                                    "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                                //cmd += Convert.ToString(sqlCommand.ExecuteNonQuery()) + "//";
                                //sqlCommand.CommandTimeout = 1200;
                                sqlCommand.ExecuteNonQuery();
                                _cntAfterQuery += 1;
                                //MessageBox.Show(count+". cycle--Fourth query:"+a);
                            }
                            if (rand.NextDouble() < 0.5)
                            {
                                _cntQuery += 1;
                                sqlCommand.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                                    "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20150101' AND '20151231' " +
                                    "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                                //cmd += Convert.ToString(sqlCommand.ExecuteNonQuery());
                                //sqlCommand.CommandTimeout = 1200;
                                sqlCommand.ExecuteNonQuery();
                                _cntAfterQuery += 1;
                                //MessageBox.Show(count+". cycle--Fifth query:"+a);
                            }

                            sqlTran.Commit();
                        }
                        catch (SqlException e)
                        {

                            if (e.Number == 1205)
                            {
                                deadList[count] += 1;
                                _cntDead += 1;
                                //MessageBox.Show("Exception Given 1205A: " + e.Message);
                                ShowException(e.Message);

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
                                //MessageBox.Show("Exception Given: "+e.Message);
                            }
                        }
                        finally
                        {
                            sqlCommand.Dispose();
                            sqlConn.Close();
                            sqlConn.Dispose();
                            //cmd += "["+count + "]. \t\t";
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
            sttcDeadLock += cntDead;
            sttcQueryCount += _cntQuery;
            sttcAfterQuery += this._cntAfterQuery;
            /*            if (_cntDead > 0)
                        {
                            MessageBox.Show(thread.Name+"'s deadlock: "+_cntDead+"Total Deadlock: "+_deadLock);
                        }*/
            isFinished = true;
            MainWindow.window.ThreadStatus("["+thread.Name + "A] finished in: " + endTime.Subtract(bgnTime) + " time. Query: " + _cntQuery + " Deadlock count: " +cntDead);
        }
        public void ShowException(string exception)
        {
            MainWindow.window.ThreadStatus("[" + thread.Name + "A] --> " + exception + ". Query: " + _cntQuery + " Deadlock count: " + cntDead);
        }
    }
}