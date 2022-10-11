using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] cmdArgs = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                string teamName = cmdArgs[1];

                try
                {
                    if (action == "Team")
                    {
                        if (!teams.Any(t => t.Name == teamName))
                        {
                            var team = new Team(teamName);
                            teams.Add(team);
                        }
                    }
                    else if (action == "Add")
                    {
                        DoesTeamExist(teams, teamName);

                        var team = teams.SingleOrDefault(t => t.Name == teamName);

                        string playerName = cmdArgs[2];
                        int endurance = int.Parse(cmdArgs[3]);
                        int sprint = int.Parse(cmdArgs[4]);
                        int dribble = int.Parse(cmdArgs[5]);
                        int passing = int.Parse(cmdArgs[6]);
                        int shooting = int.Parse(cmdArgs[7]);
                        var playerToAdd = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        team.AddPlayer(playerToAdd);
                    }
                    else if (action == "Remove")
                    {
                        string playerName = cmdArgs[2];
                        DoesTeamExist(teams, teamName);

                        var team = teams.SingleOrDefault(t => t.Name == teamName);
                        team.RemovePlayer(playerName);
                    }
                    else if (action == "Rating")
                    {
                        DoesTeamExist(teams, teamName);

                        var team = teams.SingleOrDefault(t => t.Name == teamName);
                        Console.WriteLine(team);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                command = Console.ReadLine();
            }
        }

        static void DoesTeamExist(List<Team> teams, string teamName)
        {
            if (!teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }
    }
}
