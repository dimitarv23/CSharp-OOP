using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private List<string> foods = new List<string>() { "Vegetable", "Fruit" };

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override bool CanEatFood(string foodType)
        {
            return foods.Contains(foodType);
        }

        public override void EatFood(int quantity)
        {
            this.Weight += quantity * 0.1;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
