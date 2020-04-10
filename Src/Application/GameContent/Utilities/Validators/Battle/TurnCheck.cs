namespace Application.GameContent.Utilities.Validators.Battle
{
    using System;
    using Application.Common.Interfaces;
    using Application.GameContent.Handlers;
    using Domain.Base;

    public class TurnCheck
    {
        public bool Check(Unit player, Unit enemy, BattleHandler battleHandler, bool yourTurn, IFFDbContext context)
        {
            var rng = new Random();
            if (yourTurn)
            {
                battleHandler.RegenerateOption.Regenerate(player);
                return false;
            }

            int enemyActionNumber = rng.Next(0, 2);

            if (enemyActionNumber == 0 && enemy.CurrentMana >= 0.15 * enemy.CurrentMana)
            {
                battleHandler.SpellCastOption.EnemySpellCast(enemy, player, context);
            }
            else if (enemyActionNumber == 1)
            {
                battleHandler.AttackOption.Attack(enemy, player);
            }
            else if (enemyActionNumber == 2)
            {
                battleHandler.DefendOption.Defend(enemy);
            }

            battleHandler.RegenerateOption.Regenerate(enemy);
            return true;
        }
    }
}
