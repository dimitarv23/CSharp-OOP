using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 1.6;

        public override string Drive(double distance)
        {
            return "Truck " + base.Drive(distance);
        }

        public override void Refuel(double liters)
        {
            liters *= 0.95;
            base.Refuel(liters);
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }
    }
}
