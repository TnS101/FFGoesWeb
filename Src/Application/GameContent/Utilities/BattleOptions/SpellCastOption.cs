namespace Application.GameContent.Utilities.BattleOptions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Validators.Condition;
    using Application.GameContent.Utilities.Validators.SpellChecks.Buffs;
    using Application.GameContent.Utilities.Validators.SpellChecks.DamageInfliction;
    using Application.GameContent.Utilities.Validators.SpellChecks.Effects;
    using Application.GameContent.Utilities.Validators.SpellChecks.MainStats;
    using AutoMapper;
    using Domain.Contracts.Units;
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;

    public class SpellCastOption
    {
        private readonly ManaCheck manaCheck;

        public SpellCastOption()
        {
            this.manaCheck = new ManaCheck();
        }

        public async Task SpellCast(IUnit caster, IUnit target, int spellId, IFFDbContext context, IMapper mapper)
        {
            Spell spell = null;
            var cardCondition = string.Empty;
            var talentCondition = string.Empty;

            if (caster.Type == "Player" && caster.SilenceDuration == 0)
            {
                var dbSpell = await context.Spells.FindAsync(spellId);
                //var hero = (Hero)caster;
                //var card = context.CardsEquipments.Where(c => c.HeroId == hero.Id).FirstOrDefault(c => c.Card.SpellId == dbSpell.Id && !c.Card.IsUsed && c.Card.IsActivated).Card;
                //var talent = context.HeroesTalents.FirstOrDefault(ht => ht.HeroId == hero.Id && ht.Talent.SpellId == dbSpell.Id).Talent;

                //if (talent != null)
                //{
                //    talentCondition = talent.Condition;
                //}

                //if (card != null)
                //{
                //    cardCondition = card.Condition;
                //    card.IsUsed = true;
                //    card.IsActivated = false;
                //}

                spell = mapper.Map<Spell>(dbSpell);

                if (caster.ProvokeDuration > 0 && spell.Type.Split(',')[1] == "Armor")
                {
                    return;
                }
            }

            if (caster.Type != "Player" && caster.SilenceDuration == 0)
            {
                var monster = (Monster)caster;
                var spells = await context.Spells.Where(s => s.MonsterId == monster.Id).ToArrayAsync();

                while (true)
                {
                    int spellNumber = new Random().Next(4);

                    spell = spells[spellNumber];

                    if (caster.ProvokeDuration > 0)
                    {
                        if (spell.Type.Split(',')[1] != "Armor")
                        {
                            break;
                        }

                        return;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            this.ProcessSpell(spell, caster, target, cardCondition, talentCondition);
        }

        private void ProcessSpell(Spell spell, IUnit caster, IUnit target, string cardCondition, string talentCondition)
        {
            // Spell
            string[] spellInfo = spell.Type.Split(',');

            var spellType = spellInfo[0];

            var spellStatType = spellInfo[1];

            var statsProvider = spellInfo[2];

            if (spell.Condition != null)
            {
                new ConditionValidator().Process(spell, caster, target, cardCondition, talentCondition, false);
            }

            // Effect
            if (spell.AdditionalEffect != null)
            {
                string[] effectInfo = spell.AdditionalEffect.Contains(',') ? spell.AdditionalEffect.Split(',') : new string[] { spell.AdditionalEffect };

                this.EffectCast(effectInfo, spell.ManaRequirement, spell.BuffOrEffectTarget, spell.EffectPower, spell.SecondaryPower, caster, target);
            }

            if (spellType == "Damage")
            {
                this.DamageSpellCast(spellStatType, statsProvider, spell.ManaRequirement, spell.Power, spell.SecondaryPower, spell.ResistanceAffect, caster, target);
            }
            else if (spellType == "Buff")
            {
                string positiveOrNegativeBuff = spellInfo[3];
                this.BuffSpellCast(spellStatType, spell.ManaRequirement, spell.BuffOrEffectTarget, spell.Power, caster, target, positiveOrNegativeBuff);
            }
            else if (spellType == "Heal")
            {
                this.HealSpellCast(spellStatType, spell.Power, spell.ManaRequirement, caster);
            }
        }

        private void HealSpellCast(string spellStatType, double spellPower, double manaRequirement, IUnit caster)
        {
            double healEffect = 0;

            switch (spellStatType)
            {
                case "Physical": healEffect = spellPower * caster.CurrentAttackPower; break;
                case "Magical": healEffect = spellPower * caster.CurrentMagicPower; break;
                case "Health": healEffect = spellPower * caster.MaxHP; break;
            }

            new HealCheck().Check(caster, caster, manaRequirement, healEffect, this.manaCheck);
        }

        private void BuffSpellCast(string spellStatType, double manaRequirement, string buffOrEffectTarget, double spellPower, IUnit caster, IUnit target, string positiveOrNegativeBuff)
        {
            var buffCheck = new BuffCheck();

            if (buffOrEffectTarget.Contains('/'))
            {
                string primaryBuffTarget = buffOrEffectTarget.Split('/')[0];
                string secondaryBuffTarget = buffOrEffectTarget.Split('/')[1];

                if (primaryBuffTarget == "Self" || secondaryBuffTarget == "Self")
                {
                    buffCheck.Check(caster, caster, manaRequirement, spellPower, spellStatType, this.manaCheck, positiveOrNegativeBuff);
                }
                else
                {
                    buffCheck.Check(caster, target, manaRequirement, spellPower, spellStatType, this.manaCheck, positiveOrNegativeBuff);
                }
            }
            else
            {
                if (buffOrEffectTarget == "Self")
                {
                    buffCheck.Check(caster, caster, manaRequirement, spellPower, spellStatType, this.manaCheck, positiveOrNegativeBuff);
                }
                else
                {
                    buffCheck.Check(caster, target, manaRequirement, spellPower, spellStatType, this.manaCheck, positiveOrNegativeBuff);
                }
            }
        }

        private void DamageSpellCast(string spellStatType, string statsProvider, double manaRequirement, double spellPower, double secondarySpellPower, double spellResistanceAffect, IUnit caster, IUnit target)
        {
            double damage;
            var spellDamageCheck = new SpellDamageCheck();

            if (spellStatType.Contains("/")) // Combined Damage
            {
                damage = this.MixedDamageSpellCast(statsProvider, spellStatType, spellPower, secondarySpellPower, caster, target);

                spellDamageCheck.Check(caster, target, manaRequirement, damage, this.manaCheck, "Mixed", spellResistanceAffect);
            }

            damage = this.DamageCalculation(statsProvider, spellStatType, spellPower, caster, target);

            spellDamageCheck.Check(caster, target, manaRequirement, damage, this.manaCheck, spellStatType, spellResistanceAffect);
        }

        private double MixedDamageSpellCast(string statsProvider, string spellStatType, double spellPower, double secondarySpellPower, IUnit caster, IUnit target)
        {
            string mainStatType = spellStatType.Split('/')[0];
            string secondaryStatType = spellStatType.Split('/')[1];

            double primaryDamage;
            double secondaryDamage;

            if (statsProvider.Contains('/')) // Two stats providers (Unit and Target)
            {
                var primaryStatProvider = statsProvider.Split('/')[0];
                var secondaryStatProvider = statsProvider.Split('/')[1];

                primaryDamage = this.DamageCalculation(primaryStatProvider, mainStatType, spellPower, caster, target);
                secondaryDamage = this.DamageCalculation(secondaryStatProvider, secondaryStatType, secondarySpellPower, caster, target);
            }
            else // Single Stat Provider (Unit or Target)
            {
                primaryDamage = this.DamageCalculation(statsProvider, mainStatType, spellPower, caster, target);
                secondaryDamage = this.DamageCalculation(statsProvider, secondaryStatType, secondarySpellPower, caster, target);
            }

            return this.HPDamageCap(caster, primaryDamage, secondaryDamage);
        }

        private void EffectCast(string[] effectInfo, double spellManaRequirement, string spellBuffOrEffectTarget, double spellEffectPower, double spellSecondaryPower, IUnit caster, IUnit target)
        {
            var effectCheck = new EffectCheck();

            var spellTarget = spellBuffOrEffectTarget;
            double manaRequirement = spellManaRequirement * caster.MaxMana;

            string statType = effectInfo[0];

            if (effectInfo.Length == 1)
            {
                effectCheck.Check(caster, caster, manaRequirement, spellEffectPower, statType, this.manaCheck, string.Empty);
            }
            else
            {
                string effectType = effectInfo[1];
                string secondEffectType = string.Empty;
                string secondPositiveOrNegativeEffect = string.Empty;

                if (effectInfo.Count() > 2)
                {
                    secondEffectType = effectInfo[2];
                    secondPositiveOrNegativeEffect = effectInfo[3];
                }

                if (spellBuffOrEffectTarget.Contains('/'))
                {
                    string[] targets = spellBuffOrEffectTarget.Split('/');

                    string firstTarget = targets[0];
                    string secondTarget = targets[1];

                    if (effectInfo.Count() > 2) // Two Effects and Two Providers (Caster and Target)
                    {
                        if (firstTarget == "Self")
                        {
                            effectCheck.Check(caster, caster, manaRequirement, spellEffectPower, statType, this.manaCheck, effectType);
                        }
                        else
                        {
                            effectCheck.Check(caster, target, manaRequirement, spellEffectPower, statType, this.manaCheck, effectType);
                        }

                        if (secondTarget == "Self")
                        {
                            effectCheck.Check(caster, caster, manaRequirement, spellSecondaryPower, secondEffectType, this.manaCheck, secondPositiveOrNegativeEffect);
                        }
                        else
                        {
                            effectCheck.Check(caster, target, manaRequirement, spellSecondaryPower, secondEffectType, this.manaCheck, secondPositiveOrNegativeEffect);
                        }
                    }
                    else // One Effect and Two Providers (Caster and Target)
                    {
                        if (firstTarget == "Self" || secondTarget == "Self")
                        {
                            effectCheck.Check(caster, caster, manaRequirement, spellEffectPower, statType, this.manaCheck, effectType);
                        }
                        else
                        {
                            effectCheck.Check(caster, target, manaRequirement, spellEffectPower, statType, this.manaCheck, effectType);
                        }
                    }
                }
                else // Two Effects and Single Provider (Caster or Target)
                {
                    if (effectInfo.Count() > 2)
                    {
                        if (spellTarget == "Self")
                        {
                            effectCheck.Check(caster, caster, manaRequirement, spellEffectPower, statType, this.manaCheck, effectType);
                            effectCheck.Check(caster, caster, manaRequirement, spellSecondaryPower, secondEffectType, this.manaCheck, secondPositiveOrNegativeEffect);
                        }
                        else
                        {
                            effectCheck.Check(caster, target, manaRequirement, spellEffectPower, statType, this.manaCheck, effectType);
                            effectCheck.Check(caster, target, manaRequirement, spellSecondaryPower, secondEffectType, this.manaCheck, secondPositiveOrNegativeEffect);
                        }
                    }

                    if (spellTarget == "Self") // One Effect and One Provider
                    {
                        effectCheck.Check(caster, caster, manaRequirement, spellEffectPower, statType, this.manaCheck, effectType);
                    }
                    else
                    {
                        effectCheck.Check(caster, target, manaRequirement, spellEffectPower, statType, this.manaCheck, effectType);
                    }
                }
            }
        }

        private double DamageCalculation(string statsProvider, string statType, double spellPower, IUnit caster, IUnit target)
        {
            return statType switch
            {
                "Physical" => this.GetProvider(statsProvider, spellPower, caster.CurrentAttackPower, target.CurrentAttackPower),
                "Magical" => this.GetProvider(statsProvider, spellPower, caster.CurrentMagicPower, target.CurrentMagicPower),
                "MaxHP" => this.GetProvider(statsProvider, spellPower, caster.MaxHP, target.MaxHP),
                "CurrentHP" => this.GetProvider(statsProvider, spellPower, caster.CurrentHP, target.CurrentHP),
                "CurrentMana" => this.GetProvider(statsProvider, spellPower, caster.CurrentMana, target.CurrentMana),
                "MaxMana" => this.GetProvider(statsProvider, spellPower, caster.MaxMana, target.MaxMana),
                _ => 0,
            };
        }

        private double GetProvider(string statsProvider, double spellPower, double casterPower, double targetPower)
        {
            if (statsProvider == "Self")
            {
                return spellPower * casterPower;
            }

            return spellPower * targetPower;
        }

        private double HPDamageCap(IUnit caster, double primaryDamage, double secondaryDamage)
        {
            var magicDamageCap = 0.8 * caster.CurrentMagicPower;
            var physicalDamageCap = 0.65 * caster.CurrentAttackPower;

            if (primaryDamage > magicDamageCap)
            {
                primaryDamage = magicDamageCap;
            }
            else if (primaryDamage > physicalDamageCap)
            {
                primaryDamage = physicalDamageCap;
            }

            if (secondaryDamage > magicDamageCap)
            {
                secondaryDamage = magicDamageCap;
            }
            else if (secondaryDamage > physicalDamageCap)
            {
                secondaryDamage = physicalDamageCap;
            }

            return primaryDamage + secondaryDamage;
        }
    }
}
