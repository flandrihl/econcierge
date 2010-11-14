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
        public static List<DTOPointOfInterest> GetPointOfInterest(QueryParamList queryParamList, ref string error)
        {
            return new ServerDatabaseHandler().GetPointOfInterests(queryParamList, ref error);
        }

        public static List<DTOATM> GetATM(QueryParamList queryParamList, ref string error)
        {
            return new ServerDatabaseHandler().GetATMs(queryParamList, ref error);
        }

        public static List<DTOCafe> GetCafe(QueryParamList queryParamList, ref string error)
        {
            return new ServerDatabaseHandler().GetCafes(queryParamList, ref error);
        }
        public static List<DTOMall> GetMall(QueryParamList queryParamList, ref string error)
        {
            return new ServerDatabaseHandler().GetMalls(queryParamList, ref error);
        }
    }
}
