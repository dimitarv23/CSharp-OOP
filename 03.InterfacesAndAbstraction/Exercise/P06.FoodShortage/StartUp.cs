using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var buyers = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();

                IBuyer buyer = null;

                if (cmd.Length == 4)
                {
                    string name = cmd[0];
                    int age = int.Parse(cmd[1]);
                    string id = cmd[2];
                    string birthdate = cmd[3];

                    buyer = new Citizen(name, age, id, birthdate);
                }
                else if (cmd.Length == 3)
                {
                    string name = cmd[0];
                    int age = int.Parse(cmd[1]);
                    string group = cmd[2];

                    buyer = new Rebel(name, age, group);
                }
                else
                {
                    continue;
                }

                buyers.Add(buyer);
            }

            int totalFoodPurchased = 0;

            string nameOfBuyer = Console.ReadLine();
            while (nameOfBuyer != "End")
            {
                if (buyers.Any(b => b.Name == nameOfBuyer))
                {
                    var buyer = buyers.Single(b => b.Name == nameOfBuyer);
                    totalFoodPurchased += buyer.BuyFood();
                }

                nameOfBuyer = Console.ReadLine();
            }

            Console.WriteLine(totalFoodPurchased);
        }
    }
}
