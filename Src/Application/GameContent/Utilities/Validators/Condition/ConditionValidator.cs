namespace Application.GameContent.Utilities.Validators.Condition
{
    using System.Collections.Generic;
    using Domain.Contracts.Units;
    using Domain.Entities.Game.Units;

    public class ConditionValidator
    {
        public ConditionValidator()
        {
        }

        public void Process(Spell spell, IUnit caster, IUnit target, string cardCondition, string talentCondition, bool preview)
        {
            // Enemy,CurrentHP,>,10%,Spell,Power,+,10%
            if (cardCondition != null)
            {
                spell.Condition += $"/{cardCondition}";
            }

            if (talentCondition != null)
            {
                spell.Condition += $"/{talentCondition}";
            }

            var conditions = new List<string>();

            if (spell.Condition.Contains("/"))
            {
                conditions.AddRange(spell.Condition.Split('/'));
            }
            else
            {
                conditions.Add(spell.Condition);
            }

            foreach (var condition in conditions)
            {
                var info = condition.Split(',');
                var conditionTarget = info[0];
                var conditionValueType = info[1];
                var comparator = info[2];
                var conditionValue = double.Parse(info[3]) / 100;

                var completionTarget = info[4];
                var completionValueType = info[5];
                var completionOperator = info[6];
                var completionValue = double.Parse(info[7]) / 100;

                if (conditionTarget == "Enemy" && !this.ConditionIsSatisfied(target, conditionValueType, conditionValue, comparator))
                {
                    return;
                }
                else if (conditionTarget == "Self" && !this.ConditionIsSatisfied(caster, conditionValueType, conditionValue, comparator))
                {
                    return;
                }

                if (preview == true)
                {
                    spell.SatisfiesCondition = true;
                    return;
                }

                switch (completionTarget)
                {
                    case "Spell": this.ConditionCompletion(completionValueType, completionValue, completionOperator, null, spell); break;
                    case "Enemy": this.ConditionCompletion(completionValueType, completionValue, completionOperator, target, null); break;
                    case "Self": this.ConditionCompletion(completionValueType, completionValue, completionOperator, caster, null); break;
                }
            }
        }

        private bool ConditionIsSatisfied(IUnit target, string conditionValueType, double conditionValue, string comparator)
        {
            switch (conditionValueType)
            {
                case "CurrentHP": if (this.ConditionValueComparison(target.CurrentHP, comparator, conditionValue)) return true; break;
                case "CurrentMana": if (this.ConditionValueComparison(target.CurrentMana, comparator, conditionValue)) return true; break;
                case "CurrentArmor": if (this.ConditionValueComparison(target.CurrentArmorValue, comparator, conditionValue)) return true; break;
                case "CurrentResistance": if (this.ConditionValueComparison(target.CurrentResistanceValue, comparator, conditionValue)) return true; break;
                case "CurrentHealthRegen": if (this.ConditionValueComparison(target.CurrentHealthRegen, comparator, conditionValue)) return true; break;
                case "CurrentManaRegen": if (this.ConditionValueComparison(target.CurrentManaRegen, comparator, conditionValue)) return true; break;
                case "CurrentCritChance": if (this.ConditionValueComparison(target.CurrentCritChance, comparator, conditionValue)) return true; break;
                case "CurrentAttackPower": if (this.ConditionValueComparison(target.CurrentAttackPower, comparator, conditionValue)) return true; break;
                case "CurrentMagicPower": if (this.ConditionValueComparison(target.CurrentMagicPower, comparator, conditionValue)) return true; break;
            }

            return false;
        }

        private bool ConditionValueComparison(double left, string comparator, double right)
        {
            switch (comparator)
            {
                case ">": if (left > right * left) return true; break;
                case "<": if (left < right * left) return true; break;
            }

            return false;
        }

        private void ConditionCompletion(string completionValueType, double completionValue, string mathOperator, IUnit unit, Spell spell)
        {
            if (spell != null)
            {
                switch (completionValueType)
                {
                    case "ManaRequirement": spell.ManaRequirement = this.CompletionReward(spell.ManaRequirement, mathOperator, completionValue); break;
                    case "Power": spell.Power = this.CompletionReward(spell.Power, mathOperator, completionValue); break;
                    case "EffectPower": spell.EffectPower = this.CompletionReward(spell.EffectPower, mathOperator, completionValue); break;
                    case "ResistanceAffect": spell.ResistanceAffect = this.CompletionReward(spell.ResistanceAffect, mathOperator, completionValue); break;
                }
            }
            else
            {
                switch (completionValueType)
                {
                    case "CurrentHP": unit.CurrentHP = this.CompletionReward(unit.CurrentHP, mathOperator, completionValue); break;
                    case "CurrentMana": unit.CurrentMana = this.CompletionReward(unit.CurrentMana, mathOperator, completionValue); break;
                    case "CurrentArmor": unit.CurrentArmorValue = this.CompletionReward(unit.CurrentArmorValue, mathOperator, completionValue); break;
                    case "CurrentResistance": unit.CurrentResistanceValue = this.CompletionReward(unit.CurrentResistanceValue, mathOperator, completionValue); break;
                    case "CurrentHealthRegen": unit.CurrentHealthRegen = this.CompletionReward(unit.CurrentHealthRegen, mathOperator, completionValue); break;
                    case "CurrentManaRegen": unit.CurrentManaRegen = this.CompletionReward(unit.CurrentManaRegen, mathOperator, completionValue); break;
                    case "CurrentCritChance": unit.CurrentCritChance = this.CompletionReward(unit.CurrentCritChance, mathOperator, completionValue); break;
                    case "CurrentAttackPower": unit.CurrentAttackPower = this.CompletionReward(unit.CurrentAttackPower, mathOperator, completionValue); break;
                    case "CurrentMagicPower": unit.CurrentMagicPower = this.CompletionReward(unit.CurrentMagicPower, mathOperator, completionValue); break;
                }
            }
        }

        private double CompletionReward(double left, string mathOperator, double right)
        {
            return mathOperator switch
            {
                "+" => left + (right * left),
                "-" => left - (right * left) > 0 ? left - (right * left) : 0,
                _ => 0,
            };
        }
    }
}
