using FootballTeamGenerator.Stats;
using System;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;

        private Stat[] stats;

        public Player(string name)
        {
            this.name = name;
            this.stats = new Stat[5];
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

        public double OverallSkill => this.stats.ToList().Average(s => s.Value);

        public void AddStats(params IStat[] statsToBeAdded)
        {
            for (int i = 0; i < statsToBeAdded.Length; i++)
            {
                this.stats[i] = (Stat)statsToBeAdded[i];
            }
        }
    }
}