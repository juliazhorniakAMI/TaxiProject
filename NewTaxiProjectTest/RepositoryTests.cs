using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TaxiProject_2._1.Models;
using TaxiProject_2._1.Repository;

namespace NewTaxiProjectTest
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void changeRate_Of_Drivers_CollectionsEqual()
        {

            IRepository<DriverCar> driverCARRepository = new DriverCarRepository();
            var expected = new List<DriverCar>() { new DriverCar(1, "Andriy", 4, 150), new DriverCar(2, "Ihor", 4, 200) };
            driverCARRepository.ChangeRateVehicle(1, 4);
            var result = driverCARRepository.Ent;
            CollectionAssert.AreEqual(expected, result);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]

        public void changeRate_Of_Drivers_CollectionsAreNotEqual()
        {

            IRepository<DriverCar> driverCARRepository = new DriverCarRepository();
          
            driverCARRepository.ChangeRateVehicle(-2, 1);
          
            Assert.ThrowsException<IndexOutOfRangeException>(() => driverCARRepository);
        }
        [TestMethod]
       
        public void AddObject_To_Entity_CollectionsEqual()
        {

            IRepository<DriverCar> driverCARRepository = new DriverCarRepository();
            var expected = new List<DriverCar>() { new DriverCar(1, "Andriy", 4, 150), new DriverCar(2, "Ihor", 5, 200), new DriverCar(3, "Ivan", 5, 100) };
            driverCARRepository.AddRep(new DriverCar(3, "Ivan", 5, 100));
            var result = driverCARRepository.Ent;
            CollectionAssert.AreEqual(expected, result);
        }
        [TestMethod]
       
        public void AddObject_To_Entity_CollectionContains_True()
        {

            IRepository<DriverCar> driverCARRepository = new DriverCarRepository();
            var expected = new DriverCar(3, "Ivan", 5, 100);
            driverCARRepository.AddRep(new DriverCar(3, "Ivan", 5, 100));
            var result = driverCARRepository.Ent;
            CollectionAssert.Contains(result,expected);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullObject_To_Entity_ArgumentNullException_True()
        {

            IRepository<DriverCar> driverCARRepository = new DriverCarRepository();
            driverCARRepository.AddRep(null);



            Assert.ThrowsException<ArgumentNullException>(()=>driverCARRepository);
        }

        [TestMethod]
        public void DeleteObject_From_Entity_CollectionsEqual()
        {

            IRepository<DriverCar> driverCARRepository = new DriverCarRepository();
            var expected = new List<DriverCar>() { new DriverCar(2, "Ihor", 5, 200) };
            driverCARRepository.deleteByIndex(0);
            var result = driverCARRepository.Ent;
            CollectionAssert.AreEqual(expected, result);
        }


        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DeleteObject_By_UnrealIndex_IndexOutOfRangeException()
        {

            IRepository<DriverCar> driverCARRepository = new DriverCarRepository();
          
            driverCARRepository.deleteByIndex(6);

            Assert.ThrowsException<IndexOutOfRangeException>(() => driverCARRepository);
        }


    }
}
