﻿using System;
using System.Collections.Generic;
using System.Text;
using TaxiProject_2._1.Models;
using System.IO;

namespace TaxiProject_2._1.Repository
{
    public class DriverCarFileRepository : FileRepository<DriverCar>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
   


        public override void Add(DriverCar b)
        {
          AddRep(b);
        }


        public override void ReadFromStorage()
        {

            try
            {
                List<string> lines = new List<string>();
                int id;
                string name;
                int rate;
                int price;
                using (StreamReader sr = new StreamReader(@"C:\c#\NewTaxiProject\TaxiProjectUser\bin\Debug\Drivercar.txt"))
                {

                    while (!sr.EndOfStream)
                    {
                        lines.Add(sr.ReadLine());

                    }
                    sr.Close();
                }
                for (int i=0; i < lines.Count; i++)
                {

                    string[] subs = lines[i].Split(' ');
                    id = Convert.ToInt32(subs[0]);
                    name = subs[1];
                    rate = Convert.ToInt32(subs[2]);


                    price = Convert.ToInt32(subs[3]);
                    DriverCar t = new DriverCar(id, name, rate, price);
                    Add(t);
                }






            }
            catch (Exception e)
            {
                log.Error(e.Message);
               // Console.WriteLine(e.Message);
            }





        }
        public override void ChangeRateVehicle(int index, int rating)
        {

            if (index >= entity.Count || index < 0)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            else
            {


                entity[index].Rate = rating;
            }



        }
        public override void WriteToStorage()
        {




            try
            {


                using (StreamWriter sw = new StreamWriter(@"C:\c#\NewTaxiProject\TaxiProjectUser\bin\Debug\Drivercar.txt"))
                {

                    foreach (DriverCar o in entity)
                    {
                        sw.WriteLine(o.GetInfo());//адреси зберігає

                    }
                    sw.Close();
                }

            }
           
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
