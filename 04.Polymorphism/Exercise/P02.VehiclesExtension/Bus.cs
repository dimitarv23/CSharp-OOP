using System;
using System.Collections.Generic;
using System.Text;

namespace P02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public bool AreTherePeople { get; set; } = true;
        public override double FuelConsumption => this.AreTherePeople ? base.FuelConsumption + 1.4 : base.FuelConsumption;

        public override string Drive(double distance)
        {
            return "Bus " + base.Drive(distance);
        }

        public void DriveEmpty() { }

        public override string ToString()
        {
            return $"Bus: {this.FuelQuantity:f2}";
        }
    }
}
