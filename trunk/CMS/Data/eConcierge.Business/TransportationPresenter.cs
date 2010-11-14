using System.Collections.Generic;
using System.Data;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.Business
{
	public class TransportationPresenter
	{
		public TransportationPresenter()
		{
		}
		public List<DTOTransportation> GetTransportations()
		{
			string error = string.Empty;
			List<DTOTransportation>transportation= Facade.GetTransportation(new QueryParamList(), ref error);
			if (!string.IsNullOrEmpty(error))
			{

			}
			return transportation;
		}
		public List<DTOTransportation> GetTransportations(int Id)
		{
			string error = string.Empty;
			QueryParamList param = new QueryParamList();
			param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32 , ParamValue = Id});
			List<DTOTransportation>transportation= Facade.GetTransportation(param, ref error);
			if (!string.IsNullOrEmpty(error))
			{

			}
			return transportation;
		}
		public bool Save(DTOTransportation oTransportation)
		{
			QueryParamList param = new QueryParamList();
			if(!oTransportation.IsNew)
				param.Add(new QueryParamObj(){ParamName="Id", DBType=DbType.Int32, ParamValue= oTransportation.Id});
			param.Add(new QueryParamObj(){ParamName="Title", DBType=DbType.String, ParamValue= oTransportation.Title});
			param.Add(new QueryParamObj(){ParamName="Description", DBType=DbType.String, ParamValue= oTransportation.Description});
			param.Add(new QueryParamObj(){ParamName="TransportationType", DBType=DbType.Int32, ParamValue= oTransportation.TransportationType});
			string error = string.Empty;
			string spName = oTransportation.IsNew ? "INSERTTransportation " : "UPDATETransportation";
			bool isSuccess = Facade.SetData(param, spName, ref error);
			return string.IsNullOrEmpty(error) & isSuccess;
		}
		public bool Delete(int Id)
		{
			string error = string.Empty;
			QueryParamList param = new QueryParamList();
			param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32 , ParamValue = Id});
			bool isSuccess = Facade.SetData(param, "DELETETransportation",  ref error);
			return string.IsNullOrEmpty(error) & isSuccess;
		}
	}
}
