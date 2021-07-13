namespace PlayersAndMonsters.Core
{
    using Contracts;
    using Factories.Contracts;
    using Common;
    using Models.Cards.Contracts;
    using Models.Players.Contracts;
    using Repositories.Contracts;
    using Models.BattleFields.Contracts;

    using System.Text;

    public class ManagerController : IManagerController
    {
        private readonly IPlayerRepository playerRepository;
        private readonly IPlayerFactory playerFactory;
        private readonly ICardRepository cardRepository;
        private readonly ICardFactory cardFactory;
        private readonly IBattleField battleField;

        public ManagerController(IPlayerRepository playerRepository, 
            IPlayerFactory playerFactory, 
            ICardRepository cardRepository, 
            ICardFactory cardFactory, 
            IBattleField battleField)
        {
            this.playerRepository = playerRepository;
            this.playerFactory = playerFactory;
            this.cardRepository = cardRepository;
            this.cardFactory = cardFactory;
            this.battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);
            this.playerRepository.Add(player);

            string result = string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, player.Username);
            return result;
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);
            this.cardRepository.Add(card);

            string result = string.Format(ConstantMessages.SuccessfullyAddedCard, card.GetType().Name, card.Name);
            return result;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Find(username);
            ICard card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            string result = string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, card.Name, player.Username);
            return result;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = this.playerRepository.Find(attackUser);
            IPlayer enemyPlayer = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attackPlayer, enemyPlayer);

            string result = string.Format(ConstantMessages.FightInfo, attackPlayer.Health, enemyPlayer.Health);
            return result;
        }

        public string Report()
        {
            var result = new StringBuilder();

            foreach (IPlayer player in this.playerRepository.Players)
            {
                result.
                    AppendLine(
                    string.Format(
                        ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));

                foreach (ICard card in player.CardRepository.Cards)
                {
                    result.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }

                result.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return result.ToString().TrimEnd();
        }
    }
}
