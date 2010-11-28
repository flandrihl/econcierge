using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.Business
{
	public class CalendarEventService
	{
		public List<DTOCalendarEvent> GetCalendarEvents()
		{
			string error = string.Empty;
			List<DTOCalendarEvent>calendarevent= Facade.GetCalendarEvent(new QueryParamList(), ref error);
			if (!string.IsNullOrEmpty(error))
			{

			}
			return calendarevent;
		}
		public List<DTOCalendarEvent> GetCalendarEvents(int Id)
		{
			string error = string.Empty;
			QueryParamList param = new QueryParamList();
			param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32 , ParamValue = Id});
			List<DTOCalendarEvent>calendarevent=Facade.GetCalendarEvent(param, ref error);
			if (!string.IsNullOrEmpty(error))
			{

			}
			return calendarevent;
		}
		public bool Save(DTOCalendarEvent oCalendarEvent)
		{
			QueryParamList param = new QueryParamList();
			if(!oCalendarEvent.IsNew)
				param.Add(new QueryParamObj(){ParamName="Id", DBType=DbType.Int32, ParamValue= oCalendarEvent.Id});
			param.Add(new QueryParamObj(){ParamName="CategoryId", DBType=DbType.Int32, ParamValue= oCalendarEvent.CategoryId});
			param.Add(new QueryParamObj(){ParamName="Title", DBType=DbType.String, ParamValue= oCalendarEvent.Title});
			param.Add(new QueryParamObj(){ParamName="Description", DBType=DbType.String, ParamValue= oCalendarEvent.Description});
			param.Add(new QueryParamObj(){ParamName="Photo", DBType=DbType.Binary, ParamValue= oCalendarEvent.Photo});
			param.Add(new QueryParamObj(){ParamName="StartDate", DBType=DbType.DateTime, ParamValue= oCalendarEvent.StartDate});
			param.Add(new QueryParamObj(){ParamName="EndDate", DBType=DbType.DateTime, ParamValue= oCalendarEvent.EndDate});
			param.Add(new QueryParamObj(){ParamName="Location", DBType=DbType.String, ParamValue= oCalendarEvent.Location});
			param.Add(new QueryParamObj(){ParamName="Latitude", DBType=DbType.Double, ParamValue= oCalendarEvent.Latitude});
			param.Add(new QueryParamObj(){ParamName="Longitude", DBType=DbType.Double, ParamValue= oCalendarEvent.Longitude});
			string error = string.Empty;
			string spName = oCalendarEvent.IsNew ? "INSERTCalendarEvent " : "UPDATECalendarEvent";
			bool isSuccess = Facade.SetData(param, spName, ref error);
			return string.IsNullOrEmpty(error) & isSuccess;
		}
		public bool Delete(int Id)
		{
			string error = string.Empty;
			QueryParamList param = new QueryParamList();
			param.Add(new QueryParamObj() { ParamName = "Id", DBType = DbType.Int32 , ParamValue = Id});
			bool isSuccess = Facade.SetData(param, "DELETECalendarEvent",  ref error);
			return string.IsNullOrEmpty(error) & isSuccess;
		}
	}
}
