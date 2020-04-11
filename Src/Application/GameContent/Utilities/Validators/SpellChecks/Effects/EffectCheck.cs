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
                        caster.CurrentAttackPower += effect * caster.AttackPower;
                    }
                    else if (statType == "hRegen")
                    {
                        caster.CurrentHealthRegen += effect * caster.HealthRegen;
                    }
                    else if (statType == "mRegen")
                    {
                        caster.CurrentManaRegen += effect * caster.ManaRegen;
                    }
                    else if (statType == "Armor")
                    {
                        caster.CurrentArmorValue += effect * caster.ArmorValue;
                    }
                    else if (statType == "Res")
                    {
                        caster.CurrentResistanceValue += effect * caster.ResistanceValue;
                    }
                    else if (statType == "Crit")
                    {
                        caster.CurrentCritChance += effect * caster.CritChance;
                    }
                    else if (statType == "Mana")
                    {
                        caster.CurrentMana += effect * caster.MaxMana;

                        if (caster.CurrentMana > caster.MaxMana)
                        {
                            caster.CurrentMana = caster.MaxMana;
                        }
                    }
                    else if (statType == "Magic")
                    {
                        caster.CurrentMagicPower += effect * caster.MagicPower;
                    }
                    else if (statType == "Health")
                    {
                        caster.CurrentHP += effect * caster.MaxHP;

                        if (caster.CurrentHP > caster.MaxHP)
                        {
                            caster.CurrentHP = caster.MaxHP;
                        }
                    }
                }
                else
                {
                    if (statType == "Attack")
                    {
                        effect *= target.CurrentAttackPower;

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
                        effect *= target.CurrentHealthRegen;

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
                        effect *= target.CurrentManaRegen;

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
                        effect *= target.CurrentArmorValue;

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
                        effect *= target.CurrentResistanceValue;

                        if (target.CurrentResistanceValue < effect)
                        {
                            target.CurrentResistanceValue = 0;
                        }
                        else
                        {
                            target.CurrentResistanceValue -= effect;
                        }
                    }
                    else if (statType == "Health")
                    {
                        effect *= target.CurrentHP;

                        if (target.CurrentHP > effect)
                        {
                            target.CurrentHP -= effect;
                        }
                        else
                        {
                            target.CurrentHP = 0;
                        }
                    }
                    else if (statType == "Mana")
                    {
                        effect *= target.CurrentMana;

                        if (target.CurrentMana > effect)
                        {
                            target.CurrentMana -= effect;
                        }
                        else
                        {
                            target.CurrentMana = 0;
                        }
                    }
                    else if (statType == "Magic")
                    {
                        effect *= target.CurrentMagicPower;

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
