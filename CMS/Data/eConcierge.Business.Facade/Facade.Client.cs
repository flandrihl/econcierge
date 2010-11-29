using eConcierge.Common;
using eConcierge.Model;
using eConcierge.ServerDataHandler;

namespace eConcierge.Business.Facade
{
    public partial class Facade
    {
        public static DTOHotel GetHotelDetails(QueryParamList queryParamList, ref string error)
        {
            return new ServerDatabaseHandler().GetHotelDetails(queryParamList, ref error);
        }
    }
}
