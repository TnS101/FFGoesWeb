﻿namespace Application.GameContent.Utilities.Validators.SpellChecks.MainStats
{
    using Domain.Base;

    public class ManaCheck
    {
        public ManaCheck()
        {
        }

        public bool SpellManaCheck(Unit caster, double manaRequirment)
        {
            if (caster.CurrentMana >= manaRequirment)
            {
                caster.CurrentMana -= manaRequirment;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EffectManaCheck(Unit caster, double manaRequirment)
        {
            if (caster.CurrentMana >= manaRequirment)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
