using MapDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDemo.Models
{
    public class SoldierCache
    {
        public int Id { get; set; }
        public LocationData Location { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }

        public SoldierCache(double latitude, double longitude)
        {
            Location = new LocationData() { Latitude = latitude, Longitude = longitude };
            Name = "Name" + Id;
            Rank = "Rank" + Id;
        }

    }
}
