using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        private string username;
        private int level;

        public Hero(string name, int level)
        {
            this.Username = name;
            this.Level = level;
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
