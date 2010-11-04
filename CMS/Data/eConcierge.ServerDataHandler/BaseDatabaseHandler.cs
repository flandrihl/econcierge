using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using eConcierge.Common;

namespace eConcierge.ServerDataHandler
{
    public abstract class BaseDatabaseHandler
    {
        protected string CONNECTIONSTRING;
        public BaseDatabaseHandler()
        {
            CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["eConciergeDB"].ConnectionString;
        }
        protected void SwitchToDefaultConnectionString()
        {
            CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["eConciergeDB"].ConnectionString;
        }

        protected Database GetSQLDatabase()
        {
            return new SqlDatabase(CONNECTIONSTRING);
        }


        protected DataSet GetSPResultSetEx(string storedProcName, QueryParamList spParams, ref string pErrString)
        {
            Database db = GetSQLDatabase();
            DataSet ds = new DataSet();
            try
            {

                using (DbCommand cmd = db.GetStoredProcCommand(storedProcName))
                {

                    if (spParams != null)
                    {
                        foreach (QueryParamObj obj in spParams)
                        {
                            db.AddInParameter(cmd, obj.ParamName, obj.DBType, obj.ParamValue);
                        }
                    }
                    ds = db.ExecuteDataSet(cmd);
                }

            }
            catch (Exception ex)
            {
                pErrString = ex.Message;
                LoggingUtility.WriteLog(ex);
            }
            return ds;
        }

        protected void DBExecSPInOutEx(string storedProcName, ref QueryParamList spParams, int pCommandTimeout, ref string pErrString)
        {
            Database db = GetSQLDatabase();
            DbCommand cmd = db.GetStoredProcCommand(storedProcName);
            if (pCommandTimeout > 0)
            {
                cmd.CommandTimeout = pCommandTimeout;
            }

            if (spParams != null)
            {
                foreach (QueryParamObj obj in spParams)
                {
                    db.AddParameter(cmd, obj.ParamName, obj.DBType, obj.ParamDirection, null, DataRowVersion.Current, obj.ParamValue);
                }
            }
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex) { pErrString = ex.Message; LoggingUtility.WriteLog(ex); }
            finally
            {
                if (spParams != null)
                {
                    foreach (QueryParamObj obj in spParams)
                    {
                        obj.ParamValue = db.GetParameterValue(cmd, obj.ParamName);
                    }
                }
                CloseConnection(cmd);
            }
        }

        /// <summary>
        /// Executes a stored procedure on the live config db with parameters specifying the company
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="spParams"></param>
        /// <param name="pCompanyNumber"></param>
        protected void DBExecStoredProc(string storedProcName, QueryParamList spParams, ref string pErrString)
        {
            Database db = GetSQLDatabase();
            using (DbCommand cmd = db.GetStoredProcCommand(storedProcName))
            {
                if (spParams != null)
                {
                    foreach (QueryParamObj obj in spParams)
                    {
                        db.AddInParameter(cmd, obj.ParamName, obj.DBType, obj.ParamValue);
                    }
                }
                try
                {
                    db.ExecuteNonQuery(cmd);
                }
                catch (Exception ex)
                {
                    pErrString = ex.Message;
                    LoggingUtility.WriteLog(ex);
                }
            }

        }




        /// <summary>
        /// Executes a stored procedure on the live config db with parameters specifying the company with transaction parameter to do transaction management
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="spParams"></param>
        /// <param name="pCompanyNumber"></param>
        /// <param name="pTransaction"></param>
        /// <returns></returns>
        protected int DBExecStoredProcInTran(Database db, DbCommand cmd, QueryParamList spParams, DbTransaction pTransaction)
        {
            if (spParams != null)
            {
                foreach (QueryParamObj obj in spParams)
                {
                    db.AddInParameter(cmd, obj.ParamName, obj.DBType, obj.ParamValue);
                }
            }
            return db.ExecuteNonQuery(cmd, pTransaction);

        }

        protected int DBExecStoredProcInTranReturnsIdentity(Database db, DbCommand cmd, QueryParamList spParams, DbTransaction pTransaction)
        {
            if (spParams != null)
            {
                foreach (QueryParamObj obj in spParams)
                {
                    db.AddInParameter(cmd, obj.ParamName, obj.DBType, obj.ParamValue);
                }
            }

            object identity = db.ExecuteScalar(cmd, pTransaction);
            return identity != DBNull.Value ? Convert.ToInt32(identity) : -1;

        }

        /// <summary>
        ///Private Metod that executes a sql command on specified db that does not return a resultset
        /// </summary>
        /// <param name="queryName"></param>
        /// <param name="spParams"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        protected void DBExecCommandEx(string query, QueryParamList spParams, Database db, ref string pErrString)
        {
            try
            {
                using (DbCommand cmd = db.GetSqlStringCommand(query))
                {
                    if (spParams != null)
                    {
                        foreach (QueryParamObj obj in spParams)
                        {
                            db.AddInParameter(cmd, obj.ParamName, obj.DBType, obj.ParamValue);
                        }
                    }
                    db.ExecuteNonQuery(cmd);
                }
            }
            catch (Exception e)
            {
                pErrString = e.Message;
                LoggingUtility.WriteLog(e);

            }
        }

        protected void DBExecCommandEx(string query, QueryParamList spParams, ref string pErrString)
        {
            Database db = GetSQLDatabase();
            DBExecCommandEx(query, spParams, db, ref pErrString);
        }

        protected int DBExecCommandExTran(string query, QueryParamList spParams, DbTransaction pTransaction, Database db, ref string pErrString)
        {
            DbCommand cmd = db.GetSqlStringCommand(query);
            if (spParams != null)
            {
                foreach (QueryParamObj obj in spParams)
                {
                    db.AddInParameter(cmd, obj.ParamName, obj.DBType, obj.ParamValue);
                }
            }
            return db.ExecuteNonQuery(cmd, pTransaction);
        }

        protected DataSet LoadDataSet(string query, QueryParamList spParams, string tableName, ref string pErrString)
        {
            Database db = GetSQLDatabase();
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand cmd = db.GetSqlStringCommand(query))
                {
                    if (spParams != null)
                    {
                        foreach (QueryParamObj obj in spParams)
                        {
                            db.AddInParameter(cmd, obj.ParamName, obj.DBType, obj.ParamValue);
                        }
                    }
                    db.LoadDataSet(cmd, ds, tableName);
                }

            }
            catch (Exception e)
            {
                pErrString = e.Message;
                LoggingUtility.WriteLog(e);
            }
            return ds;
        }

        protected object DBExecuteScalar(string query, QueryParamList spParams, ref string pErrString)
        {
            Database db = GetSQLDatabase();
            object result = null;
            try
            {
                using (DbCommand cmd = db.GetSqlStringCommand(query))
                {
                    if (spParams != null)
                    {
                        foreach (QueryParamObj obj in spParams)
                        {
                            db.AddInParameter(cmd, obj.ParamName, obj.DBType, obj.ParamValue);
                        }
                    }
                    result = db.ExecuteScalar(cmd);
                }
            }
            catch (Exception e)
            {
                pErrString = e.Message;
                LoggingUtility.WriteLog(e);
            }
            return result;
        }

        protected object DBExecuteScalar(string query, QueryParamList spParams, DbTransaction pTransaction, Database db)
        {
            object result = null;

            using (DbCommand cmd = db.GetSqlStringCommand(query))
            {
                if (spParams != null)
                {
                    foreach (QueryParamObj obj in spParams)
                    {
                        db.AddInParameter(cmd, obj.ParamName, obj.DBType, obj.ParamValue);
                    }
                }
                result = db.ExecuteScalar(cmd, pTransaction);
            }
            return result;
        }

        protected object DBExecuteScalarSP(string spName, QueryParamList spParams, Database db)
        {
            object result = null;

            using (DbCommand cmd = db.GetStoredProcCommand(spName))
            {
                if (spParams != null)
                {
                    foreach (QueryParamObj obj in spParams)
                    {
                        db.AddInParameter(cmd, obj.ParamName, obj.DBType, obj.ParamValue);
                    }
                }
                try
                {
                    result = db.ExecuteScalar(cmd);
                }
                catch (Exception ex)
                {
                    LoggingUtility.WriteLog(ex);
                }
            }
            return result;
        }
        protected object DBExecuteScalarSP(string spName, QueryParamList spParams)
        {
            object result = null;
            Database db = GetSQLDatabase();
            using (DbCommand cmd = db.GetStoredProcCommand(spName))
            {
                if (spParams != null)
                {
                    foreach (QueryParamObj obj in spParams)
                    {
                        db.AddInParameter(cmd, obj.ParamName, obj.DBType, obj.ParamValue);
                    }
                }
                try
                {
                    result = db.ExecuteScalar(cmd);
                }
                catch (Exception ex)
                {
                    LoggingUtility.WriteLog(ex);
                }
                
            }
            return result;
        }

        protected object DBExecuteScalarSP(string spName, QueryParamList spParams, DbTransaction pTransaction, Database db)
        {
            object result = null;

            using (DbCommand cmd = db.GetStoredProcCommand(spName))
            {
                if (spParams != null)
                {
                    foreach (QueryParamObj obj in spParams)
                    {
                        db.AddInParameter(cmd, obj.ParamName, obj.DBType, obj.ParamValue);
                    }
                }

                result = db.ExecuteScalar(cmd, pTransaction);
            }
            return result;
        }

        
        /// <summary>
        /// Runs a query on DB with parameters and returns a dbDataReader. must close the reader after done with reader.
        /// </summary>
        /// <param name="queryName"></param>
        /// <param name="queryParams"></param>        
        /// <returns></returns>
        public DbDataReader GetDBQueryReader(string query, QueryParamList queryParams)
        {
            Database db = GetSQLDatabase();
            DbCommand  command = db.GetSqlStringCommand(query);
            if (command.Connection == null)
                command.Connection = db.CreateConnection();
            if (queryParams != null)
            {
                foreach (QueryParamObj obj in queryParams)
                {
                    db.AddInParameter(command, obj.ParamName, obj.DBType, obj.ParamValue);
                }
            }
            if (command.Connection.State != ConnectionState.Open)
            {
                command.Connection.Open();
            }
            DbDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
            return reader;
        }

        public List<T> ExecuteDBQuery<T>(string query, QueryParamList queryParams, Func<DbDataReader, List<T>> populateData)
        {
            Database db = GetSQLDatabase();
            DbCommand command = db.GetSqlStringCommand(query);
            if (command.Connection == null)
                command.Connection = db.CreateConnection();
            if (queryParams != null)
            {
                foreach (QueryParamObj obj in queryParams)
                {
                    db.AddInParameter(command, obj.ParamName, obj.DBType, obj.ParamValue);
                }
            }
            DbDataReader reader = null;
            List<T> list = new List<T>();
            try
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                reader = command.ExecuteReader(CommandBehavior.SingleResult);
                list = populateData(reader);
            }
            catch (Exception e)
            {
                LoggingUtility.WriteLog(e);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                CloseConnection(command);
            }
            return list;

        }
        protected List<T> ExecuteStoreProcedure<T>(string storedProcName, QueryParamList spParams, Func<DbDataReader, List<T>> populateData)
        {
            Database db = GetSQLDatabase();
            using (DbCommand cmd = db.GetStoredProcCommand(storedProcName))
            {
                if (cmd.Connection == null)
                    cmd.Connection = db.CreateConnection();

                if (spParams != null)
                {
                    foreach (QueryParamObj obj in spParams)
                    {
                        db.AddInParameter(cmd, obj.ParamName, obj.DBType, obj.ParamValue);
                    }
                }
                DbDataReader reader = null;
                List<T> list = new List<T>();
                try
                {
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    cmd.CommandTimeout = 240;
                    reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    list = populateData(reader);
                }
                catch (Exception e)
                {
                    LoggingUtility.WriteLog(e);
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                    CloseConnection(cmd);
                }
                return list;
            }

        }
        protected void CloseConnection(DbCommand command)
        {
            if (command != null && command.Connection.State == ConnectionState.Open)
            {
                command.Connection.Close();
            }
        }
    }
}
