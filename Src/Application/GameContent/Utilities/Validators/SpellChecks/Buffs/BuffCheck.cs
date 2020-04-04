﻿namespace Application.GameContent.Utilities.Validators.SpellChecks.Buffs
{
    using Domain.Base;
    using Application.GameContent.Utilities.Validators.SpellChecks.MainStats;

    public class BuffCheck
    {
        public void Check(Unit caster, Unit target, double manaRequirment, double buffEffect, string spellName, string buffType, ManaCheck manaCheck)
        {
            if (manaCheck.SpellManaCheck(caster, manaRequirment) == true)
            {
                if (buffType == "Attack")
                {
                    caster.CurrentAttackPower += buffEffect;
                }
                else if (buffType == "hRegen")
                {
                    caster.CurrentHealthRegen += (int)buffEffect;
                }
                else if (buffType == "mRegen")
                {
                    caster.CurrentManaRegen += (int)buffEffect;
                }
                else if (buffType == "Armor")
                {
                    caster.CurrentArmorValue += buffEffect;
                }
                else if (buffType == "Res")
                {
                    caster.CurrentRessistanceValue += buffEffect;
                }
                else if (buffType == "Mana")
                {
                    caster.CurrentMana += buffEffect;
                }
                else if (buffType == "Gold")
                {
                    caster.GoldAmount += (int)buffEffect;
                }
                else if (buffType == "Magic")
                {
                    caster.CurrentMagicPower += buffEffect;
                }
            }
        }
    }
}
