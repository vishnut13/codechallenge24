using MapDemo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace MapDemo.Tests
{
    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        public void AddSoldierTest()
        {
            var vm = new ViewModels.MainViewModel();
            vm.Soldiers = new ObservableCollection<SoldierCache>();
            vm.Soldiers.Add(new SoldierCache(10, 20));

            // Assert
            Assert.AreEqual(1, vm.Soldiers.Count);
        }


        [TestMethod]
        public void LocationTest()
        {
            var vm = new ViewModels.MainViewModel();
            vm.Soldiers = new ObservableCollection<SoldierCache>();
            vm.Soldiers.Add(new SoldierCache(10, 20));

            // Assert
            Assert.AreEqual(1, vm.Soldiers.Count);
            Assert.AreEqual(10, vm.Soldiers[0].Location.Latitude);
            Assert.AreEqual(20, vm.Soldiers[0].Location.Longitude);

        }
    }
}
