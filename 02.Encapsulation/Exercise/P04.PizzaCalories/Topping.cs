using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.PizzaCalories
{
    public class Topping
    {
        private string type;
        private int weight;

        private const int @base = 2;
        private double modifier;
        private string[] allowedToppings = new string[4] { "meat", "veggies", "cheese", "sauce" };

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get { return type; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || !allowedToppings.Contains(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
        }
        public int Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }
        public double TotalCalories
        {
            get { return this.GetTotalCalories(); }
        }

        private void GetModifier()
        {
            switch (this.Type.ToLower())
            {
                case "meat": this.modifier = 1.2; break;
                case "veggies": this.modifier = 0.8; break;
                case "cheese": this.modifier = 1.1; break;
                case "sauce": this.modifier = 0.9; break;
                default: break;
            }
        }
        private double GetTotalCalories()
        {
            this.GetModifier();
            double calories = @base * this.Weight * this.modifier;
            return calories;
        }
    }
}
