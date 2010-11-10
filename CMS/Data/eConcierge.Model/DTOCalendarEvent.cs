using System;

namespace eConcierge.Model
{
	[Serializable()]
	public class DTOCalendarEvent
	{
		#region Field & Properties
		private int _Id;

		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		private int _CategoryId;

		public int CategoryId
		{
			get { return _CategoryId; }
			set { _CategoryId = value; }
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

		private Nullable<DateTime> _StartDate;

		public Nullable<DateTime> StartDate
		{
			get { return _StartDate; }
			set { _StartDate = value; }
		}

		private Nullable<DateTime> _EndDate;

		public Nullable<DateTime> EndDate
		{
			get { return _EndDate; }
			set { _EndDate = value; }
		}

		private string _Location;

		public string Location
		{
			get { return _Location; }
			set { _Location = value; }
		}

		private Nullable<Double> _Latitude;

		public Nullable<Double> Latitude
		{
			get { return _Latitude; }
			set { _Latitude = value; }
		}

		private double _Longitude;

		public double Longitude
		{
			get { return _Longitude; }
			set { _Longitude = value; }
		}

			public bool IsNew { get; set; }
		#endregion

		#region Constructors
		public DTOCalendarEvent()
		{ }

		public DTOCalendarEvent(int Id,int CategoryId,string Title,string Description,Byte[] Photo,Nullable<DateTime> StartDate,Nullable<DateTime> EndDate,string Location,Nullable<Double> Latitude,double Longitude)
		{
			this.Id = Id;
			this.CategoryId = CategoryId;
			this.Title = Title;
			this.Description = Description;
			this.Photo = Photo;
			this.StartDate = StartDate;
			this.EndDate = EndDate;
			this.Location = Location;
			this.Latitude = Latitude;
			this.Longitude = Longitude;
		}

		#endregion
	}
}
