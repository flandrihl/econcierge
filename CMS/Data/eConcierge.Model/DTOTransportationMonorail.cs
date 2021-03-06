using System;

namespace eConcierge.Model
{
	[Serializable()]
    public class DTOTransportationMonorail : DTOLocationBase
	{
		#region Field & Properties
		private int _Id;

		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		private int _TranportationId;

		public int TranportationId
		{
			get { return _TranportationId; }
			set { _TranportationId = value; }
		}

		private string _Title;

		public string Title
		{
			get { return _Title; }
			set { _Title = value; }
		}

		private string _Description;

		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		private Byte[] _Photo;

		public Byte[] Photo
		{
			get { return _Photo; }
			set { _Photo = value; }
		}

		private string _Address;

		public string Address
		{
			get { return _Address; }
			set { _Address = value; }
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
		public DTOTransportationMonorail()
		{ }

		public DTOTransportationMonorail(int Id,int TranportationId,string Title,string Description,Byte[] Photo,string Address,string Phone,Nullable<Double> Latitude,Nullable<Double> Longitude)
		{
			this.Id = Id;
			this.TranportationId = TranportationId;
			this.Title = Title;
			this.Description = Description;
			this.Photo = Photo;
			this.Address = Address;
			this.Phone = Phone;
			this.Latitude = Latitude;
			this.Longitude = Longitude;
		}

		#endregion
	}
}
