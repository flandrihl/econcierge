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
            List<DTODining> dining = Facade.Facade.GetDining(new QueryParamList(), ref error);
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
            List<DTODining> dining = Facade.Facade.GetDining(param, ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return dining;
        }
        public bool Save(DTODining oDining, List<DTODiningMenu> menuList)
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
            bool isSuccess = Facade.Facade.SaveDining(param, spName, ref error, menuList);
            return string.IsNullOrEmpty(error) & isSuccess;
        }
        public bool Delete(int Id)
        {
            string error = string.Empty;
            QueryParamList param = new QueryParamList();
            param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = Id });
            bool isSuccess = Facade.Facade.SetData(param, "DELETEDining", ref error);
            return string.IsNullOrEmpty(error) & isSuccess;
        }

        public List<DTODiningMenu> GetDiningMenu(int diningId)
        {
            string error = string.Empty;
            var param = new QueryParamList();
            param.Add(new QueryParamObj() { ParamName = "DiningId", DBType = DbType.Int32, ParamValue = diningId });
            List<DTODiningMenu> diningMenuBook = Facade.Facade.GetDiningMenu(param, ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return diningMenuBook;
        }
    }
}
