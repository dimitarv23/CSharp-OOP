using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        private List<string> foods = new List<string>() { "Meat" };

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override bool CanEatFood(string foodType)
        {
            return this.foods.Contains(foodType);
        }

        public override void EatFood(int quantity)
        {
            this.Weight += quantity * 0.25;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
