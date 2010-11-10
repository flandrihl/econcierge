using System;

namespace eConcierge.Model
{
	[Serializable()]
	public class DTOEventCalendarCategory
	{
		#region Field & Properties
		private int _Id;

		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		private string _Name;

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
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
		public DTOEventCalendarCategory()
		{ }

		public DTOEventCalendarCategory(int Id,string Name,string Description)
		{
			this.Id = Id;
			this.Name = Name;
			this.Description = Description;
		}

		#endregion
	}
}
