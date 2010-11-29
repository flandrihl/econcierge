using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.Business
{
    public class HotelService
    {
        public DTOHotel GetHotelDetails()
        {
            var error = string.Empty;
            var hotel = Facade.Facade.GetHotelDetails(new QueryParamList(), ref error);
            if (!string.IsNullOrEmpty(error))
            {

            }
            return hotel;
        }

        public bool Save(DTOHotel oHotel)
        {
            var param = new QueryParamList();
            if (!oHotel.IsNew)
                param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32, ParamValue = oHotel.Id });
            param.Add(new QueryParamObj() { ParamName = "HotelName", DBType = DbType.String, ParamValue = oHotel.HotelName });
            param.Add(new QueryParamObj() { ParamName = "Description", DBType = DbType.String, ParamValue = oHotel.Description });
            param.Add(new QueryParamObj() { ParamName = "Address", DBType = DbType.String, ParamValue = oHotel.Address });
            param.Add(new QueryParamObj() { ParamName = "Phone", DBType = DbType.String, ParamValue = oHotel.Phone });
            param.Add(new QueryParamObj() { ParamName = "Latitude", DBType = DbType.Double, ParamValue = oHotel.Latitude });
            param.Add(new QueryParamObj() { ParamName = "Longitude", DBType = DbType.Double, ParamValue = oHotel.Longitude });
            string error = string.Empty;
            string spName = oHotel.IsNew ? "INSERTHOTELDETAILS" : "UPDATEHOTELDETAILS";
            bool isSuccess = Facade.Facade.SetData(param, spName, ref error);
            return string.IsNullOrEmpty(error) & isSuccess;
        }
    }
}
