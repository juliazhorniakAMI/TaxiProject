using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TaxiProject_2._1.Models;
using TaxiProject_2._1.Repository;
using NewTaxiProject.AbstractFactory;
namespace TaxiProjectUser
{
    class Command
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

     


        public void RentTaxi()
        {
            string nameoftaxi = "x";
            int k;
            Console.WriteLine("Enter the number of seats from 1-8 you need for a taxi: \n");

            k = Convert.ToInt32(Console.ReadLine());

            if (k <= 4)
            {
                for (int i = 0; i < taxiRepository.Ent.Count(); i++)
                {
                    Console.WriteLine(taxiRepository.Ent[i]);



                }
                Console.WriteLine("Write the name of a taxi car you want to rent: \n");
                nameoftaxi = Console.ReadLine();


                for (int i = 0; i < taxiRepository.Ent.Count(); i++)
                {

                    if (nameoftaxi == taxiRepository.Ent[i].Make)
                    {

                        taxiRepository.deleteByIndex(i);

                        driverCARRepository.deleteByIndex(i);
                        taxiRepository.WriteToStorage();
                        driverCARRepository.WriteToStorage();
                    }


                }
            }
            else if (5 <= k && k <= 8)
            {
                for (int i = 0; i < busRepository.Ent.Count(); i++)
                {
                    Console.WriteLine(busRepository.Ent[i]);




                }
                Console.WriteLine("\nWrite the name of a taxi bus you want to rent: ");

                nameoftaxi = Console.ReadLine();
                for (int i = 0; i < busRepository.Ent.Count(); i++)
                {

                    if (nameoftaxi == busRepository.Ent[i].Make)
                    {

                        busRepository.deleteByIndex(i);
                        driverBUSRepository.deleteByIndex(i);
                        busRepository.WriteToStorage();
                        driverBUSRepository.WriteToStorage();
                    }


                }
            }



            try
            {


                using (StreamWriter sw = new StreamWriter("Client.txt", false))
                {
                    
                    string firstName;
                    string address;
                    Console.WriteLine("Enter the Name of the client: ");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Enter the Address of the client: ");
                    address = Console.ReadLine();
                    Client c = new Client(0,firstName, address);
                    sw.WriteLine(firstName + " " + address);
                    Console.WriteLine($"- - - - - - >  You: {firstName},on the street {address},have rented a taxi: {nameoftaxi} and been added to base__\n");


                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }


        public void showRate()
        {

            for (int i = 0; i < driverCARRepository.Ent.Count(); i++)
            {

                if (driverCARRepository.Ent[i].Rate == 5)
                {
                    Console.WriteLine("\n- - - - - \nA car-driver with the highest rate is: \n");
                    Console.WriteLine(driverCARRepository.Ent[i]);
                }

            }
            for (int i = 0; i < driverBUSRepository.Ent.Count(); i++)
            {
                if (driverBUSRepository.Ent[i].Rate == 5)
                {
                    Console.WriteLine("\n- - - - - \nA bus-driver with the highest rate is: \n");
                    Console.WriteLine(driverBUSRepository.Ent[i]);
                }

            }


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
                        driverCARRepository.WriteToStorage();
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
                        driverBUSRepository.WriteToStorage();
                        break;
                    }
                }

            }

            
        }


    }
}
