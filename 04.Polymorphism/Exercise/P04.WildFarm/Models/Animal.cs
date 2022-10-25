using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Models
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract string AskForFood();
        public abstract void EatFood(int quantity);
        public abstract bool CanEatFood(string foodType);
    }
}
