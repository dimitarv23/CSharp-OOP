using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, double caffeine) : base(name, 0, 0)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
        public override double Milliliters => 50;
        public override decimal Price => 3.50m;
    }
}
