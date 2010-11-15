using System.Collections.Generic;
using System.Data;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.Business
{
	public class CafeService
	{
		public CafeService()
		{
		}
		public List<DTOCafe> GetCafes()
		{
			string error = string.Empty;
			List<DTOCafe>cafe= Facade.GetCafe(new QueryParamList(), ref error);
			if (!string.IsNullOrEmpty(error))
			{

			}
			return cafe;
		}
		public List<DTOCafe> GetCafes(int Id)
		{
			string error = string.Empty;
			QueryParamList param = new QueryParamList();
			param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32 , ParamValue = Id});
			List<DTOCafe>cafe= Facade.GetCafe(param, ref error);
			if (!string.IsNullOrEmpty(error))
			{

			}
			return cafe;
		}
		public bool Save(DTOCafe oCafe)
		{
			QueryParamList param = new QueryParamList();
			if(!oCafe.IsNew)
				param.Add(new QueryParamObj(){ParamName="Id", DBType=DbType.Int32, ParamValue= oCafe.Id});
			param.Add(new QueryParamObj(){ParamName="Title", DBType=DbType.String, ParamValue= oCafe.Title});
			param.Add(new QueryParamObj(){ParamName="Description", DBType=DbType.String, ParamValue= oCafe.Description});
			param.Add(new QueryParamObj(){ParamName="Photo", DBType=DbType.Binary, ParamValue= oCafe.Photo});
			param.Add(new QueryParamObj(){ParamName="Address", DBType=DbType.String, ParamValue= oCafe.Address});
			param.Add(new QueryParamObj(){ParamName="Phone", DBType=DbType.String, ParamValue= oCafe.Phone});
			param.Add(new QueryParamObj(){ParamName="Latitude", DBType=DbType.Double, ParamValue= oCafe.Latitude});
			param.Add(new QueryParamObj(){ParamName="Longitude", DBType=DbType.Double, ParamValue= oCafe.Longitude});
			string error = string.Empty;
			string spName = oCafe.IsNew ? "INSERTCafe " : "UPDATECafe";
			bool isSuccess = Facade.SetData(param, spName, ref error);
			return string.IsNullOrEmpty(error) & isSuccess;
		}
		public bool Delete(int Id)
		{
			string error = string.Empty;
			QueryParamList param = new QueryParamList();
			param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32 , ParamValue = Id});
			bool isSuccess = Facade.SetData(param, "DELETECafe",  ref error);
			return string.IsNullOrEmpty(error) & isSuccess;
		}
	}
}
