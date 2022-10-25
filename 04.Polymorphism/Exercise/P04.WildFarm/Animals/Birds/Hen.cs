using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private List<string> foods = new List<string>() { "Vegetable", "Fruit", "Meat", "Seeds" };

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Cluck";
        }

        public override void EatFood(int quantity)
        {
            this.Weight += quantity * 0.35;
        }

        public override bool CanEatFood(string foodType)
        {
            return this.foods.Contains(foodType);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
