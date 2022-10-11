using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private int numberOfToppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.Toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }
        public int NumberOfToppings
        {
            get { return numberOfToppings; }
            private set
            {
                if (value > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }

                numberOfToppings = value;
            }
        }
        public double TotalCalories
        {
            get { return this.GetTotalCalories(); }
        }
        public Dough Dough { get; set; }
        public List<Topping> Toppings { get; private set; }

        private double GetTotalCalories()
        {
            return this.Dough.TotalCalories + this.Toppings.Sum(x => x.TotalCalories);
        }
        public void AddTopping(Topping topping)
        {
            this.Toppings.Add(topping);
            this.NumberOfToppings++;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
