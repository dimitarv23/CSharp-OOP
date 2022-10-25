using System;
using System.Collections.Generic;
using System.Text;

namespace P02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 1.6;

        public override string Drive(double distance)
        {
            return "Truck " + base.Drive(distance);
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }
    }
}
