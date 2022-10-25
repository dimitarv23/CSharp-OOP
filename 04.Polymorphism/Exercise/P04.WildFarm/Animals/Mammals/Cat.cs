using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Animals.Mammals
{
    public class Cat : Feline
    {
        private List<string> foods = new List<string>() { "Vegetable", "Meat" };

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "Meow";
        }

        public override bool CanEatFood(string foodType)
        {
            return this.foods.Contains(foodType);
        }

        public override void EatFood(int quantity)
        {
            this.Weight += quantity * 0.3;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
