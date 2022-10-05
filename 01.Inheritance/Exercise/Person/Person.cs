using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative!");
                }

                age = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"Name: {this.Name}, Age: {this.Age}");

            return sb.ToString();
        }
    }
}
