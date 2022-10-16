using P07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Objects
{
    public class LeutenantGeneral : ILieutenantGeneral
    {
        public LeutenantGeneral(string id, string firstName, string lastName, decimal salary)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Privates = new List<IPrivate>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public List<IPrivate> Privates { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.Append("Privates: ");

            if (this.Privates.Count > 0)
            {
                sb.AppendLine();
            }

            foreach (var @private in this.Privates)
            {
                sb.AppendLine($"  {@private}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
