using System;
using TaxiProject_2._1.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace TaxiProject_2._1.Repository
{


    public class DriverBusRepository : Repository<DriverBus>
    {



        public override void Add(DriverBus dr)
        {
            AddRep(dr);
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
        public override List<DriverBus> GroupedByAscending(List<DriverBus> drbus)
        {


            return drbus.OrderBy(x => x.Name).ToList();
        }

        public override void ReadEntity()
        {




            List<DriverBus> lines = new List<DriverBus>() { new DriverBus(1, "Vasyl", 4, 230),new DriverBus(1,"Anya", 5, 230) };


            for (int i = 0; i < lines.Count; i++)
            {



                Add(lines[i]);


            }






        }



    }
}
