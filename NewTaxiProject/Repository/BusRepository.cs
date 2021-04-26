using System;
using TaxiProject_2._1.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TaxiProject_2._1.Repository
{


    public class BusRepository : Repository<Bus>
    {



        public override void Add(Bus bus)
        {
            AddRep(bus);
        }



        public override void ReadEntity()
        {




            List<Bus> lines = new List<Bus>() { new Bus(1,"Jeep", 1221, "red", 223) };


            for (int i = 0; i < lines.Count; i++)
            {



                Add(lines[i]);


            }






        }



    }
}
