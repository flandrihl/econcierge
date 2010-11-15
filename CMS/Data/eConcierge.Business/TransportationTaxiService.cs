using System.Collections.Generic;
using System.Data;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.Business
{
	public class TransportationTaxiService
	{
		public TransportationTaxiService()
		{
		}
		public List<DTOTransportationTaxi> GetTransportationTaxis()
		{
			string error = string.Empty;
			List<DTOTransportationTaxi>transportationtaxi= Facade.GetTransportationTaxi(new QueryParamList(), ref error);
			if (!string.IsNullOrEmpty(error))
			{

			}
			return transportationtaxi;
		}
		public List<DTOTransportationTaxi> GetTransportationTaxis(int Id)
		{
			string error = string.Empty;
			QueryParamList param = new QueryParamList();
			param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32 , ParamValue = Id});
			List<DTOTransportationTaxi>transportationtaxi= Facade.GetTransportationTaxi(param, ref error);
			if (!string.IsNullOrEmpty(error))
			{

			}
			return transportationtaxi;
		}
		public bool Save(DTOTransportationTaxi oTransportationTaxi)
		{
			QueryParamList param = new QueryParamList();
			if(!oTransportationTaxi.IsNew)
				param.Add(new QueryParamObj(){ParamName="Id", DBType=DbType.Int32, ParamValue= oTransportationTaxi.Id});
			param.Add(new QueryParamObj(){ParamName="TranspotationId", DBType=DbType.Int32, ParamValue= oTransportationTaxi.TranspotationId});
			param.Add(new QueryParamObj(){ParamName="Title", DBType=DbType.String, ParamValue= oTransportationTaxi.Title});
			param.Add(new QueryParamObj(){ParamName="Phone", DBType=DbType.String, ParamValue= oTransportationTaxi.Phone});
			string error = string.Empty;
			string spName = oTransportationTaxi.IsNew ? "INSERTTransportationTaxi " : "UPDATETransportationTaxi";
			bool isSuccess = Facade.SetData(param, spName, ref error);
			return string.IsNullOrEmpty(error) & isSuccess;
		}
		public bool Delete(int Id)
		{
			string error = string.Empty;
			QueryParamList param = new QueryParamList();
			param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32 , ParamValue = Id});
			bool isSuccess = Facade.SetData(param, "DELETETransportationTaxi",  ref error);
			return string.IsNullOrEmpty(error) & isSuccess;
		}
	}
}
