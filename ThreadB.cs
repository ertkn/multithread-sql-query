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
        private int _cntDeadLock;
        private int _cntTimeout;
        private int _cntQuery;

        private static int _sttcQueryCount;        
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

        public int cntDead { get { return _cntDeadLock; } set { _cntDeadLock = value; } }
        
        public int cntTimeout { get { return _cntTimeout; } set { _cntTimeout= value; } }

        public static TimeSpan totTime { get { return _totTime; } set { _totTime = value; } }
        
        public static int sttcQueryCount { get { return _sttcQueryCount; } set { _sttcQueryCount = value; } }

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

            for (int count = 0; count < 100; count++)
            {
                isFinished = false;

                using (SqlConnection sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();
                    using (SqlCommand sqlCommand = sqlConn.CreateCommand())
                    {

                        SqlTransaction sqlTran = sqlConn.BeginTransaction(IsolationLevel.RepeatableRead);

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
                                //sqlCommand.CommandTimeout = 1200;
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rand.NextDouble() < 0.5)
                            {
                                _cntQuery += 1;
                                sqlCommand.CommandText =
                                    "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                        "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                        "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20120101' AND '20121231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rand.NextDouble() < 0.5)
                            {
                                _cntQuery += 1;
                                sqlCommand.CommandText =
                                    "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                        "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                        "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20130101' AND '20131231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rand.NextDouble() < 0.5)
                            {
                                _cntQuery += 1;
                                sqlCommand.CommandText =
                                    "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                        "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                        "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20140101' AND '20141231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rand.NextDouble() < 0.5)
                            {
                                _cntQuery += 1;
                                sqlCommand.CommandText =
                                    "SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 " +
                                        "AND EXISTS(SELECT* FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                        "AND Sales.SalesOrderHeader.OrderDate BETWEEN '20150101' AND '20151231' AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                                sqlCommand.ExecuteNonQuery();
                            }

                            sqlTran.Commit();
                        }
                        catch (SqlException e)
                        {

                            if (e.Number == 1205)
                            {
                                ShowException(e.Message);
                                _cntDeadLock += 1;
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
                            }
                            else
                            {
                                _cntTimeout += 1;
                                ShowException(e.Message);
                            }
                        }
                        finally
                        {
                            sqlCommand.Dispose();
                            sqlConn.Close();
                            sqlConn.Dispose();
                        }
                    }
                }
            }
            endTime = DateTime.Now;

            totTime += endTime.Subtract(bgnTime);
            sttcDeadLock += _cntDeadLock;
            _sttcQueryCount +=  _cntQuery;
            isFinished = true;
            MainWindow.window.ThreadStatus("["+thread.Name + "B] finished in: " + endTime.Subtract(bgnTime) + " time. Query: " + _cntQuery + " Deadlock count: " + _cntDeadLock + " Timeout count: " + _cntTimeout);
        }

        public void ShowException(string exception)
        {
            MainWindow.window.ThreadStatus("[" + thread.Name + "B] --> " + exception + ". Query: " + _cntQuery + " Deadlock: " + cntDead + " Timeout count: " + _cntTimeout);
        }
    }
}