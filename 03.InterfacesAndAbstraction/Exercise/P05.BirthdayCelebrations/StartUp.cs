using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var birthables = new List<IBirthable>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArgs = command.Split();
                string obj = cmdArgs[0];

                IBirthable birthable = null;

                if (obj == "Pet")
                {
                    string petName = cmdArgs[1];
                    string birthdate = cmdArgs[2];

                    birthable = new Pet(petName, birthdate);
                }
                else if (obj == "Citizen")
                {
                    string personName = cmdArgs[1];
                    int age = int.Parse(cmdArgs[2]);
                    string id = cmdArgs[3];
                    string birthdate = cmdArgs[4];

                    birthable = new Citizen(personName, age, id, birthdate);
                }
                else
                {
                    command = Console.ReadLine();
                    continue;
                }

                birthables.Add(birthable);
                command = Console.ReadLine();
            }

            string givenYear = Console.ReadLine();

            foreach (var birthable in birthables
                .Where(b => b.Birthdate.EndsWith(givenYear)))
            {
                Console.WriteLine(birthable.Birthdate);
            }
        }
    }
}
