namespace Application.GameContent.Utilities.Validators.Battle
{
    using System;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.BattleOptions;
    using Domain.Contracts.Units;

    public class TurnCheck
    {
        public async Task<bool> Check(IUnit player, IUnit enemy, bool yourTurn, IFFDbContext context)
        {
            var regenerationOption = new RegenerateOption();

            if (yourTurn)
            {
                regenerationOption.Regenerate(player);
                return false;
            }

            int enemyActionNumber = new Random().Next(0, 2);

            if (enemyActionNumber == 0 && enemy.CurrentMana >= 0.15 * enemy.CurrentMana)
            {
                await new SpellCastOption().SpellCast(enemy, player, 0, context);
            }
            else if (enemyActionNumber == 1)
            {
                new AttackOption().Attack(enemy, player);
            }
            else if (enemyActionNumber == 2)
            {
                new DefendOption().Defend(enemy);
            }

            regenerationOption.Regenerate(enemy);
            return true;
        }
    }
}
