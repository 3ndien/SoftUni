using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;

        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public IReadOnlyCollection<Player> Players
        {
            get { return this.players.AsReadOnly(); }
        }

        public int Rating => (int)Math.Round(this.players.Select(p => p.OverallSkill).Sum());

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            this.players.Remove(player);
        }
    }
}
