using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.Business
{
    public class ATMService
    {
        public List<DTOATM> GetATMs()
        {
            string error = string.Empty;
            List<DTOATM> atm = Facade.GetATM(new QueryParamList(), ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return atm;
        }
        public List<DTOATM> GetATMs(int Id)
        {
            string error = string.Empty;
            QueryParamList param = new QueryParamList();
            param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = Id });
            List<DTOATM> atm = Facade.GetATM(param, ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return atm;
        }
        public bool Save(DTOATM oATM)
        {
            QueryParamList param = new QueryParamList();
            if (!oATM.IsNew)
                param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = oATM.Id });
            param.Add(new QueryParamObj() { ParamName = "Title", DBType = DbType.String, ParamValue = oATM.Title });
            param.Add(new QueryParamObj() { ParamName = "Description", DBType = DbType.String, ParamValue = oATM.Description });
            param.Add(new QueryParamObj() { ParamName = "Photo", DBType = DbType.Binary, ParamValue = oATM.Photo });
            param.Add(new QueryParamObj() { ParamName = "Address", DBType = DbType.String, ParamValue = oATM.Address });
            param.Add(new QueryParamObj() { ParamName = "Phone", DBType = DbType.String, ParamValue = oATM.Phone });
            param.Add(new QueryParamObj() { ParamName = "Latitude", DBType = DbType.Double, ParamValue = oATM.Latitude });
            param.Add(new QueryParamObj() { ParamName = "Longitude", DBType = DbType.Double, ParamValue = oATM.Longitude });
            string error = string.Empty;
            string spName = oATM.IsNew ? "INSERTATM " : "UPDATEATM";
            bool isSuccess = Facade.SetData(param, spName, ref error);
            return string.IsNullOrEmpty(error) & isSuccess;
        }
        public bool Delete(int Id)
        {
            string error = string.Empty;
            QueryParamList param = new QueryParamList();
            param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = Id });
            bool isSuccess = Facade.SetData(param, "DELETEATM", ref error);
            return string.IsNullOrEmpty(error) & isSuccess;
        }
    }
}
