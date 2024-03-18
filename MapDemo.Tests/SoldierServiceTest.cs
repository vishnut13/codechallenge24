using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MapDemo.Models.Tests
{
    [TestClass]
    public partial class SoldierServiceTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            SoldierService target = new SoldierService();

            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void GenerateTest()
        {
            SoldierService target = new SoldierService();


            List<SoldierCache> result = target.Generate(10);

            Assert.IsTrue(result.Count == 10);
        }

        [TestMethod]
        public void LocationTest()
        {
            SoldierService target = new SoldierService();
            target.SoldierCache.Add(new SoldierCache(10, 20));

            // Assert
            Assert.AreEqual(1, target.SoldierCache.Count);
            Assert.AreEqual(10, target.SoldierCache[0].Location.Latitude);
            Assert.AreEqual(20, target.SoldierCache[0].Location.Longitude);
        }

    }
}
