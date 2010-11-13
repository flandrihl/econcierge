using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eConcierge.Common;
using eConcierge.Model;
using eConcierge.ServerDataHandler;

namespace eConcierge.Business
{
    public partial class Facade
    {
        public static List<DTODiningCategory> GetDiningCategory(QueryParamList queryParamList, ref string error)
        {
            return new ServerDatabaseHandler().GetDiningCategorys(queryParamList, ref error);
        }

        public static List<DTODiningSubCategory> GetDiningSubCategory(QueryParamList queryParamList, ref string error)
        {
            return new ServerDatabaseHandler().GetDiningSubCategorys(queryParamList, ref error);
        }

        public static List<DTODining> GetDining(QueryParamList queryParamList, ref string error)
        {
            return new ServerDatabaseHandler().GetDinings(queryParamList, ref error);
        }

    }
}
