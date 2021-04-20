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
        private TimeSpan _elapseTime;
        private int _cntDead = 0;

        static private TimeSpan _totTime;
        static private int _deadLock;
        static private string _isoLevel;
        static private bool _isfinished = false;
        Random rand = new Random();

        public ThreadA(int thrNum)
        {
            this._thread = new Thread(new ThreadStart(ThrQuery));
            this._thread.Name = "Thread" + thrNum;
        }

        public Thread thread{get { return _thread; } set { _thread = value; }}
        
        public DateTime bgnTime{get { return _bgnTime; } set { _bgnTime = value; }}

        public DateTime endTime{get { return _endTime; } set { _endTime = value; }}

        public TimeSpan elapseTime{get { return _elapseTime; } set { _elapseTime = value; }}

        public int cntDead { get { return _cntDead; } set { _cntDead = value; } }

        public static TimeSpan totTime{get { return _totTime; } set { _totTime = value; }}

        public static int deadLock {get { return _deadLock; } set { _deadLock = value; }}

        public static string isoLevel {get { return _isoLevel; } set { _isoLevel = value; }}

        public static bool isFinished {get { return _isfinished; } set { _isfinished = value; }}

        public void SqlUpdateQuery(int fromDate, int toDate,SqlCommand command, SqlTransaction sqlTran)
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
                if(e.Number == 1205)
                {
                    try
                    {
                        cntDead++;
                        MessageBox.Show("Inner Try");
                        sqlTran.Rollback();
                    }
                    catch (SqlException ex)
                    {
                        /*if (sqlTran.Connection != null)
                        {
                            MessageBox.Show("THREAD-A: An exception of type " + ex.GetType() +
                                " was encountered while attempting to roll back the transaction.");
                        }*/
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public void ThrQuery()
        {
            string connString = "Data Source= DESKTOP-704N33C;Initial Catalog=AdventureWorks2012;Integrated Security=True;Connection Timeout=30;";
            /*SqlConnection sqlConn;
            SqlTransaction sqlTran;
            SqlCommand sqlCommand;
            */
            this.bgnTime = DateTime.Now;
            //MessageBox.Show(beginTime.ToString("T"));

            for (int count = 0; count < 100; count++)
            {
                isFinished = false;
               
                using(SqlConnection sqlConn = new SqlConnection(connString))
                {
                    sqlConn.Open();
                    using(SqlCommand sqlCommand = sqlConn.CreateCommand())
                    {

                        SqlTransaction sqlTran = sqlConn.BeginTransaction(IsolationLevel.Serializable);

                        isoLevel = (Convert.ToString(sqlTran.IsolationLevel));

                        sqlCommand.Connection = sqlConn;
                        sqlCommand.Transaction = sqlTran;

                        try
                        {

                            SqlUpdateQuery(20110101, 20111231, sqlCommand, sqlTran);
                            SqlUpdateQuery(20120101, 20121231, sqlCommand, sqlTran);
                            SqlUpdateQuery(20130101, 20131231, sqlCommand, sqlTran);
                            SqlUpdateQuery(20140101, 20141231, sqlCommand, sqlTran);
                            SqlUpdateQuery(20150101, 20151231, sqlCommand, sqlTran);

                            sqlTran.Commit();
                        }
                        catch (SqlException e)
                        {
                            if (e.Number == 1205)
                            {
                                MessageBox.Show("Outter Try");
                                cntDead++;
                                try
                                {
                                    sqlTran.Rollback();
                                }
                                catch (SqlException ex)
                                {
                                    throw new Exception(ex.Message);
                                }
                            }
                            else
                                throw new Exception(e.Message);

                        }
                        finally
                        {
                            //sqlCommand.Connection.Close();
                            //sqlTran.Dispose();
                            sqlCommand.Dispose();
                            sqlConn.Close();
                            sqlConn.Dispose();
                        }
                    }
                }
            }

            endTime = DateTime.Now;

            /*MessageBox.Show(endTime.ToString("T"));
            MessageBox.Show(elapsed.ToString("T"));*/
            
            elapseTime = endTime.Subtract(bgnTime); // Record this value for reporting.
            
            totTime += elapseTime;
            deadLock += cntDead;
            isFinished = true;
        }
    }
}

/*if (rand.NextDouble() < 0.5)
                    {
                        cntExe++;
                        sqlCommand.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                            "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20120101' AND '20121231' " +
                            "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                        sqlCommand.ExecuteNonQuery();
                        //MessageBox.Show("sorgu gerçekleşti.");
                    }
                    if (rand.NextDouble() < 0.5)
                    {
                        cntExe++;
                        sqlCommand.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                            "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20130101' AND '20131231' " +
                            "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                        sqlCommand.ExecuteNonQuery();
                        //MessageBox.Show("sorgu gerçekleşti.");
                    }
                    if (rand.NextDouble() < 0.5)
                    {
                        cntExe++;
                        sqlCommand.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                            "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20140101' AND '20141231' " +
                            "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                        sqlCommand.ExecuteNonQuery();
                        //MessageBox.Show("sorgu gerçekleşti.");
                    }
                    if (rand.NextDouble() < 0.5)
                    {
                        cntExe++;
                        sqlCommand.CommandText = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                            "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN '20150101' AND '20151231' " +
                            "AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
                        sqlCommand.ExecuteNonQuery();
                        //MessageBox.Show("sorgu gerçekleşti.");
                    }*/

/*
if ((count + 1) == 100)
{
MessageBox.Show((count + 1) + ". A-" + thread.Name + " bağlantısı açıldı...");
}*/

/*            MessageBox.Show("A-" + thread.Name + " START: " + bgnTime.ToString("T") + "\nA-"+ thread.Name + " END: " + endTime.ToString("T") + "\nA-" + thread.Name + " TIME ELAPSE: " + elapseTime.ToString("T") +
                "\nTransaction " + cntExe + " times executed" + "\nTransaction " + cntExc + " times get exception" + "\nTransaction has " + cntDead + " times DeadLock");*/
//thread.Abort();

//MessageBox.Show("Bağlantı kapatıldı.");
//Console.WriteLine("Both records are written to database.");

/*                    MessageBox.Show("THREAD-A: An exception of type " + e.GetType() +
                        " was encountered while inserting the data.\nNeither record was written to database.");
//MessageBox.Show("Neither record was written to database.");*/