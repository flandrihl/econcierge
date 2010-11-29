using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.Business
{
    public class DiningSubCategoryService
    {
        public List<DTODiningSubCategory> GetDiningSubCategorys()
        {
            string error = string.Empty;
            List<DTODiningSubCategory> diningsubcategory = Facade.Facade.GetDiningSubCategory(new QueryParamList(), ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return diningsubcategory;
        }
        public List<DTODiningSubCategory> GetDiningSubCategorys(int Id)
        {
            string error = string.Empty;
            QueryParamList param = new QueryParamList();
            param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = Id });
            List<DTODiningSubCategory> diningsubcategory = Facade.Facade.GetDiningSubCategory(param, ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return diningsubcategory;
        }
        public bool Save(DTODiningSubCategory oDiningSubCategory)
        {
            QueryParamList param = new QueryParamList();
            if (!oDiningSubCategory.IsNew)
                param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = oDiningSubCategory.Id });
            param.Add(new QueryParamObj() { ParamName = "CategoryId", DBType = DbType.Int32, ParamValue = oDiningSubCategory.CategoryId });
            param.Add(new QueryParamObj() { ParamName = "Title", DBType = DbType.String, ParamValue = oDiningSubCategory.Title });
            param.Add(new QueryParamObj() { ParamName = "Description", DBType = DbType.String, ParamValue = oDiningSubCategory.Description });
            string error = string.Empty;
            string spName = oDiningSubCategory.IsNew ? "INSERTDiningSubCategory " : "UPDATEDiningSubCategory";
            bool isSuccess = Facade.Facade.SetData(param, spName, ref error);
            return string.IsNullOrEmpty(error) & isSuccess;
        }
        public bool Delete(int Id)
        {
            string error = string.Empty;
            QueryParamList param = new QueryParamList();
            param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = Id });
            bool isSuccess = Facade.Facade.SetData(param, "DELETEDiningSubCategory", ref error);
            return string.IsNullOrEmpty(error) & isSuccess;
        }
    }
}
