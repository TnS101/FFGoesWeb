﻿namespace Application.GameContent.Utilities.Validators.SpellChecks.MainStats
{
    using Domain.Contracts.Units;

    public class HealCheck
    {
        public void Check(IUnit caster, IUnit target, double manaRequirment, double healEffect, ManaCheck manaCheck)
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
