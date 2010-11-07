using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using eConcierge.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using eConcierge.Common;

namespace eConcierge.ServerDataHandler
{
    public class ServerDatabaseHandler : BaseDatabaseHandler
    {
      
        public DataSet GetData(string tableName, QueryParamList pParams, ref string pErrString)
        {
            string query = "SELECT * FROM " + tableName;
            AddWhereClause(ref query, pParams);
            return LoadDataSet(query, pParams, tableName, ref pErrString);
        }

        public void ExecuteQuery(string query, QueryParamList pParams, ref string pErrString)
        {
            DBExecCommandEx(query, pParams, ref pErrString);
        }

        private void AddWhereClause(ref string query, QueryParamList pParams)
        {
            // query += " WHERE LanguageType=" + (int)LanguageLoader.CurrentLanguageType;
            query += " WHERE 1=1 ";
            if (pParams.Count > 0)
            {
                foreach (QueryParamObj item in pParams)
                {
                    query += " AND " + item.ParamName + " = @" + item.ParamName;
                }
            }
        }

        public bool SetData(QueryParamList pParam, string spName, ref string pErrString)
        {
            DBExecStoredProc(spName, pParam, ref pErrString);
            return string.IsNullOrEmpty(pErrString); 
        }

        public bool SetData(List<QueryParamList> paramList, string spName, ref string pErrString)
        {

            Database db = GetSQLDatabase();
            DbConnection connection = db.CreateConnection();
            DbTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                foreach (QueryParamList param in paramList)
                {
                    DbCommand cmd = db.GetStoredProcCommand(spName);
                    DBExecStoredProcInTran(db, cmd, param, transaction);
                }
                transaction.Commit();
            }
            catch (Exception exp)
            {
                transaction.Rollback();
                pErrString = exp.Message;
                LoggingUtility.WriteLog(exp);
                return string.IsNullOrEmpty(pErrString); 
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        #region Client Bulk
        //public List<DTOClient> GetClients(QueryParamList pParam, ref string pErrString)
        //{
        //    string query = "SELECT Id, ClientId, Name, BOAccountNumber, PhoneNumber, LastUpdated FROM Client";
        //    AddWhereClause(ref query, pParam);
        //    return ExecuteDBQuery(query, pParam, PopulateClients);
        //}

        
        
        //private List<DTOClient> PopulateClients(DbDataReader oDbDataReader)
        //{
        //    List<DTOClient> lst = new List<DTOClient>();
        //    while (oDbDataReader.Read())
        //    {
        //        DTOClient oDTOClient = new DTOClient();
        //        oDTOClient.Id = oDbDataReader["Id"] != DBNull.Value ? Convert.ToInt32(oDbDataReader["Id"]) : oDTOClient.Id;
        //        oDTOClient.ClientId = oDbDataReader["ClientId"] != DBNull.Value ? Convert.ToString(oDbDataReader["ClientId"]) : oDTOClient.ClientId;
        //        oDTOClient.Name = oDbDataReader["Name"] != DBNull.Value ? Convert.ToString(oDbDataReader["Name"]) : oDTOClient.Name;
        //        oDTOClient.BOAccountNumber = oDbDataReader["BOAccountNumber"] != DBNull.Value ? Convert.ToString(oDbDataReader["BOAccountNumber"]) : oDTOClient.BOAccountNumber;
        //        oDTOClient.PhoneNumber = oDbDataReader["PhoneNumber"] != DBNull.Value ? Convert.ToString(oDbDataReader["PhoneNumber"]) : oDTOClient.PhoneNumber;
        //        oDTOClient.LastUpdated = oDbDataReader["LastUpdated"] != DBNull.Value ? Convert.ToDateTime(oDbDataReader["LastUpdated"]) : oDTOClient.LastUpdated;
        //        lst.Add(oDTOClient);
        //    }
        //    return lst;
        //}

        //public void SaveClientData(QueryParamList clientParam, string spName, QueryParamList clientCredentialParam, string ccSPName, ref string pErrString)
        //{
        //    Database db = GetSQLDatabase();
        //    DbConnection connection = db.CreateConnection();
        //    DbTransaction transaction = null;
        //    try
        //    {
        //        connection.Open();
        //        transaction = connection.BeginTransaction();

        //        DbCommand cmd = db.GetStoredProcCommand(spName);
        //        int id = DBExecStoredProcInTranReturnsIdentity(db, cmd, clientParam, transaction);
        //        if (id < 0)
        //            throw new Exception();
        //        clientCredentialParam.Add(new QueryParamObj() { ParamName = "ClientId", DBType = DbType.Int32, ParamValue = id });

        //        cmd = db.GetStoredProcCommand(ccSPName);
        //        DBExecStoredProcInTranReturnsIdentity(db, cmd, clientCredentialParam, transaction);

        //        transaction.Commit();
        //    }
        //    catch (Exception exp)
        //    {
        //        transaction.Rollback();
        //        pErrString = exp.Message;
        //        LoggingUtility.WriteLog(exp);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}

       
        #endregion

        #region Event Calendar Category
        public List<DTOEventCalendarCategory> GetEventCalendarCategorys(QueryParamList pParam, ref string pErrString)
        {
            string query = "SELECT Id, Name, Description FROM EventCalendarCategory";
            AddWhereClause(ref query, pParam);
            return ExecuteDBQuery(query, pParam, PopulateEventCalendarCategorys);
        }
        private List<DTOEventCalendarCategory> PopulateEventCalendarCategorys(DbDataReader oDbDataReader)
        {
            List<DTOEventCalendarCategory> lst = new List<DTOEventCalendarCategory>();
            while (oDbDataReader.Read())
            {
                DTOEventCalendarCategory oDTOEventCalendarCategory = new DTOEventCalendarCategory();
                oDTOEventCalendarCategory.Id = oDbDataReader["Id"] != DBNull.Value ? Convert.ToInt32(oDbDataReader["Id"]) : oDTOEventCalendarCategory.Id;
                oDTOEventCalendarCategory.Name = oDbDataReader["Name"] != DBNull.Value ? Convert.ToString(oDbDataReader["Name"]) : oDTOEventCalendarCategory.Name;
                oDTOEventCalendarCategory.Description = oDbDataReader["Description"] != DBNull.Value ? Convert.ToString(oDbDataReader["Description"]) : oDTOEventCalendarCategory.Description;
                lst.Add(oDTOEventCalendarCategory);
            }
            return lst;
        }
        #endregion
    }
}
