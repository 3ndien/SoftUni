
namespace PlayersAndMonsters.Models.Cards
{
    using Contracts;

    public class TrapCard : Card, ICard
    {
        private const int DefaultDamagePoint = 120;
        private const int DefauutHealthPoint = 5;

        public TrapCard(string name) 
            : base(name, DefaultDamagePoint, DefauutHealthPoint)
        {
        }
    }
}
