using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rnd = new Random();

        public RandomList()
        {
            this.rnd = new Random();
        }

        public string RandomString()
        {
            return this[this.rnd.Next(0, this.Count)];
        }
    }
}
