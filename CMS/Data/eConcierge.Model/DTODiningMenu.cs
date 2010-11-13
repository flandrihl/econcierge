using System;

namespace eConcierge.Model
{
	[Serializable()]
	public class DTODiningMenu
	{
		#region Field & Properties
		private int _Id;

		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		private int _DiningId;

		public int DiningId
		{
			get { return _DiningId; }
			set { _DiningId = value; }
		}

		private Byte[] _Photo;

		public Byte[] Photo
		{
			get { return _Photo; }
			set { _Photo = value; }
		}

		private string _FileName;

		public string FileName
		{
			get { return _FileName; }
			set { _FileName = value; }
		}

			public bool IsNew { get; set; }
		#endregion

		#region Constructors
		public DTODiningMenu()
		{ }

		public DTODiningMenu(int Id,int DiningId,Byte[] Photo,string FileName)
		{
			this.Id = Id;
			this.DiningId = DiningId;
			this.Photo = Photo;
			this.FileName = FileName;
		}

		#endregion
	}
}
