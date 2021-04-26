using System;
using TaxiProject_2._1.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace TaxiProject_2._1.Repository
{
	

	public class TaxiFileRepository : FileRepository<Taxi>
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


		public override void Add(Taxi taxi)
		{
	       AddRep(taxi);
		}

	

		public override void ReadFromStorage()
		{
			

			try
			{
			
				List<string> lines = new List<string>();
				int id;
				string make;
				int number;
				string color;
				int MaxSpeed;

				using (StreamReader sr = new StreamReader(@"C:\c#\NewTaxiProject\TaxiProjectUser\bin\Debug\Taxi.txt"))
				{

					while (!sr.EndOfStream)
					{
						lines.Add(sr.ReadLine());

					}
					sr.Close();
				}
				for (int i=0;i<lines.Count;i++) {

					string[] subs = lines[i].Split(' ');
					id = Convert.ToInt32(subs[0]);
					make = subs[1];
					number = Convert.ToInt32(subs[2]);

					color = subs[3];
					MaxSpeed = Convert.ToInt32(subs[4]);
					Taxi t = new Taxi(id,make, number, color, MaxSpeed);
					Add(t);


				}
			
				
				

			}
			catch (Exception e)
			{
				log.Error(e.Message);
				//Console.WriteLine(e.Message);
			}
		}

		public override void WriteToStorage()
		{
			

			


			try
			{
				

				using (StreamWriter sw = new StreamWriter(@"C:\c#\NewTaxiProject\TaxiProjectUser\bin\Debug\Taxi.txt",false))
				{

					foreach (Taxi o in entity)
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
