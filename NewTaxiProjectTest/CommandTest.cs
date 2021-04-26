using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiProject_2._1.Models;
using TaxiProject_2._1.Repository;
using TaxiAdmin;
using System.Configuration;
namespace NewTaxiProjectTest
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]


        public void ShowMaxRate_of_Driver_True()
        {
            Command c= new Command();
            
            var expected = new List<Person>() { new DriverCar(2, "Ihor", 5, 200), new DriverBus(1, "Anya", 5, 230) };
            var result = c.showRate();
            
           
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Rep_Check_IsEmpty_False()
        {
            Command c = new Command();
            var taxiRep = c.taxiRepository;
            var busRep = c.busRepository;
            var driverCARRep = c.driverCARRepository;

            var driverBUSRep = c.driverBUSRepository;
            
            Assert.IsNotNull(taxiRep);
            Assert.IsNotNull(busRep);
            Assert.IsNotNull(driverCARRep);
            Assert.IsNotNull(driverBUSRep);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Rep_Check_IsNull_True()
        {
            Command c = new Command();
            c.taxiRepository.Ent = null;
            
         
            Assert.ThrowsException<NullReferenceException>(() => c.taxiRepository.Ent);
        }

    }
}
