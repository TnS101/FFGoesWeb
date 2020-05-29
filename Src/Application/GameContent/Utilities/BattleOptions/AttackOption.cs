﻿namespace Application.GameContent.Utilities.BattleOptions
{
    using Application.GameContent.Utilities.Validators.Battle;
    using Domain.Base;

    public class AttackOption
    {
        public void Attack(Unit caster, Unit target)
        {
            target.CurrentAttackPower = new CritCheck().Check(caster.CurrentAttackPower, caster.CritChance);

            if (target.CurrentHP > 0)
            {
                if (target.CurrentArmorValue >= caster.CurrentAttackPower)
                {
                    if (target.Type == "Player")
                    {
                        target.CurrentArmorValue -= 0.3 * target.CurrentArmorValue;
                    }
                    else
                    {
                        target.CurrentArmorValue -= 0.7 * target.CurrentArmorValue;
                    }
                }
                else
                {
                    target.CurrentHP -= caster.CurrentAttackPower - target.CurrentArmorValue;
                }
            }
        }
    }
}
