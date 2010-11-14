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

        #region Event Calendar
        public List<DTOCalendarEvent> GetCalendarEvents(QueryParamList pParam, ref string pErrString)
        {
            string query = "SELECT Id, CategoryId, Title, Description, Photo, StartDate, EndDate, Location, Latitude, Longitude FROM CalendarEvent";
            AddWhereClause(ref query, pParam);
            return ExecuteDBQuery(query, pParam, PopulateCalendarEvents);
        }
        private List<DTOCalendarEvent> PopulateCalendarEvents(DbDataReader oDbDataReader)
        {
            List<DTOCalendarEvent> lst = new List<DTOCalendarEvent>();
            while (oDbDataReader.Read())
            {
                DTOCalendarEvent oDTOCalendarEvent = new DTOCalendarEvent();
                oDTOCalendarEvent.Id = oDbDataReader["Id"] != DBNull.Value ? Convert.ToInt32(oDbDataReader["Id"]) : oDTOCalendarEvent.Id;
                oDTOCalendarEvent.CategoryId = oDbDataReader["CategoryId"] != DBNull.Value ? Convert.ToInt32(oDbDataReader["CategoryId"]) : oDTOCalendarEvent.CategoryId;
                oDTOCalendarEvent.Title = oDbDataReader["Title"] != DBNull.Value ? Convert.ToString(oDbDataReader["Title"]) : oDTOCalendarEvent.Title;
                oDTOCalendarEvent.Description = oDbDataReader["Description"] != DBNull.Value ? Convert.ToString(oDbDataReader["Description"]) : oDTOCalendarEvent.Description;
                oDTOCalendarEvent.Photo = oDbDataReader["Photo"] != DBNull.Value ? (Byte[])(oDbDataReader["Photo"]) : oDTOCalendarEvent.Photo;
                oDTOCalendarEvent.StartDate = oDbDataReader["StartDate"] != DBNull.Value ? Convert.ToDateTime(oDbDataReader["StartDate"]) : oDTOCalendarEvent.StartDate;
                oDTOCalendarEvent.EndDate = oDbDataReader["EndDate"] != DBNull.Value ? Convert.ToDateTime(oDbDataReader["EndDate"]) : oDTOCalendarEvent.EndDate;
                oDTOCalendarEvent.Location = oDbDataReader["Location"] != DBNull.Value ? Convert.ToString(oDbDataReader["Location"]) : oDTOCalendarEvent.Location;
                oDTOCalendarEvent.Latitude = oDbDataReader["Latitude"] != DBNull.Value ? Convert.ToDouble(oDbDataReader["Latitude"]) : oDTOCalendarEvent.Latitude;
                oDTOCalendarEvent.Longitude = oDbDataReader["Longitude"] != DBNull.Value ? Convert.ToDouble(oDbDataReader["Longitude"]) : oDTOCalendarEvent.Longitude;
                lst.Add(oDTOCalendarEvent);
            }
            return lst;
        }
        #endregion

        #region Dining Category
        public List<DTODiningCategory> GetDiningCategorys(QueryParamList pParam, ref string pErrString)
        {
            string query = "SELECT Id, Title, Description FROM DiningCategory";
            AddWhereClause(ref query, pParam);
            return ExecuteDBQuery(query, pParam, PopulateDiningCategorys);
        }
        private List<DTODiningCategory> PopulateDiningCategorys(DbDataReader oDbDataReader)
        {
            List<DTODiningCategory> lst = new List<DTODiningCategory>();
            while (oDbDataReader.Read())
            {
                DTODiningCategory oDTODiningCategory = new DTODiningCategory();
                oDTODiningCategory.Id = oDbDataReader["Id"] != DBNull.Value ? Convert.ToInt32(oDbDataReader["Id"]) : oDTODiningCategory.Id;
                oDTODiningCategory.Title = oDbDataReader["Title"] != DBNull.Value ? Convert.ToString(oDbDataReader["Title"]) : oDTODiningCategory.Title;
                oDTODiningCategory.Description = oDbDataReader["Description"] != DBNull.Value ? Convert.ToString(oDbDataReader["Description"]) : oDTODiningCategory.Description;
                lst.Add(oDTODiningCategory);
            }
            return lst;
        }
        #endregion

        #region Dining Sub Category
        public List<DTODiningSubCategory> GetDiningSubCategorys(QueryParamList pParam, ref string pErrString)
        {
            string query = "SELECT Id, CategoryId, Title, Description FROM DiningSubCategory";
            AddWhereClause(ref query, pParam);
            return ExecuteDBQuery(query, pParam, PopulateDiningSubCategorys);
        }
        private List<DTODiningSubCategory> PopulateDiningSubCategorys(DbDataReader oDbDataReader)
        {
            List<DTODiningSubCategory> lst = new List<DTODiningSubCategory>();
            while (oDbDataReader.Read())
            {
                DTODiningSubCategory oDTODiningSubCategory = new DTODiningSubCategory();
                oDTODiningSubCategory.Id = oDbDataReader["Id"] != DBNull.Value ? Convert.ToInt32(oDbDataReader["Id"]) : oDTODiningSubCategory.Id;
                oDTODiningSubCategory.CategoryId = oDbDataReader["CategoryId"] != DBNull.Value ? Convert.ToInt32(oDbDataReader["CategoryId"]) : oDTODiningSubCategory.CategoryId;
                oDTODiningSubCategory.Title = oDbDataReader["Title"] != DBNull.Value ? Convert.ToString(oDbDataReader["Title"]) : oDTODiningSubCategory.Title;
                oDTODiningSubCategory.Description = oDbDataReader["Description"] != DBNull.Value ? Convert.ToString(oDbDataReader["Description"]) : oDTODiningSubCategory.Description;
                lst.Add(oDTODiningSubCategory);
            }
            return lst;
        }
        #endregion

        #region Dining
        public List<DTODining> GetDinings(QueryParamList pParam, ref string pErrString)
        {
            string query = "SELECT Id, SubCategoryId, Title, Description, Photo, Address, Telephone, Latitude, Longitude FROM Dining";
            AddWhereClause(ref query, pParam);
            return ExecuteDBQuery(query, pParam, PopulateDinings);
        }
        private List<DTODining> PopulateDinings(DbDataReader oDbDataReader)
        {
            List<DTODining> lst = new List<DTODining>();
            while (oDbDataReader.Read())
            {
                DTODining oDTODining = new DTODining();
                oDTODining.Id = oDbDataReader["Id"] != DBNull.Value ? Convert.ToInt32(oDbDataReader["Id"]) : oDTODining.Id;
                oDTODining.SubCategoryId = oDbDataReader["SubCategoryId"] != DBNull.Value ? Convert.ToInt32(oDbDataReader["SubCategoryId"]) : oDTODining.SubCategoryId;
                oDTODining.Title = oDbDataReader["Title"] != DBNull.Value ? Convert.ToString(oDbDataReader["Title"]) : oDTODining.Title;
                oDTODining.Description = oDbDataReader["Description"] != DBNull.Value ? Convert.ToString(oDbDataReader["Description"]) : oDTODining.Description;
                oDTODining.Photo = oDbDataReader["Photo"] != DBNull.Value ? (Byte[])(oDbDataReader["Photo"]) : oDTODining.Photo;
                oDTODining.Address = oDbDataReader["Address"] != DBNull.Value ? Convert.ToString(oDbDataReader["Address"]) : oDTODining.Address;
                oDTODining.Telephone = oDbDataReader["Telephone"] != DBNull.Value ? Convert.ToString(oDbDataReader["Telephone"]) : oDTODining.Telephone;
                oDTODining.Latitude = oDbDataReader["Latitude"] != DBNull.Value ? Convert.ToDouble(oDbDataReader["Latitude"]) : oDTODining.Latitude;
                oDTODining.Longitude = oDbDataReader["Longitude"] != DBNull.Value ? Convert.ToDouble(oDbDataReader["Longitude"]) : oDTODining.Longitude;
                lst.Add(oDTODining);
            }
            return lst;
        }
        #endregion

        #region Dining Menu
        public List<DTODiningMenu> GetDiningMenus(QueryParamList pParam, ref string pErrString)
        {
            string query = "SELECT Id, DiningId, Photo, FileName FROM DiningMenu";
            AddWhereClause(ref query, pParam);
            return ExecuteDBQuery(query, pParam, PopulateDiningMenus);
        }
        private List<DTODiningMenu> PopulateDiningMenus(DbDataReader oDbDataReader)
        {
            List<DTODiningMenu> lst = new List<DTODiningMenu>();
            while (oDbDataReader.Read())
            {
                DTODiningMenu oDTODiningMenu = new DTODiningMenu();
                oDTODiningMenu.Id = oDbDataReader["Id"] != DBNull.Value ? Convert.ToInt32(oDbDataReader["Id"]) : oDTODiningMenu.Id;
                oDTODiningMenu.DiningId = oDbDataReader["DiningId"] != DBNull.Value ? Convert.ToInt32(oDbDataReader["DiningId"]) : oDTODiningMenu.DiningId;
                oDTODiningMenu.Photo = oDbDataReader["Photo"] != DBNull.Value ? (Byte[])(oDbDataReader["Photo"]) : oDTODiningMenu.Photo;
                oDTODiningMenu.FileName = oDbDataReader["FileName"] != DBNull.Value ? Convert.ToString(oDbDataReader["FileName"]) : oDTODiningMenu.FileName;
                lst.Add(oDTODiningMenu);
            }
            return lst;
        }
        public bool SaveDining(QueryParamList pParam, string spName, ref string pErrString, List<DTODiningMenu> menuList)
        {
            Database db = GetSQLDatabase();
            DbConnection connection = db.CreateConnection();
            DbTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                DbCommand cmd = db.GetStoredProcCommand(spName);

                int id = DBExecStoredProcInTranReturnsIdentity(db, cmd, pParam, transaction);
                if (id > 0)
                {
                    foreach (DTODiningMenu menu in menuList)
                    {
                        menu.DiningId = id;
                    }
                }
                foreach (DTODiningMenu menu in menuList)
                {
                    QueryParamList param = new QueryParamList();
                    param.Add(new QueryParamObj() { ParamName = "DiningId", DBType = DbType.Int32, ParamValue = menu.DiningId });
                    param.Add(new QueryParamObj() { ParamName = "Photo", DBType = DbType.Binary, ParamValue = menu.Photo });
                    param.Add(new QueryParamObj() { ParamName = "FileName", DBType = DbType.String, ParamValue = menu.FileName });
                    cmd = db.GetStoredProcCommand("INSERTDiningMenu");
                    DBExecStoredProcInTranReturnsIdentity(db, cmd, param, transaction);
                }

                transaction.Commit();
            }
            catch (Exception exp)
            {
                transaction.Rollback();
                pErrString = exp.Message;
                LoggingUtility.WriteLog(exp);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        #endregion

        #region Point Of Interest
        public List<DTOPointOfInterest> GetPointOfInterests(QueryParamList pParam, ref string pErrString)
        {
            string query = "SELECT Id, Title, Description, Photo, Address, Phone, Latitude, Longitude FROM PointOfInterest";
            AddWhereClause(ref query, pParam);
            return ExecuteDBQuery(query, pParam, PopulatePointOfInterests);
        }
        private List<DTOPointOfInterest> PopulatePointOfInterests(DbDataReader oDbDataReader)
        {
            List<DTOPointOfInterest> lst = new List<DTOPointOfInterest>();
            while (oDbDataReader.Read())
            {
                DTOPointOfInterest oDTOPointOfInterest = new DTOPointOfInterest();
                oDTOPointOfInterest.Id = oDbDataReader["Id"] != DBNull.Value ? Convert.ToInt32(oDbDataReader["Id"]) : oDTOPointOfInterest.Id;
                oDTOPointOfInterest.Title = oDbDataReader["Title"] != DBNull.Value ? Convert.ToString(oDbDataReader["Title"]) : oDTOPointOfInterest.Title;
                oDTOPointOfInterest.Description = oDbDataReader["Description"] != DBNull.Value ? Convert.ToString(oDbDataReader["Description"]) : oDTOPointOfInterest.Description;
                oDTOPointOfInterest.Photo = oDbDataReader["Photo"] != DBNull.Value ? (Byte[])(oDbDataReader["Photo"]) : oDTOPointOfInterest.Photo;
                oDTOPointOfInterest.Address = oDbDataReader["Address"] != DBNull.Value ? Convert.ToString(oDbDataReader["Address"]) : oDTOPointOfInterest.Address;
                oDTOPointOfInterest.Phone = oDbDataReader["Phone"] != DBNull.Value ? Convert.ToString(oDbDataReader["Phone"]) : oDTOPointOfInterest.Phone;
                oDTOPointOfInterest.Latitude = oDbDataReader["Latitude"] != DBNull.Value ? Convert.ToDouble(oDbDataReader["Latitude"]) : oDTOPointOfInterest.Latitude;
                oDTOPointOfInterest.Longitude = oDbDataReader["Longitude"] != DBNull.Value ? Convert.ToDouble(oDbDataReader["Longitude"]) : oDTOPointOfInterest.Longitude;
                lst.Add(oDTOPointOfInterest);
            }
            return lst;
        }
        #endregion

        #region ATM
        public List<DTOATM> GetATMs(QueryParamList pParam, ref string pErrString)
        {
            string query = "SELECT Id, Title, Description, Photo, Address, Phone, Latitude, Longitude FROM ATM";
            AddWhereClause(ref query, pParam);
            return ExecuteDBQuery(query, pParam, PopulateATMs);
        }
        private List<DTOATM> PopulateATMs(DbDataReader oDbDataReader)
        {
            List<DTOATM> lst = new List<DTOATM>();
            while (oDbDataReader.Read())
            {
                DTOATM oDTOATM = new DTOATM();
                oDTOATM.Id = oDbDataReader["Id"] != DBNull.Value ? Convert.ToInt32(oDbDataReader["Id"]) : oDTOATM.Id;
                oDTOATM.Title = oDbDataReader["Title"] != DBNull.Value ? Convert.ToString(oDbDataReader["Title"]) : oDTOATM.Title;
                oDTOATM.Description = oDbDataReader["Description"] != DBNull.Value ? Convert.ToString(oDbDataReader["Description"]) : oDTOATM.Description;
                oDTOATM.Photo = oDbDataReader["Photo"] != DBNull.Value ? (Byte[])(oDbDataReader["Photo"]) : oDTOATM.Photo;
                oDTOATM.Address = oDbDataReader["Address"] != DBNull.Value ? Convert.ToString(oDbDataReader["Address"]) : oDTOATM.Address;
                oDTOATM.Phone = oDbDataReader["Phone"] != DBNull.Value ? Convert.ToString(oDbDataReader["Phone"]) : oDTOATM.Phone;
                oDTOATM.Latitude = oDbDataReader["Latitude"] != DBNull.Value ? Convert.ToDouble(oDbDataReader["Latitude"]) : oDTOATM.Latitude;
                oDTOATM.Longitude = oDbDataReader["Longitude"] != DBNull.Value ? Convert.ToDouble(oDbDataReader["Longitude"]) : oDTOATM.Longitude;
                lst.Add(oDTOATM);
            }
            return lst;
        }
        #endregion
    }
}
