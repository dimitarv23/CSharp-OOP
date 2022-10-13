using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var canBeIdentified = new List<IIdentifiable>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArgs = command.Split();

                IIdentifiable identifiable = null;

                if (cmdArgs.Length == 2)
                {
                    string robotModel = cmdArgs[0];
                    string id = cmdArgs[1];

                    identifiable = new Robot(robotModel, id);
                }
                else if (cmdArgs.Length == 3)
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];

                    identifiable = new Citizen(name, age, id);
                }

                canBeIdentified.Add(identifiable);
                command = Console.ReadLine();
            }

            string fakeIdEnding = Console.ReadLine();

            foreach (var fakeId in canBeIdentified
                .Where(i => i.Id.EndsWith(fakeIdEnding)))
            {
                Console.WriteLine(fakeId.Id);
            }
        }
    }
}
