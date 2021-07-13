
using System;

namespace FootballTeamGenerator.Stats
{
    public abstract class Stat : IStat
    {
        private int value;

        public Stat(int value)
        {
            Value = value;
        }

        public virtual int Value
        {
            get { return this.value; }
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{this.GetType().Name.ToString()} should be between 0 and 100.");
                }
                this.value = value;
            }
        }
    }
}
