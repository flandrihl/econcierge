using System;

namespace eConcierge.Model
{
	[Serializable()]
	public class DTOATM
	{
		#region Field & Properties
		private int _Id;

		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
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

		private Nullable<Double> _Latitude;

		public Nullable<Double> Latitude
		{
			get { return _Latitude; }
			set { _Latitude = value; }
		}

		private Nullable<Double> _Longitude;

		public Nullable<Double> Longitude
		{
			get { return _Longitude; }
			set { _Longitude = value; }
		}

			public bool IsNew { get; set; }
		#endregion

		#region Constructors
		public DTOATM()
		{ }

		public DTOATM(int Id,string Title,string Description,Byte[] Photo,string Address,string Phone,Nullable<Double> Latitude,Nullable<Double> Longitude)
		{
			this.Id = Id;
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
