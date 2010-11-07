using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eConcierge.Common;
using eConcierge.Model;
using eConcierge.ServerDataHandler;

namespace eConcierge.Business.Facade
{
    public partial class Facade
    {
        public static List<DTOEventCalendarCategory> GetEventCalendarCategory(QueryParamList queryParamList, ref string error)
        {
            return new ServerDatabaseHandler().GetEventCalendarCategorys(queryParamList, ref error);
        }
    }
}
