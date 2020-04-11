namespace Application.GameContent.Utilities.Validators.SpellChecks.DamageInfliction
{
    using Application.GameContent.Utilities.Validators.SpellChecks.MainStats;
    using Domain.Base;

    public class SpellDamageCheck
    {
        public SpellDamageCheck()
        {
        }

        public void Check(Unit caster, Unit target, double manaRequirment, double damage, ManaCheck manaCheck, string damageType)
        {
            if (manaCheck.SpellManaCheck(caster, manaRequirment))
            {
                if (damageType == "Physical")
                {
                    if (damage > target.CurrentArmorValue)
                    {
                        target.CurrentHP -= damage;
                    }
                    else
                    {
                        target.CurrentArmorValue -= target.CurrentArmorValue * 0.3;
                    }
                }
                else if (damageType == "Magical")
                {
                    if (damage > target.CurrentResistanceValue)
                    {
                        target.CurrentHP -= damage;
                    }
                    else
                    {
                        target.CurrentResistanceValue -= target.CurrentResistanceValue * 0.3;
                    }
                }
                else if (damageType == "Mixed")
                {
                    double protection = (target.CurrentResistanceValue / 2) + (target.CurrentArmorValue / 2);

                    if (damage > protection)
                    {
                        target.CurrentHP -= damage;
                    }
                    else
                    {
                        target.CurrentResistanceValue -= target.CurrentResistanceValue * 0.15;
                        target.CurrentArmorValue -= target.CurrentArmorValue * 0.15;
                    }
                }
            }

            if (target.CurrentHP <= damage)
            {
                target.CurrentHP = 0;
            }
        }
    }
}
