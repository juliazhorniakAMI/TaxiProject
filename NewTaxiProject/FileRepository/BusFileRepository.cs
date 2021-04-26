using System;
using System.IO;
using TaxiProject_2._1.Models;
using System.Collections.Generic;
using System.Text;

namespace TaxiProject_2._1.Repository
{
   public class BusFileRepository:FileRepository<Bus>
    {
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
	


		public override void Add(Bus bus)
		{
			 AddRep(bus);
		}



		public override void ReadFromStorage()
		{
			//string path = @"C:\c#навчальна\TaxiProject_2.1\data\Bus.txt";


			try
			{
				List<string> lines = new List<string>();
				string make;
				int number;
				string color;
				int MaxSpeed;
				int id;

				using (StreamReader sr = new StreamReader(@"C:\c#\NewTaxiProject\TaxiProjectUser\bin\Debug\Bus.txt"))
				{

					while (!sr.EndOfStream)
					{
						lines.Add(sr.ReadLine());

					}
					sr.Close();
				}
				for (int i= 0; i < lines.Count; i++)
				{

					string[] subs = lines[i].Split(' ');
					id = Convert.ToInt32(subs[0]);
					make = subs[1];
					number = Convert.ToInt32(subs[2]);

					color = subs[3];
					MaxSpeed = Convert.ToInt32(subs[4]);
					Bus t = new Bus(id, make, number, color, MaxSpeed);
					Add(t);


				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		public override void WriteToStorage()
		{

			try
			{
			
				using (StreamWriter sw = new StreamWriter(@"C:\c#\NewTaxiProject\TaxiProjectUser\bin\Debug\Bus.txt", false))
				{

					foreach (Bus o in entity)
					{
						sw.WriteLine(o.GetInfo());//адреси зберігає

					}
					sw.Close();
				}
				
				
			}

			catch (Exception e)
			{
				log.Info(e.Message);
				//Console.WriteLine(e.Message);
			}

		}
	}
}

