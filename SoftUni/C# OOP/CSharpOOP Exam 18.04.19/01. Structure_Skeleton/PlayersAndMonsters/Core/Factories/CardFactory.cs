namespace PlayersAndMonsters.Core.Factories
{
    using Contracts;
    using Models.Cards.Contracts;

    using System;
    using System.Linq;
    using System.Reflection;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            string cardClassName = type + "Card";

            Type cardType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == cardClassName);

            if (cardType == null)
            {
                throw new ArgumentException("Card of this type does not exists!");
            }

            ICard card = (ICard)Activator.CreateInstance(cardType, name);
            return card;
        }
    }
}
