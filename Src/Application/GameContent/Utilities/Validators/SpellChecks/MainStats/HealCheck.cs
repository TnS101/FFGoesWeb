namespace Application.GameContent.Utilities.Validators.SpellChecks.MainStats
{
    using Domain.Base;

    public class HealCheck
    {
        public HealCheck()
        {
        }

        public void Check(Unit caster, Unit target, double manaRequirment, double healEffect, ManaCheck manaCheck)
        {
            if (manaCheck.SpellManaCheck(caster, manaRequirment) == true)
            {
                target.CurrentHP += healEffect;

                if (target.CurrentHP > target.MaxHP)
                {
                    target.CurrentHP = target.MaxHP;
                }
            }
        }
    }
}
