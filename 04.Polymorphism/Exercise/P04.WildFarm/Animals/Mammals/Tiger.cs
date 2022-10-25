using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Animals.Mammals
{
    public class Tiger : Feline
    {
        private List<string> foods = new List<string>() { "Meat" };

        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }

        public override bool CanEatFood(string foodType)
        {
            return foods.Contains(foodType);
        }

        public override void EatFood(int quantity)
        {
            this.Weight += quantity;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
