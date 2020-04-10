namespace Application.GameContent.Utilities.Validators.SpellChecks.Effects
{
    using Application.GameContent.Utilities.Validators.SpellChecks.MainStats;
    using Domain.Base;

    public class EffectCheck
    {
        public EffectCheck()
        {
        }

        public void Check(Unit caster, Unit target, double manaRequirment,
            double effect, string statType, ManaCheck manaCheck, string effectType)
        {
            if (manaCheck.EffectManaCheck(caster, manaRequirment))
            {
                if (effectType == "Positive")
                {
                    if (statType == "Attack")
                    {
                        caster.CurrentAttackPower += effect;
                    }
                    else if (statType == "hRegen")
                    {
                        caster.CurrentHealthRegen += (int)effect;
                    }
                    else if (statType == "mRegen")
                    {
                        caster.CurrentManaRegen += (int)effect;
                    }
                    else if (statType == "Armor")
                    {
                        caster.CurrentArmorValue += effect;
                    }
                    else if (statType == "Res")
                    {
                        caster.CurrentArmorValue += effect;
                    }
                    else if (statType == "Crit")
                    {
                        caster.CurrentCritChance += effect;
                    }
                    else if (statType == "Mana")
                    {
                        if (caster.CurrentMana <= effect)
                        {
                            caster.CurrentMana += effect;
                        }
                    }
                    else if (statType == "Magic")
                    {
                        caster.CurrentMagicPower += effect;
                    }
                    else if (statType == "Health")
                    {
                        if (caster.CurrentHP <= effect)
                        {
                            caster.CurrentHP += effect;
                        }
                    }
                }
                else
                {
                    if (statType == "Attack")
                    {
                        if (target.CurrentAttackPower < effect)
                        {
                            target.CurrentAttackPower = 0;
                        }
                        else
                        {
                            target.CurrentAttackPower -= effect;
                        }
                    }
                    else if (statType == "hRegen")
                    {
                        if (target.CurrentHealthRegen < effect)
                        {
                            target.CurrentHealthRegen = 0;
                        }
                        else
                        {
                            target.CurrentHealthRegen -= effect;
                        }
                    }
                    else if (statType == "mRegen")
                    {
                        if (target.CurrentManaRegen < effect)
                        {
                            target.CurrentManaRegen = 0;
                        }
                        else
                        {
                            target.CurrentManaRegen -= effect;
                        }
                    }
                    else if (statType == "Armor")
                    {
                        if (target.CurrentArmorValue < effect)
                        {
                            target.CurrentArmorValue = 0;
                        }
                        else
                        {
                            target.CurrentArmorValue -= effect;
                        }
                    }
                    else if (statType == "Res")
                    {
                        if (target.CurrentResistanceValue < effect)
                        {
                            target.CurrentResistanceValue = 0;
                        }
                        else
                        {
                            target.CurrentResistanceValue -= effect;
                        }
                    }
                    else if (statType == "SelfHP")
                    {
                        caster.CurrentHP -= effect;
                    }
                    else if (statType == "Damage")
                    {
                        if (target.CurrentHP > effect)
                        {
                            target.CurrentHP -= effect;
                        }
                    }
                    else if (statType == "Mana")
                    {
                        if (target.CurrentMana > effect)
                        {
                            target.CurrentMana -= effect;
                        }
                    }
                    else if (statType == "Magic")
                    {
                        if (target.CurrentMagicPower > effect)
                        {
                            target.CurrentMagicPower -= effect;
                        }
                    }
                }
            }
        }
    }
}
