using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public virtual string Name 
        { 
            get { return this.name; }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new Exception("Invalid input!");
                }

                this.name = value;
            }
        }
        public virtual int Age 
        { 
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Invalid input!");
                }

                this.age = value;
            }
        }
        public virtual string Gender 
        { 
            get { return this.gender; }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new Exception("Invalid input!");
                }

                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}
