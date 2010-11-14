using System;

namespace eConcierge.Model
{
	[Serializable()]
	public class DTOTransportation
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

		private int _TransportationType;

		public int TransportationType
		{
			get { return _TransportationType; }
			set { _TransportationType = value; }
		}

			public bool IsNew { get; set; }
		#endregion

		#region Constructors
		public DTOTransportation()
		{ }

		public DTOTransportation(int Id,string Title,string Description,int TransportationType)
		{
			this.Id = Id;
			this.Title = Title;
			this.Description = Description;
			this.TransportationType = TransportationType;
		}

		#endregion
	}
}
