using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.Business
{
    public class DiningMenuService
    {
        public List<DTODiningMenu> GetDiningMenus()
        {
            string error = string.Empty;
            List<DTODiningMenu> diningmenu = Facade.GetDiningMenu(new QueryParamList(), ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return diningmenu;
        }
        public List<DTODiningMenu> GetDiningMenus(int Id)
        {
            string error = string.Empty;
            QueryParamList param = new QueryParamList();
            param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = Id });
            List<DTODiningMenu> diningmenu = Facade.GetDiningMenu(param, ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return diningmenu;
        }

        public List<DTODiningMenu> GetDiningMenusByDining(int diningId)
        {
            string error = string.Empty;
            QueryParamList param = new QueryParamList();
            param.Add(new QueryParamObj() { ParamName = "DiningId", DBType = DbType.Int32, ParamValue = diningId });
            List<DTODiningMenu> diningmenu = Facade.GetDiningMenu(param, ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return diningmenu;
        }
        public bool Save(DTODiningMenu oDiningMenu)
        {
            QueryParamList param = new QueryParamList();
            if (!oDiningMenu.IsNew)
                param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = oDiningMenu.Id });
            param.Add(new QueryParamObj() { ParamName = "DiningId", DBType = DbType.Int32, ParamValue = oDiningMenu.DiningId });
            param.Add(new QueryParamObj() { ParamName = "Photo", DBType = DbType.Binary, ParamValue = oDiningMenu.Photo });
            param.Add(new QueryParamObj() { ParamName = "FileName", DBType = DbType.String, ParamValue = oDiningMenu.FileName });
            string error = string.Empty;
            string spName = oDiningMenu.IsNew ? "INSERTDiningMenu " : "UPDATEDiningMenu";
            bool isSuccess = Facade.SetData(param, spName, ref error);
            return string.IsNullOrEmpty(error) & isSuccess;
        }
        public bool Delete(int Id)
        {
            string error = string.Empty;
            QueryParamList param = new QueryParamList();
            param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = Id });
            bool isSuccess = Facade.SetData(param, "DELETEDiningMenu", ref error);
            return string.IsNullOrEmpty(error) & isSuccess;
        }
    }
}
