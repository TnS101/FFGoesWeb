namespace Application.GameContent.Utilities.Validators.SpellChecks.DamageInfliction
{
    using Domain.Base;
    using Application.GameContent.Utilities.Validators.SpellChecks.MainStats;

    public class PhysicalDamageCheck
    {
        public void Check(Unit caster, Unit target, double manaRequirment, double damage, string spellName, ManaCheck manaCheck)
        {
            if (manaCheck.SpellManaCheck(caster, manaRequirment) == true)
            {
                if (damage > target.CurrentArmorValue)
                {
                    target.CurrentHP -= damage;
                    if (target.CurrentHP <= damage)
                    {
                        target.CurrentHP = 0;
                    }
                }
                else
                {
                    target.CurrentArmorValue -= target.CurrentArmorValue * 0.25;
                }
            }
        }
    }
}
