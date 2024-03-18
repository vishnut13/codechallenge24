using Effort;
using MapDemo.Data;
using MapDemo.DB;
using MapDemo.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MapDemo.Tests
{
    [TestClass]
    public class DataCRUDTests
    {
        private SoldierDbContext dbContext;

        [TestInitialize]
        public void Setup()
        {
            var connection = DbConnectionFactory.CreateTransient();

            dbContext = new SoldierDbContext(connection);
        }

        [TestMethod]
        public void SaveToDatabaseTest()
        {
            SoldierData sd = new SoldierData()
            {
                Id = 1,
                Name = "Name1"
            };

            dbContext.Soldiers.Add(sd);
            dbContext.SaveChanges();

            //// Assert
            Assert.AreEqual(1, dbContext.Soldiers.Count());
            Assert.IsNotNull(dbContext.Soldiers.FirstOrDefault(s => s.Id == 1));
        }

        [TestMethod]
        public void LocationDBTest()
        {
            SoldierData sd = new SoldierData()
            {
                Id = 1,
                Name = "Name1"
            };
            LocationData ld = new LocationData()
            {
                Id = 1,
                Soldier_Id = sd.Id,
                Soldier = sd,
                Latitude = 10,
                Longitude = 20,
                Altitude = 30,
            };
            sd.Locations.Add(ld);

            dbContext.Soldiers.Add(sd);
            dbContext.SaveChanges();

            //// Assert
            Assert.AreEqual(1, dbContext.Soldiers.Count());
            Assert.IsNotNull(dbContext.Locations.FirstOrDefault(l => l.Soldier_Id == 1));
        }

    }
}
