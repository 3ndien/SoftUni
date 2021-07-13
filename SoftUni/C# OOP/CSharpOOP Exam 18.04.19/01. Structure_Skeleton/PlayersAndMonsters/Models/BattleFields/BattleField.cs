namespace PlayersAndMonsters.Models.BattleFields
{
    using Cards.Contracts;
    using Contracts;
    using Players;
    using Players.Contracts;

    using System;
    using System.Linq;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer is Beginner)
            {
                attackPlayer.Health += 40;

                foreach (ICard card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            if (enemyPlayer is Beginner)
            {
                enemyPlayer.Health += 40;

                foreach (ICard card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            int attackPlayerBonusHP = attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
            int enemyPlayerBonusHP = enemyPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);

            attackPlayer.Health += attackPlayerBonusHP;
            enemyPlayer.Health += enemyPlayerBonusHP;

            int totalAttackerDamage = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
            int totalEnemyDamage = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);

            while (true)
            {
                enemyPlayer.TakeDamage(totalAttackerDamage);

                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                attackPlayer.TakeDamage(totalEnemyDamage);

                if (attackPlayer.Health == 0)
                {
                    break;
                }
            }
        }
    }
}
