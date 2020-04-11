namespace Application.GameContent.Utilities.BattleOptions
{
    using System;
    using Domain.Base;

    public class AttackOption
    {
        public AttackOption()
        {
        }

        public void Attack(Unit caster, Unit target)
        {
            Random rng = new Random();

            int critNumber = rng.Next(0, 100);

            double initialAttackPower = caster.CurrentAttackPower;

            if (critNumber > 0 && critNumber < Math.Floor(caster.CritChance))
            {
                caster.CurrentAttackPower *= 2;
            }

            if (target.CurrentHP > 0)
            {
                if (target.CurrentArmorValue >= caster.CurrentAttackPower)
                {
                    double armorPenalty = 0;
                    if (target.ClassType != null)
                    {
                        armorPenalty += 0.80;
                    }
                    else
                    {
                        armorPenalty += 0.50;
                    }

                    target.CurrentArmorValue -= armorPenalty * target.CurrentArmorValue;
                }
                else
                {
                    target.CurrentHP -= caster.CurrentAttackPower - target.CurrentArmorValue;
                }
            }
            else
            {
                target.CurrentHP = 0;
            }

            caster.CurrentAttackPower = initialAttackPower;
        }
    }
}
