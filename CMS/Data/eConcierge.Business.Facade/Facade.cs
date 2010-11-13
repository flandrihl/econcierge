using System.Collections.Generic;
using eConcierge.Common;
using eConcierge.ServerDataHandler;

namespace eConcierge.Business
{
    public partial class Facade
    {
        public static bool SetData(QueryParamList pParam, string spName, ref string pErrString)
        {
            return new ServerDatabaseHandler().SetData(pParam, spName, ref pErrString);
        }

        public static bool SetData(List<QueryParamList> pParamList, string spName, ref string pErrString)
        {
            return new ServerDatabaseHandler().SetData(pParamList, spName, ref pErrString);
        }

        //public static List<DTOUser> GetUsers(QueryParamList queryParamList, ref string error)
        //{
        //    return new ServerDatabaseHandler().GetUsers(queryParamList, ref error);
        //}
    }
}
