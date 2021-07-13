
namespace _07_InfernoInfinitySimple.Model
{
    public abstract class Gem : IGem
    {
        protected Gem(Clarity clarity, int strength, int agility, int vitality)
        {
            this.Clarity = clarity;
            this.Strength = strength + (int)Clarity;
            this.Agility = agility + (int)Clarity;
            this.Vitality = vitality + (int)Clarity;
        }

        public int Strength { get; private set; }

        public int Agility { get; private set; }

        public int Vitality { get; private set; }

        public Clarity Clarity { get; private set; }
    }
}
