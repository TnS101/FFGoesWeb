namespace Application.GameContent.Utilities.Validators.Battle
{
    using System;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.BattleOptions;
    using Domain.Base;

    public class TurnCheck
    {
        public TurnCheck()
        {
        }

        public async Task<bool> Check(Unit player, Unit enemy, bool yourTurn, IFFDbContext context)
        {
            var rng = new Random();

            var regenerationOption = new RegenerateOption();

            if (yourTurn)
            {
                regenerationOption.Regenerate(player);
                return false;
            }

            int enemyActionNumber = rng.Next(0, 2);

            if (enemyActionNumber == 0 && enemy.CurrentMana >= 0.15 * enemy.CurrentMana)
            {
                var spellCastOption = new SpellCastOption();

                await spellCastOption.SpellCast(enemy, player, string.Empty, context);
            }
            else if (enemyActionNumber == 1)
            {
                var attackOption = new AttackOption();

                attackOption.Attack(enemy, player);
            }
            else if (enemyActionNumber == 2)
            {
                var defendOption = new DefendOption();

                defendOption.Defend(enemy);
            }

            regenerationOption.Regenerate(enemy);
            return true;
        }
    }
}
