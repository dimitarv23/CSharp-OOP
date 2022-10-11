using System;

namespace P04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string pizzaName = pizzaInfo[1];

                string[] doughInfo = Console.ReadLine().Split();
                string flour = doughInfo[1];
                string technique = doughInfo[2];
                int doughWeight = int.Parse(doughInfo[3]);

                var dough = new Dough(flour, technique, doughWeight);
                var pizza = new Pizza(pizzaName, dough);

                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] cmdArgs = command.Split();
                    string toppingType = cmdArgs[1];
                    int toppingWeight = int.Parse(cmdArgs[2]);

                    var topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                    command = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
