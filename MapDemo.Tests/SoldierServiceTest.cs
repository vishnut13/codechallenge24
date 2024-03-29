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

        [TestMethod]
        public void RemoveTest()
        {
            SoldierService target = new SoldierService();
            var sd = new SoldierCache(10, 20) { Id = 1 };
            target.SoldierCache.Add(sd);

            // Assert
            Assert.AreEqual(1, target.SoldierCache.Count,"add count check");

            target.SoldierCache.Remove(sd);

            Assert.AreEqual(0, target.SoldierCache.Count, "remove count check");
        }


    }
}
