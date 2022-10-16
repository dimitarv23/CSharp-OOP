using P07.MilitaryElite.Models;
using P07.MilitaryElite.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var soldiers = new List<ISoldier>();
            var privates = new List<IPrivate>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string title = cmdArgs[0];

                string id = cmdArgs[1];
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];

                if (title == "Private")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    var currPrivate = new Private(id, firstName, lastName, salary);

                    privates.Add(currPrivate);
                    soldiers.Add(currPrivate);
                }
                else if (title == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string[] privateIds = cmdArgs.Skip(5).ToArray();

                    var currLieutenant = new LeutenantGeneral(id, firstName, lastName, salary);

                    foreach (var privateId in privateIds)
                    {
                        var privateToAdd = privates.Single(p => p.Id == privateId);
                        currLieutenant.Privates.Add(privateToAdd);
                    }

                    soldiers.Add(currLieutenant);
                }
                else if (title == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    string[] repairsInfo = cmdArgs.Skip(6).ToArray();

                    var currEngineer = new Engineer(id, firstName, lastName, salary, corps);

                    if (corps != "Airforces" && corps != "Marines")
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    for (int i = 0; i < repairsInfo.Length; i += 2)
                    {
                        string repairPart = repairsInfo[i];
                        int repairHours = int.Parse(repairsInfo[i + 1]);

                        Repair repair = new Repair(repairPart, repairHours);
                        currEngineer.Repairs.Add(repair);
                    }

                    soldiers.Add(currEngineer);
                }
                else if (title == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    string[] missionsInfo = cmdArgs.Skip(6).ToArray();

                    var currCommando = new Commando(id, firstName, lastName, salary, corps);

                    if (corps != "Airforces" && corps != "Marines")
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    for (int i = 0; i < missionsInfo.Length; i += 2)
                    {
                        string missionCodeName = missionsInfo[i];
                        string missionState = missionsInfo[i + 1];

                        if (missionState != "inProgress" && missionState != "Finished")
                        {
                            continue;
                        }

                        Mission mission = new Mission(missionCodeName, missionState);
                        currCommando.Missions.Add(mission);
                    }

                    soldiers.Add(currCommando);
                }
                else if (title == "Spy")
                {
                    int codeNumber = int.Parse(cmdArgs[4]);

                    var currSpy = new Spy(id, firstName, lastName, codeNumber);

                    soldiers.Add(currSpy);
                }

                command = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
