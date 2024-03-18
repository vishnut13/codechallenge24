using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MapDemo.Models
{
    public class SoldierService
    {
        public List<SoldierCache> SoldierCache;
        public SoldierService()
        {
            // Initialize cache
            SoldierCache = new List<SoldierCache>();

        }

        public List<SoldierCache> Generate()
        {
            // Simulate soldier data by generating random positions
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                double latitude = 46.950249 + (rand.NextDouble() - 0.4) * 0.01;
                double longitude = 7.415634 + (rand.NextDouble() - 0.4) * 0.01;
                SoldierCache.Add
                    (new SoldierCache(latitude, longitude) { Id = i, Name = "Name" + i, Rank = "Rank" + i });
            }
            return SoldierCache;
        }

    }
}
