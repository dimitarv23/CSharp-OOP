using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.Players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }
        public List<Player> Players
        {
            get { return players; }
            private set
            {
                players = value;
            }
        }
        public int Rating
        {
            get => CalculateRating();
        }


        private int CalculateRating()
        {
            if (this.Players.Count == 0)
            {
                return 0;
            }

            int totalOveralls = this.Players.Sum(p => p.Overall);
            return (int)Math.Round((double)totalOveralls / this.Players.Count);
        }

        public void AddPlayer(Player player)
        {
            if (this.Players.Any(p => p.Name == player.Name))
            {
                throw new ArgumentException($"Player {player.Name} is already in {this.Name} team.");
            }

            this.Players.Add(player);
        }
        public void RemovePlayer(string name)
        {
            if (!this.Players.Any(p => p.Name == name))
            {
                throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            }

            var playerToRemove = this.Players.SingleOrDefault(p => p.Name == name);
            this.Players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
