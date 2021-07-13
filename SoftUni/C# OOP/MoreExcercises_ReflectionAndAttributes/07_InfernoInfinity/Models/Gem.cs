
using _07_InfernoInfinity.Models.Contracts;

namespace _07_InfernoInfinity.Models
{
    public abstract class Gem : IGem
    {
        private int strength;
        private int agility;
        private int vitality;
        private Clarity clarity;

        protected Gem(int strength, int agility, int vitality, Clarity clarity)
        {
            this.strength = strength;
            this.agility = agility;
            this.vitality = vitality;
            this.clarity = clarity;
        }

        public virtual int Strength
        {
            get { return this.strength + (int)Clarity; }
            private set { this.strength = value; }
        }

        public virtual int Agility
        {
            get { return this.agility + (int)Clarity; }
            private set { this.agility = value; }
        }

        public virtual int Vitality
        {
            get { return this.vitality + (int)Clarity; }
            private set { this.vitality = value; }
        }

        public virtual Clarity Clarity
        {
            get { return this.clarity; }
            private set { this.clarity = value; }
        }
    }
}
