using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.Business
{
    public class DiningCategoryService
    {
        public List<DTODiningCategory> GetDiningCategorys()
        {
            string error = string.Empty;
            List<DTODiningCategory> diningcategory = Facade.GetDiningCategory(new QueryParamList(), ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return diningcategory;
        }
        public List<DTODiningCategory> GetDiningCategorys(int Id)
        {
            string error = string.Empty;
            QueryParamList param = new QueryParamList();
            param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = Id });
            List<DTODiningCategory> diningcategory = Facade.GetDiningCategory(param, ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return diningcategory;
        }
        public bool Save(DTODiningCategory oDiningCategory)
        {
            QueryParamList param = new QueryParamList();
            if (!oDiningCategory.IsNew)
                param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = oDiningCategory.Id });
            param.Add(new QueryParamObj() { ParamName = "Title", DBType = DbType.String, ParamValue = oDiningCategory.Title });
            param.Add(new QueryParamObj() { ParamName = "Description", DBType = DbType.String, ParamValue = oDiningCategory.Description });
            string error = string.Empty;
            string spName = oDiningCategory.IsNew ? "INSERTDiningCategory " : "UPDATEDiningCategory";
            bool isSuccess = Facade.SetData(param, spName, ref error);
            return string.IsNullOrEmpty(error) & isSuccess;
        }
        public bool Delete(int Id)
        {
            string error = string.Empty;
            QueryParamList param = new QueryParamList();
            param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = Id });
            bool isSuccess = Facade.SetData(param, "DELETEDiningCategory", ref error);
            return string.IsNullOrEmpty(error) & isSuccess;
        }
    }
}
