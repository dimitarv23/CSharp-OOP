using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        private List<string> foods = new List<string>() { "Meat" };

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override bool CanEatFood(string foodType)
        {
            return this.foods.Contains(foodType);
        }

        public override void EatFood(int quantity)
        {
            this.Weight += quantity * 0.4;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
