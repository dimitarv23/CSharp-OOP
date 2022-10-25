using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 0.9;

        public override string Drive(double distance)
        {
            return "Car " + base.Drive(distance);
        }

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";
        }
    }
}
