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
            var spell = new Spell();
            var cardCondition = string.Empty;
            var talentCondition = string.Empty;

            if (caster.Type == "Player" && caster.SilenceDuration == 0)
            {
                var dbSpell = await context.Spells.FindAsync(spellId);
                var hero = (Hero)caster;
                var card = context.CardsEquipment.Where(c => c.EquipmentId == hero.Id).FirstOrDefault(c => c.Card.SpellId == dbSpell.Id && !c.Card.IsUsed && c.Card.IsActivated).Card;
                var talent = context.HeroesTalents.FirstOrDefault(ht => ht.HeroId == hero.Id && ht.Talent.SpellId == dbSpell.Id).Talent;

                if (talent != null)
                {
                    talentCondition = talent.Condition;
                }

                if (card != null)
                {
                    cardCondition = card.Condition;
                    card.IsUsed = true;
                    card.IsActivated = false;
                }

                spell = mapper.Map<Spell>(dbSpell);

                if (caster.ProvokeDuration > 0 && spell.Type.Split(',')[1] == "Armor")
                {
                    return;
                }
            }

            if (caster.Type == "Monster")
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

            if (spellType == "Buff")
            {
                string positiveOrNegativeBuff = spellInfo[3];
                this.BuffSpellCast(spellStatType, spell.ManaRequirement, spell.BuffOrEffectTarget, spell.Power, caster, target, positiveOrNegativeBuff);
            }

            if (spellType == "Heal")
            {
                this.HealSpellCast(spellStatType, spell.Power, spell.ManaRequirement, caster);
            }
        }

        private void HealSpellCast(string spellStatType, double spellPower, double spellManaRequirment, IUnit caster)
        {
            double healEffect = 0;

            var manaRequirement = spellManaRequirment * caster.MaxMana;

            if (spellStatType == "Physical")
            {
                healEffect = spellPower * caster.CurrentAttackPower;
            }
            else if (spellStatType == "Magical")
            {
                healEffect = spellPower * caster.CurrentMagicPower;
            }
            else if (spellStatType == "Health")
            {
                healEffect = spellPower * caster.MaxHP;
            }

            new HealCheck().Check(caster, caster, manaRequirement, healEffect, this.manaCheck);
        }

        private void BuffSpellCast(string spellStatType, double spellManaRequirement, string buffOrEffectTarget, double spellPower, IUnit caster, IUnit target, string positiveOrNegativeBuff)
        {
            double manaRequirement = spellManaRequirement * caster.MaxMana;

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

        private void DamageSpellCast(string spellStatType, string statsProvider, double spellManaRequirement, double spellPower, double secondarySpellPower, double spellResistanceAffect, IUnit caster, IUnit target)
        {
            double damage = 0;
            double manaRequirement = spellManaRequirement * caster.MaxMana;
            var spellDamageCheck = new SpellDamageCheck();

            if (spellStatType.Contains("/")) // Combined Damage
            {
                damage = this.MixedDamageSpellCast(statsProvider, spellStatType, spellPower, secondarySpellPower, caster, target);

                spellDamageCheck.Check(caster, target, manaRequirement, damage, this.manaCheck, "Mixed", spellResistanceAffect);
            }

            string spellDamageType;
            if (spellStatType == "Physical")
            {
                if (statsProvider == "Self")
                {
                    damage = spellPower * caster.CurrentAttackPower;
                }
                else
                {
                    damage = spellPower * target.CurrentAttackPower;
                }

                spellDamageType = "Physical";
            }
            else
            {
                if (spellStatType == "Magical")
                {
                    if (statsProvider == "Self")
                    {
                        damage = spellPower * caster.CurrentMagicPower;
                    }
                    else
                    {
                        damage = spellPower * target.CurrentMagicPower;
                    }
                }
                else if (spellStatType == "MaxHP")
                {
                    if (statsProvider == "Self")
                    {
                        damage = spellPower * caster.MaxHP;
                    }
                    else
                    {
                        damage = spellPower * target.MaxHP;
                    }
                }
                else if (spellStatType == "CurrentHP")
                {
                    if (statsProvider == "Self")
                    {
                        damage = spellPower * caster.CurrentHP;
                    }
                    else
                    {
                        damage = spellPower * target.CurrentHP;
                    }
                }
                else if (spellStatType == "CurrentMana")
                {
                    if (statsProvider == "Self")
                    {
                        damage = spellPower * caster.CurrentMana;
                    }
                    else
                    {
                        damage = spellPower * target.CurrentMana;
                    }
                }

                spellDamageType = "Magical";
            }

            spellDamageCheck.Check(caster, target, manaRequirement, damage, this.manaCheck, spellDamageType, spellResistanceAffect);
        }

        private double MixedDamageSpellCast(string statsProvider, string spellStatType, double spellPower, double secondarySpellPower, IUnit caster, IUnit target)
        {
            string mainStatType = spellStatType.Split('/')[0];
            string secondaryStatType = spellStatType.Split('/')[1];

            double primaryDamage = 0;
            double secondaryDamage = 0;

            if (statsProvider.Contains('/')) // Two stats providers (Unit and Target)
            {
                var primaryStatProvider = statsProvider.Split('/')[0];
                var secondaryStatProvider = statsProvider.Split('/')[1];

                // Primary Stats
                if (mainStatType == "Physical")
                {
                    if (primaryStatProvider == "Self")
                    {
                        primaryDamage = spellPower * caster.CurrentAttackPower;
                    }
                    else
                    {
                        primaryDamage = spellPower * target.CurrentAttackPower;
                    }
                }

                if (mainStatType == "Magical")
                {
                    if (primaryStatProvider == "Self")
                    {
                        primaryDamage = spellPower * caster.CurrentMagicPower;
                    }
                    else
                    {
                        primaryDamage = spellPower * target.CurrentMagicPower;
                    }
                }
                else if (mainStatType == "MaxHP")
                {
                    if (primaryStatProvider == "Self")
                    {
                        primaryDamage = spellPower * caster.MaxHP;
                    }
                    else
                    {
                        primaryDamage = spellPower * target.MaxHP;
                    }
                }
                else if (mainStatType == "CurrentHP")
                {
                    if (primaryStatProvider == "Self")
                    {
                        primaryDamage = spellPower * caster.CurrentHP;
                    }
                    else
                    {
                        primaryDamage = spellPower * target.CurrentHP;
                    }
                }
                else if (mainStatType == "CurrentMana")
                {
                    if (primaryStatProvider == "Self")
                    {
                        primaryDamage = spellPower * caster.CurrentMana;
                    }
                    else
                    {
                        primaryDamage = spellPower * target.CurrentMana;
                    }
                }

                // Secondary Stats
                if (secondaryStatType == "Physical")
                {
                    if (secondaryStatProvider == "Self")
                    {
                        secondaryDamage = secondarySpellPower * caster.CurrentAttackPower;
                    }
                    else
                    {
                        secondaryDamage = secondarySpellPower * target.CurrentAttackPower;
                    }
                }
                else if (secondaryStatType == "Magical")
                {
                    if (secondaryStatProvider == "Self")
                    {
                        secondaryDamage = secondarySpellPower * caster.CurrentMagicPower;
                    }
                    else
                    {
                        secondaryDamage = secondarySpellPower * target.CurrentMagicPower;
                    }
                }
                else if (secondaryStatType == "MaxHP")
                {
                    if (secondaryStatProvider == "Self")
                    {
                        secondaryDamage = secondarySpellPower * caster.MaxHP;
                    }
                    else
                    {
                        secondaryDamage = secondarySpellPower * target.MaxHP;
                    }
                }
                else if (secondaryStatType == "CurrentHP")
                {
                    if (secondaryStatProvider == "Self")
                    {
                        secondaryDamage = secondarySpellPower * caster.CurrentHP;
                    }
                    else
                    {
                        secondaryDamage = secondarySpellPower * target.CurrentHP;
                    }
                }
                else if (secondaryStatProvider == "CurrentMana")
                {
                    if (secondaryStatProvider == "Self")
                    {
                        secondaryDamage = secondarySpellPower * caster.CurrentMana;
                    }
                    else
                    {
                        secondaryDamage = secondarySpellPower * target.CurrentMana;
                    }
                }
            }
            else // Single Stat Provider (Unit or Target)
            {
                // Main Stats
                if (mainStatType == "Physical")
                {
                    if (statsProvider == "Self")
                    {
                        primaryDamage = spellPower * caster.CurrentAttackPower;
                    }
                    else
                    {
                        primaryDamage = spellPower * target.CurrentAttackPower;
                    }
                }
                else if (mainStatType == "Magical")
                {
                    if (statsProvider == "Self")
                    {
                        primaryDamage = spellPower * caster.CurrentMagicPower;
                    }
                    else
                    {
                        primaryDamage = spellPower * target.CurrentMagicPower;
                    }
                }
                else if (mainStatType == "MaxHP")
                {
                    if (statsProvider == "Self")
                    {
                        primaryDamage = spellPower * caster.MaxHP;
                    }
                    else
                    {
                        primaryDamage = spellPower * target.MaxHP;
                    }
                }
                else if (mainStatType == "CurrentHP")
                {
                    if (statsProvider == "Self")
                    {
                        primaryDamage = spellPower * caster.CurrentHP;
                    }
                    else
                    {
                        primaryDamage = spellPower * target.CurrentHP;
                    }
                }
                else if (mainStatType == "CurrentMana")
                {
                    if (statsProvider == "Self")
                    {
                        primaryDamage = spellPower * caster.CurrentMana;
                    }
                    else
                    {
                        primaryDamage = spellPower * target.CurrentMana;
                    }
                }

                // Secondary Stats
                if (secondaryStatType == "Physical")
                {
                    if (statsProvider == "Self")
                    {
                        secondaryDamage = secondarySpellPower * caster.CurrentAttackPower;
                    }
                    else
                    {
                        secondaryDamage = secondarySpellPower * target.CurrentAttackPower;
                    }
                }
                else if (secondaryStatType == "Magical")
                {
                    if (statsProvider == "Self")
                    {
                        secondaryDamage = secondarySpellPower * caster.CurrentMagicPower;
                    }
                    else
                    {
                        secondaryDamage = secondarySpellPower * target.CurrentMagicPower;
                    }
                }
                else if (secondaryStatType == "MaxHP")
                {
                    if (statsProvider == "Self")
                    {
                        secondaryDamage = secondarySpellPower * caster.MaxHP;
                    }
                    else
                    {
                        secondaryDamage = secondarySpellPower * target.MaxHP;
                    }
                }
                else if (secondaryStatType == "CurrentHP")
                {
                    if (statsProvider == "Self")
                    {
                        secondaryDamage = secondarySpellPower * caster.CurrentHP;
                    }
                    else
                    {
                        secondaryDamage = secondarySpellPower * target.CurrentHP;
                    }
                }
                else if (secondaryStatType == "CurrentMana")
                {
                    if (statsProvider == "Self")
                    {
                        secondaryDamage = secondarySpellPower * caster.CurrentMana;
                    }
                    else
                    {
                        secondaryDamage = secondarySpellPower * target.CurrentMana;
                    }
                }
            }

            var damage = this.HPDamageCap(caster, primaryDamage, secondaryDamage);

            return damage;
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
    }
}
