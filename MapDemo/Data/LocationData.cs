using System;

namespace MapDemo.Data
{
    [Serializable]
    public class LocationData
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; } = 550.0;

    }
}
