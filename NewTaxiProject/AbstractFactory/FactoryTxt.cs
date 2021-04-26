using System;
using System.Collections.Generic;
using System.Text;
using TaxiProject_2._1.Repository;
using TaxiProject_2._1.Models;

namespace NewTaxiProject.AbstractFactory
{
  
    public class FactoryTxt : AbstractFactory
    {
        public override IRepository<Bus> BusRep()
        {
            return new BusFileRepository();
        }

        public override IRepository<DriverBus> DriverBusRep()
        {
            return new DriverBusFileRepository();
        }

        public override IRepository<DriverCar> DriverCarRep()
        {
            return new DriverCarFileRepository();
        }

        public override IRepository<Taxi> TaxiRep()
        {
            return new TaxiFileRepository();
        }
    }
}
