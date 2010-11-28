using System;

namespace eConcierge.Model
{
	[Serializable()]
    public class DTODining : DTOLocationBase
	{
		#region Field & Properties
		private int _Id;

		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		private int _SubCategoryId;

		public int SubCategoryId
		{
			get { return _SubCategoryId; }
			set { _SubCategoryId = value; }
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

		private string _Telephone;

		public string Telephone
		{
			get { return _Telephone; }
			set { _Telephone = value; }
		}

		public bool IsNew { get; set; }
		#endregion

		#region Constructors
		public DTODining()
		{ }

		public DTODining(int Id,int SubCategoryId,string Title,string Description,Byte[] Photo,string Address,string Telephone,Nullable<Double> Latitude,Nullable<Double> Longitude)
		{
			this.Id = Id;
			this.SubCategoryId = SubCategoryId;
			this.Title = Title;
			this.Description = Description;
			this.Photo = Photo;
			this.Address = Address;
			this.Telephone = Telephone;
			this.Latitude = Latitude;
			this.Longitude = Longitude;
		}

		#endregion
	}
}
