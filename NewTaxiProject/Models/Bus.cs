using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiProject_2._1.Models
{
    public class Bus : Vehicle
    {

        public Bus(int id=0,string make = "", int number = 0, string color = "", int MaxSpeed = 0) : base(id,make, number, color, MaxSpeed)
        { }

        public override string ToString()
        {
            return $"\n___________Bus information____________:\nMake: {make}\nNumber: {number}\nColor: {color}\nMaxSpeed: {maxSpeed}";
        }
    }
}
