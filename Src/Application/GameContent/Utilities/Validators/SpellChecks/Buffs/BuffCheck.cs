namespace Application.GameContent.Utilities.Validators.SpellChecks.Buffs
{
    using Application.GameContent.Utilities.Validators.SpellChecks.MainStats;
    using Domain.Base;

    public class BuffCheck
    {
        public BuffCheck()
        {
        }

        public void Check(Unit caster, Unit target, double manaRequirment, double buffEffect, string buffStat, ManaCheck manaCheck, string buffType)
        {
            if (manaCheck.SpellManaCheck(caster, manaRequirment))
            {
                if (buffType == "Positive")
                {
                    if (buffStat == "Attack")
                    {
                        caster.CurrentAttackPower += buffEffect * caster.AttackPower;
                    }
                    else if (buffStat == "hRegen")
                    {
                        caster.CurrentHealthRegen += buffEffect * caster.HealthRegen;
                    }
                    else if (buffStat == "mRegen")
                    {
                        caster.CurrentManaRegen += buffEffect * caster.ManaRegen;
                    }
                    else if (buffStat == "Armor")
                    {
                        caster.CurrentArmorValue += buffEffect * caster.ArmorValue;
                    }
                    else if (buffStat == "Res")
                    {
                        caster.CurrentResistanceValue += buffEffect * caster.ResistanceValue;
                    }
                    else if (buffStat == "Mana")
                    {
                        caster.CurrentMana += buffEffect * caster.MaxMana;
                    }
                    else if (buffStat == "Gold")
                    {
                        buffEffect *= caster.Level;

                        caster.GoldAmount += (int)buffEffect;
                    }
                    else if (buffStat == "Magic")
                    {
                        caster.CurrentMagicPower += buffEffect * caster.GoldAmount;
                    }
                }
                else
                {
                    if (buffStat == "Attack")
                    {
                        if (target.CurrentAttackPower < buffEffect)
                        {
                            target.CurrentAttackPower = 0;
                        }
                        else
                        {
                            target.CurrentAttackPower -= buffEffect;
                        }
                    }
                    else if (buffStat == "hRegen")
                    {
                        if (target.CurrentHealthRegen < buffEffect)
                        {
                            target.CurrentHealthRegen = 0;
                        }
                        else
                        {
                            target.CurrentHealthRegen -= buffEffect * target.CurrentHealthRegen;
                        }
                    }
                    else if (buffStat == "mRegen")
                    {
                        if (target.CurrentManaRegen < buffEffect)
                        {
                            target.CurrentManaRegen = 0;
                        }
                        else
                        {
                            target.CurrentManaRegen -= buffEffect * target.CurrentManaRegen;
                        }
                    }
                    else if (buffStat == "Armor")
                    {
                        if (target.CurrentArmorValue < buffEffect)
                        {
                            target.CurrentArmorValue = 0;
                        }
                        else
                        {
                            target.CurrentArmorValue -= buffEffect * target.CurrentArmorValue;
                        }
                    }
                    else if (buffStat == "Res")
                    {
                        if (target.CurrentResistanceValue < buffEffect)
                        {
                            target.CurrentResistanceValue = 0;
                        }
                        else
                        {
                            target.CurrentResistanceValue -= buffEffect * target.CurrentResistanceValue;
                        }
                    }
                    else if (buffStat == "Health")
                    {
                        if (caster.CurrentHP > buffEffect)
                        {
                            caster.CurrentHP -= buffEffect;
                        }
                    }
                    else if (buffStat == "Magic")
                    {
                        if (target.CurrentMagicPower < buffEffect)
                        {
                            target.CurrentMagicPower = 0;
                        }
                        else
                        {
                            target.CurrentMagicPower -= buffEffect * target.CurrentMagicPower;
                        }
                    }
                    else if (buffStat == "Mana")
                    {
                        if (target.CurrentMana < buffEffect)
                        {
                            target.CurrentMana = 0;
                        }
                        else
                        {
                            target.CurrentMana -= buffEffect * target.MaxMana;
                        }
                    }
                }
            }
        }
    }
}
