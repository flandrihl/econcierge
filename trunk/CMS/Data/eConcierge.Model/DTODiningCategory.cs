using System;

namespace eConcierge.Model
{
	[Serializable()]
	public class DTODiningCategory
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

			public bool IsNew { get; set; }
		#endregion

		#region Constructors
		public DTODiningCategory()
		{ }

		public DTODiningCategory(int Id,string Title,string Description)
		{
			this.Id = Id;
			this.Title = Title;
			this.Description = Description;
		}

		#endregion
	}
}
