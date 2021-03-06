﻿using System;
using System.Collections.Generic;
using eConcierge.Common;
using eConcierge.Model;
using eConcierge.ServerDataHandler;

namespace eConcierge.Business.Facade
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
        public static List<DTODiningMenu> GetDiningMenu(QueryParamList queryParamList, ref string error)
        {
            return new ServerDatabaseHandler().GetDiningMenus(queryParamList, ref error);
        }

        public static bool SaveDining(QueryParamList pParam, string spName, ref string pErrString, List<DTODiningMenu> menuList)
        {
            return new ServerDatabaseHandler().SaveDining(pParam, spName, ref pErrString, menuList);
        }
    }
}
