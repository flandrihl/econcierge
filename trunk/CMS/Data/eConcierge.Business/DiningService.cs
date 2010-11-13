using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.Business
{
    public class DiningService
    {
        public List<DTODining> GetDinings()
        {
            string error = string.Empty;
            List<DTODining> dining = Facade.GetDining(new QueryParamList(), ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return dining;
        }
        public List<DTODining> GetDinings(int Id)
        {
            string error = string.Empty;
            QueryParamList param = new QueryParamList();
            param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = Id });
            List<DTODining> dining = Facade.GetDining(param, ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return dining;
        }
        public bool Save(DTODining oDining)
        {
            QueryParamList param = new QueryParamList();
            if (!oDining.IsNew)
                param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = oDining.Id });
            param.Add(new QueryParamObj() { ParamName = "SubCategoryId", DBType = DbType.Int32, ParamValue = oDining.SubCategoryId });
            param.Add(new QueryParamObj() { ParamName = "Title", DBType = DbType.String, ParamValue = oDining.Title });
            param.Add(new QueryParamObj() { ParamName = "Description", DBType = DbType.String, ParamValue = oDining.Description });
            param.Add(new QueryParamObj() { ParamName = "Photo", DBType = DbType.Binary, ParamValue = oDining.Photo });
            param.Add(new QueryParamObj() { ParamName = "Address", DBType = DbType.String, ParamValue = oDining.Address });
            param.Add(new QueryParamObj() { ParamName = "Telephone", DBType = DbType.String, ParamValue = oDining.Telephone });
            param.Add(new QueryParamObj() { ParamName = "Latitude", DBType = DbType.Double, ParamValue = oDining.Latitude });
            param.Add(new QueryParamObj() { ParamName = "Longitude", DBType = DbType.Double, ParamValue = oDining.Longitude });
            string error = string.Empty;
            string spName = oDining.IsNew ? "INSERTDining " : "UPDATEDining";
            bool isSuccess = Facade.SetData(param, spName, ref error);
            return string.IsNullOrEmpty(error) & isSuccess;
        }
        public bool Delete(int Id)
        {
            string error = string.Empty;
            QueryParamList param = new QueryParamList();
            param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = Id });
            bool isSuccess = Facade.SetData(param, "DELETEDining", ref error);
            return string.IsNullOrEmpty(error) & isSuccess;
        }
    }
}
