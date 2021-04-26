using System;
using TaxiProject_2._1.Models;
using System.Collections.Generic;
using System.Text;



namespace TaxiProject_2._1.Repository
{
	public class FileRepository<T> : IRepository<T>
	{



		protected List<T> entity = new List<T>();



		 ~FileRepository()
		{

			WriteToStorage();
		}



		public FileRepository()
		{
		
			ReadFromStorage();
		}
		public virtual void ReadFromStorage() { }
		public virtual void WriteToStorage() { }

		public List<T> Ent
		{
			get { return entity; }
			set
			{

				entity = value;
				if (value == null)
				{



					Type type1 = typeof(List<T>);
					throw new NullReferenceException(type1.ToString());





				}
			}
		}


		public void deleteByIndex(int ind)
		{
			if (ind >= entity.Count || ind < 0)
			{


				throw new IndexOutOfRangeException(nameof(ind));
			}
			else
			{

				entity.RemoveAt(ind);


			}
		}
		public virtual void ChangeRateVehicle(int index, int rating)
		{


		}

		//~FileRepository()
		//{
		//	WriteToStorage();

		//}

		public void AddRep(T en)
		{
			entity.Add(en);
			WriteToStorage();


		}

		public virtual void Add(T en) { throw new NotImplementedException(); }

	}
}

