using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiProject_2._1.Models
{
	public class DriverBus : Person
	{

		int price;
		int rate;
		public int Price { get { return price; } set { price = value; } }
		public int Rate { get { return rate; } set { rate = value; } }
		public DriverBus(int id=0,string name = "", int rate = 0, int price = 0) : base(id,name)
		{

			Rate = rate;
			Price = price;

		}
		public static bool operator >(DriverBus first, DriverCar second)
		{
			return (first.Rate > second.Rate);
		}
		public static bool operator <(DriverBus first, DriverCar second)
		{
			return (first.Rate < second.Rate);
		}

		public string GetInfo()
		{

			return string.Format(Id+" "+name + " " + rate + " " + price);
		}
		public override bool Equals(object obj)
		{
			DriverBus mobj = obj as DriverBus;
			return mobj != null && Object.Equals(this.Name, mobj.Name) && Object.Equals(this.Rate, mobj.Rate) && Object.Equals(this.Price, mobj.Price);
		}
		public override string ToString()
		{
			return $"\n_-_-_-_-_-_Info of the bus driver_-_-_-_-_-_: \nName: {name}\nResidence: {Residence}\nRate: {rate}\nPrice: {price}";
		}
	}
}
