namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.SpellChecks.Effects
{
    using Domain.Base;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.SpellChecks.MainStats;

    public class NegativeEffectCheck
    {
        public void Check(Unit caster, Unit target, double manaRequirment,
            double negativeEffect, string negativeEffectType, ManaCheck manaCheck)
        {
            if (manaCheck.EffectManaCheck(caster, manaRequirment) == true)
            {
                if (negativeEffectType == "Attack")
                {
                    if (target.CurrentAttackPower < negativeEffect)
                    {
                        target.CurrentAttackPower = 0;
                    }
                    else
                    {
                        target.CurrentAttackPower -= negativeEffect;
                    }
                }
                else if (negativeEffectType == "hRegen")
                {
                    if (target.CurrentHealthRegen < (int)negativeEffect)
                    {
                        target.CurrentHealthRegen = 0;
                    }
                    else
                    {
                        target.CurrentHealthRegen -= (int)negativeEffect;
                    }
                }
                else if (negativeEffectType == "mRegen")
                {
                    if (target.CurrentManaRegen < (int)negativeEffect)
                    {
                        target.CurrentManaRegen = 0;
                    }
                    else
                    {
                        target.CurrentManaRegen -= (int)negativeEffect;
                    }
                }
                else if (negativeEffectType == "Armor")
                {
                    if (target.CurrentArmorValue < negativeEffect)
                    {
                        target.CurrentArmorValue = 0;
                    }
                    else
                    {
                        target.CurrentArmorValue -= negativeEffect;
                    }
                }
                else if (negativeEffectType == "Res")
                {
                    if (target.CurrentRessistanceValue < negativeEffect)
                    {
                        target.CurrentRessistanceValue = 0;
                    }
                    else
                    {
                        target.CurrentRessistanceValue -= negativeEffect;
                    }
                }
                else if (negativeEffectType == "SelfHP")
                {
                    caster.CurrentHP -= negativeEffect;
                }
                else if (negativeEffectType == "Damage")
                {
                    if (target.CurrentHP > negativeEffect)
                    {
                        target.CurrentHP -= negativeEffect;
                    }
                }
                else if (negativeEffectType == "Mana")
                {
                    if (target.CurrentMana > negativeEffect)
                    {
                        target.CurrentMana -= negativeEffect;
                    }
                }
                else if (negativeEffectType == "Magic")
                {
                    if (target.CurrentMagicPower > negativeEffect)
                    {
                        target.CurrentMagicPower -= negativeEffect;
                    }
                }
            }
        }
    }
}
