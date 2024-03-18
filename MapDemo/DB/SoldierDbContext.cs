using MapDemo.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace MapDemo.DB
{
    public class SoldierDbContext : DbContext
    {
        public DbSet<SoldierData> Soldiers { get; set; }
        public DbSet<LocationData> Locations { get; set; }

        public SoldierDbContext() : base("SoldierDbContext")
        {
        }

    }
}
