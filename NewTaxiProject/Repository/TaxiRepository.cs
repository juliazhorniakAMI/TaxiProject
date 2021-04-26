using System;
using TaxiProject_2._1.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TaxiProject_2._1.Repository
{
	

	public class TaxiRepository : Repository<Taxi>
	{
		
	

		public override void Add(Taxi taxi)
		{
			AddRep(taxi);
		}

	

		public override void ReadEntity()
		{

			if (entity == null)
			{

				throw new ArgumentNullException(nameof(entity));

			}
			else {

				List<Taxi> lines = new List<Taxi>() { new Taxi(1, "Skoda", 1221, "red", 223), new Taxi(2, "Reno", 1421, "black", 220) };


				for (int i = 0; i < lines.Count; i++)
				{



					Add(lines[i]);


				}
			}
			
				
			
				
				

			
			
		}

		
		
	}
}
