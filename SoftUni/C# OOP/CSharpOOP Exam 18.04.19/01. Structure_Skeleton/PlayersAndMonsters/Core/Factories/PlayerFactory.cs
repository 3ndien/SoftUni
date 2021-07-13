namespace PlayersAndMonsters.Core.Factories
{
    using Factories.Contracts;
    using Models.Players.Contracts;
    using Repositories;

    using System;
    using System.Linq;
    using System.Reflection;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            Type typePlayer = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (typePlayer == null)
            {
                throw new ArgumentException("Player of this type does not exists!");
            }

            IPlayer player = (IPlayer)Activator.CreateInstance(typePlayer, new object[] { new CardRepository(), username });
            return player;
        }
    }
}
