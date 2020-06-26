namespace Application.GameContent.Utilities.Validators.Battle
{
    using System;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.BattleOptions;
    using AutoMapper;
    using Domain.Contracts.Units;

    public class TurnCheck
    {
        public async Task<bool> Check(IUnit player, IUnit enemy, bool yourTurn, IFFDbContext context, IMapper mapper)
        {
            var regenerationOption = new RegenerateOption();

            if (yourTurn)
            {
                regenerationOption.Regenerate(player);
                this.DurationDecrement(player);

                return false;
            }

            if (enemy.StunDuration == 0)
            {
                int enemyActionNumber = new Random().Next(3);

                if (enemyActionNumber == 0 && enemy.CurrentMana >= 0.15 * enemy.CurrentMana && enemy.SilenceDuration == 0)
                {
                    await new SpellCastOption().SpellCast(enemy, player, 0, context, mapper);
                }
                else if (enemyActionNumber == 1 && enemy.BlindDuration == 0)
                {
                    new AttackOption().Attack(enemy, player);
                }
                else if (enemyActionNumber == 2 && enemy.ProvokeDuration == 0)
                {
                    new DefendOption().Defend(enemy);
                }
            }
            else
            {
                this.DurationDecrement(enemy);
            }

            regenerationOption.Regenerate(enemy);
            return true;
        }

        private void DurationDecrement(IUnit unit)
        {
            unit.StunDuration = unit.StunDuration > 0 ? unit.StunDuration -= 1 : 0;
            unit.SilenceDuration = unit.SilenceDuration > 0 ? unit.SilenceDuration -= 1 : 0;
            unit.BlindDuration = unit.BlindDuration > 0 ? unit.BlindDuration -= 1 : 0;
            unit.ProvokeDuration = unit.ProvokeDuration > 0 ? unit.ProvokeDuration -= 1 : 0;
            unit.ConfusionDuration = unit.ConfusionDuration > 0 ? unit.ConfusionDuration -= 1 : 0;
        }
    }
}
