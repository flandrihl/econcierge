using System;

namespace eConcierge.Model
{
	[Serializable()]
	public class DTOTransportationTaxi
	{
		#region Field & Properties
		private int _Id;

		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		private int _TranspotationId;

		public int TranspotationId
		{
			get { return _TranspotationId; }
			set { _TranspotationId = value; }
		}

		private string _Title;

		public string Title
		{
			get { return _Title; }
			set { _Title = value; }
		}

		private string _Phone;

		public string Phone
		{
			get { return _Phone; }
			set { _Phone = value; }
		}

			public bool IsNew { get; set; }
		#endregion

		#region Constructors
		public DTOTransportationTaxi()
		{ }

		public DTOTransportationTaxi(int Id,int TranspotationId,string Title,string Phone)
		{
			this.Id = Id;
			this.TranspotationId = TranspotationId;
			this.Title = Title;
			this.Phone = Phone;
		}

		#endregion
	}
}
