using P07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Objects
{
    public class Commando : ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Corps = corps;
            this.Missions = new List<IMission>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string Corps { get; set; }
        public List<IMission> Missions { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.Append("Missions: ");

            if (this.Missions.Count > 0)
            {
                sb.AppendLine();
            }

            foreach (var mission in this.Missions)
            {
                sb.AppendLine("  " + mission.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
