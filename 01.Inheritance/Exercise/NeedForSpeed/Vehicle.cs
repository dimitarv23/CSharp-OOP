using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption { get { return this.DefaultFuelConsumption; } }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double km)
        {
            this.Fuel -= km * this.FuelConsumption;
        }
    }
}
