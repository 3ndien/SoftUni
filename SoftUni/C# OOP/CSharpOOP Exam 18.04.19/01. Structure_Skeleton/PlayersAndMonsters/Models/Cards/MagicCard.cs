
namespace PlayersAndMonsters.Models.Cards
{
    using Contracts;

    public class MagicCard : Card, ICard
    {
        private const int DefaultDamagePoints = 5;
        private const int DefaultHealthPoints = 80;

        public MagicCard(string name) 
            : base(name, DefaultDamagePoints, DefaultHealthPoints)
        {
        }
    }
}
