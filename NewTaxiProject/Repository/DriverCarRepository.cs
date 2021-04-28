using System;
using TaxiProject_2._1.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace TaxiProject_2._1.Repository
{


	public class DriverCarRepository : Repository<DriverCar>
	{



		public override void Add(DriverCar dr)
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

		public override List<DriverCar> GroupedByAscending(List<DriverCar> drcar)
		{


			return drcar.OrderBy(x => x.Name).ToList();
		}

		public override void ReadEntity()
		{




			List<DriverCar> lines = new List<DriverCar>() { new DriverCar(1,"Andriy",4,150), new DriverCar(2,"Ihor", 5, 200) };


			for (int i = 0; i < lines.Count; i++)
			{



				Add(lines[i]);


			}






		}



	}
}
