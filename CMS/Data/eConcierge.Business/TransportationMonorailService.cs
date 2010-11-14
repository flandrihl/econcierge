using System.Collections.Generic;
using System.Data;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.Business
{
	public class TransportationMonorailService
	{
		public TransportationMonorailService()
		{
		}
		public List<DTOTransportationMonorail> GetTransportationMonorails()
		{
			string error = string.Empty;
			List<DTOTransportationMonorail>transportationmonorail= Facade.GetTransportationMonorail(new QueryParamList(), ref error);
			if (!string.IsNullOrEmpty(error))
			{

			}
			return transportationmonorail;
		}
		public List<DTOTransportationMonorail> GetTransportationMonorails(int Id)
		{
			string error = string.Empty;
			QueryParamList param = new QueryParamList();
			param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32 , ParamValue = Id});
			List<DTOTransportationMonorail>transportationmonorail= Facade.GetTransportationMonorail(param, ref error);
			if (!string.IsNullOrEmpty(error))
			{

			}
			return transportationmonorail;
		}
		public bool Save(DTOTransportationMonorail oTransportationMonorail)
		{
			QueryParamList param = new QueryParamList();
			if(!oTransportationMonorail.IsNew)
				param.Add(new QueryParamObj(){ParamName="Id", DBType=DbType.Int32, ParamValue= oTransportationMonorail.Id});
			param.Add(new QueryParamObj(){ParamName="TranportationId", DBType=DbType.Int32, ParamValue= oTransportationMonorail.TranportationId});
			param.Add(new QueryParamObj(){ParamName="Title", DBType=DbType.String, ParamValue= oTransportationMonorail.Title});
			param.Add(new QueryParamObj(){ParamName="Description", DBType=DbType.String, ParamValue= oTransportationMonorail.Description});
			param.Add(new QueryParamObj(){ParamName="Photo", DBType=DbType.Binary, ParamValue= oTransportationMonorail.Photo});
			param.Add(new QueryParamObj(){ParamName="Address", DBType=DbType.String, ParamValue= oTransportationMonorail.Address});
			param.Add(new QueryParamObj(){ParamName="Phone", DBType=DbType.String, ParamValue= oTransportationMonorail.Phone});
			param.Add(new QueryParamObj(){ParamName="Latitude", DBType=DbType.Double, ParamValue= oTransportationMonorail.Latitude});
			param.Add(new QueryParamObj(){ParamName="Longitude", DBType=DbType.Double, ParamValue= oTransportationMonorail.Longitude});
			string error = string.Empty;
			string spName = oTransportationMonorail.IsNew ? "INSERTTransportationMonorail " : "UPDATETransportationMonorail";
			bool isSuccess = Facade.SetData(param, spName, ref error);
			return string.IsNullOrEmpty(error) & isSuccess;
		}
		public bool Delete(int Id)
		{
			string error = string.Empty;
			QueryParamList param = new QueryParamList();
			param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32 , ParamValue = Id});
			bool isSuccess = Facade.SetData(param, "DELETETransportationMonorail",  ref error);
			return string.IsNullOrEmpty(error) & isSuccess;
		}
	}
}
