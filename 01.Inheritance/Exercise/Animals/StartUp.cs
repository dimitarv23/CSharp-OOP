using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string command = Console.ReadLine();

            while (command != "Beast!")
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string name = cmdArgs[0];
                int age = int.Parse(cmdArgs[1]);
                string gender = cmdArgs[2];

                try
                {
                    if (command == "Dog")
                    {
                        var dog = new Dog(name, age, gender);
                        animals.Add(dog);
                    }
                    else if (command == "Frog")
                    {
                        var frog = new Frog(name, age, gender);
                        animals.Add(frog);
                    }
                    else if (command == "Cat")
                    {
                        var cat = new Cat(name, age, gender);
                        animals.Add(cat);
                    }
                    else if (command == "Tomcat")
                    {
                        var tomcat = new Tomcat(name, age);
                        animals.Add(tomcat);
                    }
                    else if (command == "Kitten")
                    {
                        var kitten = new Kitten(name, age);
                        animals.Add(kitten);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                command = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
