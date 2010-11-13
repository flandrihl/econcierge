using System;

namespace eConcierge.Model
{
	[Serializable()]
	public class DTODiningSubCategory
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

			public bool IsNew { get; set; }
		#endregion

		#region Constructors
		public DTODiningSubCategory()
		{ }

		public DTODiningSubCategory(int Id,int CategoryId,string Title,string Description)
		{
			this.Id = Id;
			this.CategoryId = CategoryId;
			this.Title = Title;
			this.Description = Description;
		}

		#endregion
	}
}
