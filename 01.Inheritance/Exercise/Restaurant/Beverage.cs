using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double ml) : base(name, price)
        {
            this.Milliliters = ml;
        }

        public virtual double Milliliters { get; set; }
    }
}
