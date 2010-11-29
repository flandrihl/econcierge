using System.Collections.Generic;
using System.Data;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.Business
{
	public class MallService
	{
		public MallService()
		{
		}
		public List<DTOMall> GetMalls()
		{
			string error = string.Empty;
			List<DTOMall>mall= Facade.Facade.GetMall(new QueryParamList(), ref error);
			if (!string.IsNullOrEmpty(error))
			{

			}
			return mall;
		}
		public List<DTOMall> GetMalls(int Id)
		{
			string error = string.Empty;
			QueryParamList param = new QueryParamList();
			param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32 , ParamValue = Id});
			List<DTOMall>mall= Facade.Facade.GetMall(param, ref error);
			if (!string.IsNullOrEmpty(error))
			{

			}
			return mall;
		}
		public bool Save(DTOMall oMall)
		{
			QueryParamList param = new QueryParamList();
			if(!oMall.IsNew)
				param.Add(new QueryParamObj(){ParamName="Id", DBType=DbType.Int32, ParamValue= oMall.Id});
			param.Add(new QueryParamObj(){ParamName="Title", DBType=DbType.String, ParamValue= oMall.Title});
			param.Add(new QueryParamObj(){ParamName="Description", DBType=DbType.String, ParamValue= oMall.Description});
			param.Add(new QueryParamObj(){ParamName="Photo", DBType=DbType.Binary, ParamValue= oMall.Photo});
			param.Add(new QueryParamObj(){ParamName="Address", DBType=DbType.String, ParamValue= oMall.Address});
			param.Add(new QueryParamObj(){ParamName="Phone", DBType=DbType.String, ParamValue= oMall.Phone});
			param.Add(new QueryParamObj(){ParamName="Latitude", DBType=DbType.Double, ParamValue= oMall.Latitude});
			param.Add(new QueryParamObj(){ParamName="Longitude", DBType=DbType.Double, ParamValue= oMall.Longitude});
			string error = string.Empty;
			string spName = oMall.IsNew ? "INSERTMall " : "UPDATEMall";
			bool isSuccess = Facade.Facade.SetData(param, spName, ref error);
			return string.IsNullOrEmpty(error) & isSuccess;
		}
		public bool Delete(int Id)
		{
			string error = string.Empty;
			QueryParamList param = new QueryParamList();
			param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32 , ParamValue = Id});
			bool isSuccess = Facade.Facade.SetData(param, "DELETEMall",  ref error);
			return string.IsNullOrEmpty(error) & isSuccess;
		}
	}
}
