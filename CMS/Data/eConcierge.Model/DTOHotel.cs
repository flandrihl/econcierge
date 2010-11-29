using System;

namespace eConcierge.Model
{
    [Serializable()]
	public class DTOHotel : DTOLocationBase
    {
		#region Field & Properties
		private int _Id;

		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		private string _HotelName;

		public string HotelName
		{
			get { return _HotelName; }
			set { _HotelName = value; }
		}

		private string _Description;

		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
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
		public DTOHotel()
		{ }

        public DTOHotel(int id, string hotelName, string description, string address, string phone, double? latitude, double? longitude)
		{
			this.Id = id;
			this.HotelName = HotelName;
			this.Description = description;
			this.Address = address;
			this.Phone = phone;
			this.Latitude = latitude;
			this.Longitude = longitude;
		}

		#endregion
	}
}
