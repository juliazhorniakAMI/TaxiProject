using System;
using TaxiProject_2._1.Models;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace TaxiProject_2._1.Repository
{
	public class Repository<T> : IRepository<T>
	{



		protected List<T> entity = new List<T>();







		public Repository()
		{
		
			ReadEntity();
		}
	
		public virtual void ReadEntity() { }
		

		public List<T> Ent { get { return entity; } set {

				entity = value;
				if (value == null) {



						Type type1 = typeof(List<T>);
						throw new NullReferenceException(type1.ToString());




					
				}
			} }


		public void deleteByIndex(int ind)
		{
			if (ind >= entity.Count() || ind < 0) {


				throw new IndexOutOfRangeException(nameof(ind));
			}
			else {

				entity.RemoveAt(ind);


			}
			
		}
		public virtual void ChangeRateVehicle(int index, int rating)
		{


		}

		

		public void AddRep(T en)
		{
			if (en == null)
			{


				throw new ArgumentNullException(nameof(en));
			}
			else {

				entity.Add(en);
			}
		

		
			

		
		}
	


		public virtual void Add(T en) { throw new NotImplementedException(); }

        void IRepository<T>.ReadFromStorage()
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.WriteToStorage()
        {
            throw new NotImplementedException();
        }
    }
}

