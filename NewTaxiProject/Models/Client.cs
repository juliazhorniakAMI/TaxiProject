using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiProject_2._1.Models
{
	public class Client : Person
	{
		string address;


		public string Address { get { return address; } set { address = value; } }
		public Client(int id=0,string name = "", string address = "") : base(id,name)
		{

			Address = address;

		}
		public string GetInfo()
		{

			return string.Format(name + " " + address);
		}

		public override string ToString()
		{
			return $"\nInformation of client: \nFirst Name: {name}\nAddress: {address}";

		}
	}
}
