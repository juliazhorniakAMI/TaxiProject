using System;
using System.Collections.Generic;
using System.Text;

using TaxiProject_2._1.Repository;
using TaxiProject_2._1.Models;
using System.Configuration;

namespace NewTaxiProject.AbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract IRepository<Taxi> TaxiRep();
        public abstract IRepository<DriverBus> DriverBusRep();
        public abstract IRepository<DriverCar> DriverCarRep();
        public abstract IRepository<Bus> BusRep();


      

    }

   
}
