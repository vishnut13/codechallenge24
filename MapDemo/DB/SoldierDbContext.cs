﻿using MapDemo.Data;
using System.Data.Common;
using System.Data.Entity;

namespace MapDemo.DB
{
    public class SoldierDbContext : DbContext
    {
        public DbSet<SoldierData> Soldiers { get; set; }
        public DbSet<LocationData> Locations { get; set; }

        public SoldierDbContext() : base("SoldierDbContext")
        {
        }

        public SoldierDbContext(DbConnection connection) : base(connection, false)
        {
        }
    }
}
