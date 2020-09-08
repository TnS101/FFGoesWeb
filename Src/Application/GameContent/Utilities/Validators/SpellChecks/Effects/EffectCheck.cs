namespace Application.GameContent.Utilities.Validators.SpellChecks.Effects
{
    using Application.GameContent.Utilities.Validators.SpellChecks.MainStats;
    using Domain.Contracts.Units;

    public class EffectCheck
    {
        public void Check(IUnit caster, IUnit target, double manaRequirment,
            double effect, string statType, ManaCheck manaCheck, string effectType)
        {
            if (manaCheck.EffectManaCheck(caster, manaRequirment))
            {
                if (effectType == "Positive")
                {
                    switch (statType)
                    {
                        case "Attack": caster.CurrentAttackPower += effect * caster.AttackPower; break;
                        case "hRegen": caster.CurrentHealthRegen += effect * caster.HealthRegen; break;
                        case "mRegen": caster.CurrentManaRegen += effect * caster.ManaRegen; break;
                        case "Armor": caster.CurrentArmorValue += effect * caster.ArmorValue; break;
                        case "Res": caster.CurrentResistanceValue += effect * caster.ResistanceValue; break;
                        case "Crit": caster.CurrentCritChance += effect * caster.CritChance; break;
                        case "Mana": caster.CurrentMana = this.MaxValidator(caster.CurrentMana, effect, caster.MaxMana); break;
                        case "Magic": caster.CurrentMagicPower += effect * caster.MagicPower; break;
                        case "Health": caster.CurrentHP = this.MaxValidator(caster.CurrentHP, effect, caster.MaxHP); break;
                    }
                }
                else if (effectType == "Negative")
                {
                    switch (statType)
                    {
                        case "Attack": target.CurrentAttackPower = this.NegativeValidator(target.CurrentAttackPower, effect); break;
                        case "hRegen": target.CurrentHealthRegen = this.NegativeValidator(target.CurrentHealthRegen, effect); break;
                        case "mRegen": target.CurrentManaRegen = this.NegativeValidator(target.CurrentManaRegen, effect); break;
                        case "Armor": target.CurrentArmorValue = this.NegativeValidator(target.CurrentArmorValue, effect); break;
                        case "Res": target.CurrentResistanceValue = this.NegativeValidator(target.CurrentResistanceValue, effect); break;
                        case "Crit": target.CurrentCritChance = this.NegativeValidator(target.CurrentCritChance, effect); break;
                        case "Mana": target.CurrentMana = this.NegativeValidator(target.CurrentMana, effect); break;
                        case "Magic": target.CurrentMagicPower = this.NegativeValidator(target.CurrentMagicPower, effect); break;
                        case "Health": target.CurrentHP = this.NegativeValidator(target.CurrentHP, effect); break;
                        case "Stun": target.StunDuration += (int)effect; break;
                        case "Confusion": target.ConfusionDuration += (int)effect; break;
                        case "Provoke": target.ProvokeDuration += (int)effect; break;
                        case "Silence": target.SilenceDuration += (int)effect; break;
                        case "Blind": target.BlindDuration += (int)effect; break;
                    }
                }
            }
        }

        private double MaxValidator(double stat, double effect, double max)
        {
            var sum = stat + (effect * max);

            if (sum > max)
            {
                return max;
            }
            else
            {
                return sum;
            }
        }

        private double NegativeValidator(double stat, double effect)
        {
            double result = 0;

            effect *= stat;

            if (stat > effect)
            {
                result = stat - effect;
            }

            return result;
        }
    }
}
