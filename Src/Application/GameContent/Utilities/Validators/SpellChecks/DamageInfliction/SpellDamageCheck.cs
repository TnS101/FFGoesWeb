namespace Application.GameContent.Utilities.Validators.SpellChecks.DamageInfliction
{
    using Application.GameContent.Utilities.Validators.Battle;
    using Application.GameContent.Utilities.Validators.SpellChecks.MainStats;
    using Domain.Base;

    public class SpellDamageCheck
    {
        public void Check(Unit caster, Unit target, double manaRequirment, double damage, ManaCheck manaCheck, string damageType, double resistanceAffect)
        {
            damage = new CritCheck().Check(damage, caster.CritChance);

            if (manaCheck.SpellManaCheck(caster, manaRequirment))
            {
                if (damageType == "Physical")
                {
                    double protection = target.CurrentArmorValue * resistanceAffect;

                    if (damage > protection)
                    {
                        damage -= protection;

                        target.CurrentHP -= damage;
                    }
                    else
                    {
                        target.CurrentArmorValue -= target.CurrentArmorValue * 0.3;
                    }
                }
                else if (damageType == "Magical")
                {
                    double protection = target.CurrentResistanceValue * resistanceAffect;

                    if (damage > protection)
                    {
                        damage -= protection;

                        target.CurrentHP -= damage;
                    }
                    else
                    {
                        target.CurrentResistanceValue -= target.CurrentResistanceValue * 0.3;
                    }
                }
                else if (damageType == "Mixed")
                {
                    double protection = (target.CurrentResistanceValue * resistanceAffect / 2) + (target.CurrentArmorValue * resistanceAffect / 2);

                    if (damage > protection)
                    {
                        damage -= protection;

                        target.CurrentHP -= damage;
                    }
                    else
                    {
                        target.CurrentResistanceValue -= target.CurrentResistanceValue * 0.15;
                        target.CurrentArmorValue -= target.CurrentArmorValue * 0.15;
                    }
                }
            }
        }
    }
}
