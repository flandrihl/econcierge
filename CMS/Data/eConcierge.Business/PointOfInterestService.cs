using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.Business
{
    public class PointOfInterestService
    {
        public List<DTOPointOfInterest> GetPointOfInterests()
        {
            string error = string.Empty;
            List<DTOPointOfInterest> pointofinterest = Facade.GetPointOfInterest(new QueryParamList(), ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return pointofinterest;
        }
        public List<DTOPointOfInterest> GetPointOfInterests(int Id)
        {
            string error = string.Empty;
            QueryParamList param = new QueryParamList();
            param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = Id });
            List<DTOPointOfInterest> pointofinterest = Facade.GetPointOfInterest(param, ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return pointofinterest;
        }
        public bool Save(DTOPointOfInterest oPointOfInterest)
        {
            QueryParamList param = new QueryParamList();
            if (!oPointOfInterest.IsNew)
                param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = oPointOfInterest.Id });
            param.Add(new QueryParamObj() { ParamName = "Title", DBType = DbType.String, ParamValue = oPointOfInterest.Title });
            param.Add(new QueryParamObj() { ParamName = "Description", DBType = DbType.String, ParamValue = oPointOfInterest.Description });
            param.Add(new QueryParamObj() { ParamName = "Photo", DBType = DbType.Binary, ParamValue = oPointOfInterest.Photo });
            param.Add(new QueryParamObj() { ParamName = "Address", DBType = DbType.String, ParamValue = oPointOfInterest.Address });
            param.Add(new QueryParamObj() { ParamName = "Phone", DBType = DbType.String, ParamValue = oPointOfInterest.Phone });
            param.Add(new QueryParamObj() { ParamName = "Latitude", DBType = DbType.Double, ParamValue = oPointOfInterest.Latitude });
            param.Add(new QueryParamObj() { ParamName = "Longitude", DBType = DbType.Double, ParamValue = oPointOfInterest.Longitude });
            string error = string.Empty;
            string spName = oPointOfInterest.IsNew ? "INSERTPointOfInterest " : "UPDATEPointOfInterest";
            bool isSuccess = Facade.SetData(param, spName, ref error);
            return string.IsNullOrEmpty(error) & isSuccess;
        }
        public bool Delete(int Id)
        {
            string error = string.Empty;
            QueryParamList param = new QueryParamList();
            param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = Id });
            bool isSuccess = Facade.SetData(param, "DELETEPointOfInterest", ref error);
            return string.IsNullOrEmpty(error) & isSuccess;
        }
    }
}
