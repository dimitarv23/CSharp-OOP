using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }
        public virtual double FuelConsumption { get; set; }

        public virtual string Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;

            if (neededFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
                return $"travelled {distance} km";
            }

            return $"needs refueling";
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
