using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiProject_2._1.Models;
using TaxiProject_2._1.Repository;
using NewTaxiProject.AbstractFactory;
namespace TaxiAdmin
{
  public  class Command
    {
        
        public IRepository<Taxi> taxiRepository;
        public IRepository<Bus> busRepository;
        public IRepository<DriverCar> driverCARRepository;

        public IRepository<DriverBus> driverBUSRepository;



        AbstractFactory type = Choose_Type.ChooseType();
        public Command()
        {
           
            taxiRepository = type.TaxiRep();
            busRepository = type.BusRep();
            driverBUSRepository = type.DriverBusRep();
            driverCARRepository = type.DriverCarRep();
         
        }


        public void AddTaxi(Taxi taxi)
        {
            taxiRepository.Add(taxi);
        }

        public void AddBus(Bus taxibus)
        {
            busRepository.Add(taxibus);
        }
        public void AddDriverCar(DriverCar driver)
        {
            driverCARRepository.Add(driver);
        }
        public void AddDriverBus(DriverBus driver)
        {
            driverBUSRepository.Add(driver);
        }
        public void Print()
        {

            foreach (Taxi o in taxiRepository.Ent)
            {
                Console.WriteLine(o);


            }
            foreach (Bus o in busRepository.Ent)
            {
                Console.WriteLine(o);
            }

        }


        public void WriteAllDrivers()
        {
            for (int i = 0; i < taxiRepository.Ent.Count(); i++)
            {
                Console.WriteLine(driverCARRepository.Ent[i]);
                Console.WriteLine(taxiRepository.Ent[i]);



            }
            for (int i = 0; i < busRepository.Ent.Count(); i++)
            {
                Console.WriteLine(driverBUSRepository.Ent[i]);
                Console.WriteLine(busRepository.Ent[i]);



            }
        }




        public List<Person> showRate()
        {
            List<Person> pers = new List<Person>();
            for (int i = 0; i < driverCARRepository.Ent.Count(); i++)
            {
              
                if (driverCARRepository.Ent[i].Rate == 5) {
                    pers.Add(driverCARRepository.Ent[i]);
                    Console.WriteLine("\n- - - - - \nA car-driver with the highest rate is: \n");
                    Console.WriteLine(driverCARRepository.Ent[i]);
                }

            }
            for (int i = 0; i < driverBUSRepository.Ent.Count(); i++)
            {
                if (driverBUSRepository.Ent[i].Rate == 5)
                {
                    pers.Add(driverBUSRepository.Ent[i]);
                    Console.WriteLine("\n- - - - - \nA bus-driver with the highest rate is: \n");
                    Console.WriteLine(driverBUSRepository.Ent[i]);
                }

            }
            return pers;
         

        }
        public void changeRate()
        {
            int rating;

            string name;

            int b;
            Console.WriteLine("Enter 1 if you want to change rate for cars and 0 for buses: \n");
            b = Convert.ToInt32(Console.ReadLine());

          
            Console.WriteLine("Enter the name of a driver whose rating you want to change :  \n");


            name = Console.ReadLine();
            if (b == 1)
            {
                for (int i = 0; i < driverCARRepository.Ent.Count(); i++)
                {
                    if ((driverCARRepository.Ent[i]).Name == name)
                    {
                        Console.WriteLine("Enter a rating from 1-5 to this driver:  \n");
                        rating = Convert.ToInt32(Console.ReadLine());


                        driverCARRepository.ChangeRateVehicle(i, rating);
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < driverBUSRepository.Ent.Count(); i++)
                {
                    if ((driverBUSRepository.Ent[i]).Name == name)
                    {
                        Console.WriteLine("Enter a rating from 1 - 5 to this driver:  \n");

                        rating = Convert.ToInt32(Console.ReadLine());
                        driverBUSRepository.ChangeRateVehicle(i, rating);
                        break;
                    }
                }

            }
        }
    }
}


