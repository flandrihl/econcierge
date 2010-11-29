using System.Collections.Generic;
using eConcierge.Common;
using eConcierge.Model;
using eConcierge.ServerDataHandler;

namespace eConcierge.Business.Facade
{
    public partial class Facade
    {
        public static List<DTOTransportation> GetTransportation(QueryParamList queryParamList, ref string error)
        {
            return new ServerDatabaseHandler().GetTransportations(queryParamList, ref error);
        }
        public static List<DTOTransportationMonorail> GetTransportationMonorail(QueryParamList queryParamList, ref string error)
        {
            return new ServerDatabaseHandler().GetTransportationMonorails(queryParamList, ref error);
        }
        public static List<DTOTransportationTaxi> GetTransportationTaxi(QueryParamList queryParamList, ref string error)
        {
            return new ServerDatabaseHandler().GetTransportationTaxis(queryParamList, ref error);
        }
    }
}
