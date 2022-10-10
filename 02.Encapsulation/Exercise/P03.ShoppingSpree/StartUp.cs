using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var people = new List<Person>();
                var products = new List<Product>();

                string[] peopleArgs = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var person in peopleArgs)
                {
                    string[] personInfo = person.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string personName = personInfo[0];
                    decimal money = decimal.Parse(personInfo[1]);

                    if (!people.Any(p => p.Name == personName))
                    {
                        var currPerson = new Person(personName, money);
                        people.Add(currPerson);
                    }
                }

                string[] productsArgs = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var product in productsArgs)
                {
                    string[] productInfo = product.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string productName = productInfo[0];
                    decimal cost = decimal.Parse(productInfo[1]);

                    if (!products.Any(p => p.Name == productName))
                    {
                        var currProduct = new Product(productName, cost);
                        products.Add(currProduct);
                    }
                }

                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string personName = cmdArgs[0];
                    string productName = cmdArgs[1];

                    var person = people.FirstOrDefault(p => p.Name == personName);
                    var product = products.FirstOrDefault(p => p.Name == productName);

                    Console.WriteLine(person.BuyProduct(product));

                    command = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
