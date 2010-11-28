using System;

namespace eConcierge.Model
{
    public class DTOLocationBase
    {
        private double? _Longitude;

        public double? Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }

        private double? _Latitude;

        public double? Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }
    }
}