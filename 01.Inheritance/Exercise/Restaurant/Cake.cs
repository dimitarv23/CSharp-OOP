using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name) : base(name, 0, 0, 0)
        {
        }

        public override double Grams => 250;
        public override double Calories => 1000;
        public override decimal Price => 5;
    }
}
