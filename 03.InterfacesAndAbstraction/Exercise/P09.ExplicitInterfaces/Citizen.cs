using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P09.ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        string IPerson.GetName()
        {
            return this.Name;
        }
        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
