namespace Application.GameContent.Utilities.Validators.Battle
{
    using System;
    using Application.Common.Interfaces;
    using Application.GameContent.Handlers;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;

    public class TurnCheck
    {
        public bool Check(UnitFullViewModel player, UnitFullViewModel enemy, BattleHandler battleHandler, bool yourTurn, IFFDbContext context)
        {
            var rng = new Random();
            if (yourTurn)
            {
                battleHandler.RegenerateOption.Regenerate(player);
                return false;
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
                return true;
            }

            return true;
        }
    }
}
