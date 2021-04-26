using System;
using System.Collections.Generic;
using System.Text;
using TaxiProject_2._1.Repository;
using TaxiProject_2._1.Models;

namespace NewTaxiProject.AbstractFactory
{
    public class FactoryList : AbstractFactory
    {
        public override IRepository<Bus> BusRep()
        {
            return new BusRepository();
        }

        public override IRepository<DriverBus> DriverBusRep()
        {
            return new DriverBusRepository();
        }

        public override IRepository<DriverCar> DriverCarRep()
        {
            return new DriverCarRepository();
        }

        public override IRepository<Taxi> TaxiRep()
        {
            return new TaxiRepository();
        }
    }
}
