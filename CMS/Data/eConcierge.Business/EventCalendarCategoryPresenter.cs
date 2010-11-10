using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.Business
{
    [Export(typeof(EventCalendarCategoryService))]
	public class EventCalendarCategoryService
	{
		
		public List<DTOEventCalendarCategory> GetEventCalendarCategorys()
		{
			string error = string.Empty;
			List<DTOEventCalendarCategory>eventcalendarcategory= Facade.Facade.GetEventCalendarCategory(new QueryParamList(), ref error);
			if (!string.IsNullOrEmpty(error))
			{

			}
			return eventcalendarcategory;
		}
		public List<DTOEventCalendarCategory> GetEventCalendarCategorys(int Id)
		{
			string error = string.Empty;
			QueryParamList param = new QueryParamList();
			param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32 , ParamValue = Id});
			List<DTOEventCalendarCategory>eventcalendarcategory= Facade.Facade.GetEventCalendarCategory(param, ref error);
			if (!string.IsNullOrEmpty(error))
			{

			}
			return eventcalendarcategory;
		}
		public bool Save(DTOEventCalendarCategory oEventCalendarCategory)
		{
			QueryParamList param = new QueryParamList();
			if(!oEventCalendarCategory.IsNew)
				param.Add(new QueryParamObj(){ParamName="Id", DBType=DbType.Int32, ParamValue= oEventCalendarCategory.Id});
			param.Add(new QueryParamObj(){ParamName="Name", DBType=DbType.String, ParamValue= oEventCalendarCategory.Name});
			param.Add(new QueryParamObj(){ParamName="Description", DBType=DbType.String, ParamValue= oEventCalendarCategory.Description});
			string error = string.Empty;
			string spName = oEventCalendarCategory.IsNew ? "INSERTEventCalendarCategory " : "UPDATEEventCalendarCategory";
			bool isSuccess = Facade.Facade.SetData(param, spName, ref error);
			return string.IsNullOrEmpty(error) & isSuccess;
		}
		public bool Delete(int Id)
		{
			string error = string.Empty;
			QueryParamList param = new QueryParamList();
			param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32 , ParamValue = Id});
			bool isSuccess = Facade.Facade.SetData(param, "DELETEEventCalendarCategory",  ref error);
			return string.IsNullOrEmpty(error) & isSuccess;
		}
	}
}
