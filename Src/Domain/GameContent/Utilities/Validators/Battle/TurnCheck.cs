namespace FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Validators.Battle
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Handlers;
    using System;

    public class TurnCheck
    {
        public bool Check(Unit player, Unit enemy, BattleHandler battleHandler, IFFDbContext context, bool yourTurn)
        {
            var rng = new Random();
            if (yourTurn)
            {
                battleHandler.RegenerateOption.Regenerate(player);
                context.SaveChanges();
                return yourTurn = false;
            }

            else if (!yourTurn)
            {
                int enemyActionNumber = rng.Next(0, 2);

                if (enemyActionNumber == 0)
                {
                    battleHandler.AttackOption.Attack(enemy, player);
                }
                else if (enemyActionNumber == 1)
                {
                    battleHandler.DefendOption.Defend(enemy);
                }
                else if (enemyActionNumber == 2)
                {
                    battleHandler.SpellCastOption.EnemySpellCast(enemy, player, context);
                }

                battleHandler.RegenerateOption.Regenerate(enemy);
                context.SaveChanges();
                return yourTurn = true;
            }
            return true;
        }
    }
}
