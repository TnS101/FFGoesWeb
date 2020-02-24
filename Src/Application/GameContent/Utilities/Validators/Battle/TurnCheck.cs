namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.Battle
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers;
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
    using System;
    using System.Threading;

    public class TurnCheck
    {
        public bool Check(Unit player, Unit enemy, BattleHandler battleHandler, IFFDbContext context, bool yourTurn, CancellationToken cancellationToken)
        {
            var rng = new Random();
            if (yourTurn)
            {
                battleHandler.RegenerateOption.Regenerate(player);
                context.SaveChangesAsync(cancellationToken);
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
                context.SaveChangesAsync(cancellationToken);
                return yourTurn = true;
            }
            return true;
        }
    }
}
