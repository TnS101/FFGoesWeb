namespace Application.GameContent.Utilities.Validators.SpellChecks.Buffs
{
    using Application.GameContent.Utilities.Validators.SpellChecks.MainStats;
    using Domain.Contracts.Units;

    public class BuffCheck
    {
        public void Check(IUnit caster, IUnit target, double manaRequirment, double buffEffect, string buffStat, ManaCheck manaCheck, string buffType)
        {
            if (manaCheck.SpellManaCheck(caster, manaRequirment))
            {
                if (buffType == "Positive")
                {
                    switch (buffStat)
                    {
                        case "Attack": caster.CurrentAttackPower += buffEffect * caster.AttackPower; break;
                        case "hRegen": caster.CurrentHealthRegen += buffEffect * caster.HealthRegen; break;
                        case "mRegen": caster.CurrentManaRegen += buffEffect * caster.ManaRegen; break;
                        case "Armor": caster.CurrentArmorValue += buffEffect * caster.ArmorValue; break;
                        case "Res": caster.CurrentResistanceValue += buffEffect * caster.ResistanceValue; break;
                        case "Mana": caster.CurrentMana = caster.CurrentMana + (buffEffect * caster.MaxMana) > caster.MaxMana ? caster.MaxMana : caster.CurrentMana + (buffEffect * caster.MaxMana); break;
                        case "Gold": caster.CoinAmount += (int)(buffEffect * caster.Level); break;
                        case "Magic": caster.CurrentMagicPower += buffEffect * caster.MagicPower; break;
                    }
                }
                else
                {
                    switch (buffStat)
                    {
                        case "Attack": target.CurrentAttackPower = this.NegativeValidator(target.CurrentAttackPower, buffEffect); break;
                        case "hRegen": target.CurrentHealthRegen = this.NegativeValidator(target.CurrentHealthRegen, buffEffect); break;
                        case "mRegen": target.CurrentManaRegen = this.NegativeValidator(target.CurrentManaRegen, buffEffect); break;
                        case "Armor": target.CurrentArmorValue = this.NegativeValidator(target.CurrentArmorValue, buffEffect); break;
                        case "Res": target.CurrentResistanceValue = this.NegativeValidator(target.CurrentResistanceValue, buffEffect); break;
                        case "Mana": target.CurrentMana = this.NegativeValidator(target.CurrentMana, buffEffect); break;
                        case "Magic": target.CurrentMagicPower = this.NegativeValidator(target.CurrentMagicPower, buffEffect); break;
                        case "Health": target.CurrentHP = this.NegativeValidator(target.CurrentHP, buffEffect); break;
                    }
                }
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
