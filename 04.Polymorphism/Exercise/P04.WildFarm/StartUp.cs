using P04.WildFarm.Animals.Birds;
using P04.WildFarm.Animals.Mammals;
using P04.WildFarm.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace P04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int commandNum = 0;
            Animal animal = null;
            List<Animal> animals = new List<Animal>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArgs = command.Split();

                if (commandNum % 2 == 0)
                {
                    string animalType = cmdArgs[0];
                    string name = cmdArgs[1];
                    double weight = double.Parse(cmdArgs[2]);

                    Animal currAnimal = null;

                    if (animalType == "Hen")
                    {
                        currAnimal = new Hen(name, weight, double.Parse(cmdArgs[3]));
                    }
                    else if (animalType == "Owl")
                    {
                        currAnimal = new Owl(name, weight, double.Parse(cmdArgs[3]));
                    }
                    else if (animalType == "Cat")
                    {
                        currAnimal = new Cat(name, weight, cmdArgs[3], cmdArgs[4]);
                    }
                    else if (animalType == "Tiger")
                    {
                        currAnimal = new Tiger(name, weight, cmdArgs[3], cmdArgs[4]);
                    }
                    else if (animalType == "Dog")
                    {
                        currAnimal = new Dog(name, weight, cmdArgs[3]);
                    }
                    else if (animalType == "Mouse")
                    {
                        currAnimal = new Mouse(name, weight, cmdArgs[3]);
                    }

                    animal = currAnimal;
                    animals.Add(animal);
                }
                else
                {
                    string foodType = cmdArgs[0];
                    int quantity = int.Parse(cmdArgs[1]);

                    Console.WriteLine(animal.AskForFood());

                    if (animal.CanEatFood(foodType))
                    {
                        animal.FoodEaten += quantity;
                        animal.EatFood(quantity);
                    }
                    else
                    {
                        Console.WriteLine($"{animal.GetType().Name} does not eat {foodType}!");
                    }
                }

                commandNum++;
                command = Console.ReadLine();
            }

            foreach (var a in animals)
            {
                Console.WriteLine(a.ToString());
            }
        }
    }
}
