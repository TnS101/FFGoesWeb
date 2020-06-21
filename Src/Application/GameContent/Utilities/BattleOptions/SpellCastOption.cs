namespace Application.GameContent.Utilities.BattleOptions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Validators.SpellChecks.Buffs;
    using Application.GameContent.Utilities.Validators.SpellChecks.DamageInfliction;
    using Application.GameContent.Utilities.Validators.SpellChecks.Effects;
    using Application.GameContent.Utilities.Validators.SpellChecks.MainStats;
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

        public async Task SpellCast(IUnit caster, IUnit target, int spellId, IFFDbContext context)
        {
            if (caster.Type == "Player")
            {
                var spell = await context.Spells.FindAsync(spellId);

                this.ProcessSpell(spell, caster, target);
            }
            else
            {
                Random rng = new Random();

                int spellNumber = rng.Next(0, 4);

                var monster = (Monster)caster;

                var spells = await context.Spells.Where(s => s.MonsterId == monster.Id).ToListAsync();

                if (spellNumber == 0)
                {
                    this.ProcessSpell(spells[0], caster, target);
                }
                else if (spellNumber == 1)
                {
                    this.ProcessSpell(spells[1], caster, target);
                }
                else if (spellNumber == 2)
                {
                    this.ProcessSpell(spells[2], caster, target);
                }
                else if (spellNumber == 3)
                {
                    this.ProcessSpell(spells[3], caster, target);
                }
            }
        }

        private void ProcessSpell(Spell spell, IUnit caster, IUnit target)
        {
            // Spell
            string[] spellInfo = spell.Type.Split(',');

            string spellType = spellInfo[0];

            string spellStatType = spellInfo[1];

            string statsProvider = spellInfo[2];

            // Effect
            if (spell.AdditionalEffect != null)
            {
                string[] effectInfo = spell.AdditionalEffect.Split(',');

                this.EffectCast(effectInfo, spell, caster, target);
            }

            if (spellType == "Damage")
            {
                this.DamageSpellCast(spellStatType, statsProvider, spell, caster, target);
            }

            if (spellType == "Buff")
            {
                string positiveOrNegativeBuff = spellInfo[3];
                this.BuffSpellCast(spellStatType, spell, caster, target, positiveOrNegativeBuff);
            }

            if (spellType == "Heal")
            {
                this.HealSpellCast(spellStatType, spell, caster);
            }
        }

        private void HealSpellCast(string spellStatType, Spell spell, IUnit caster)
        {
            double healEffect = 0;

            double manaRequirement = spell.ManaRequirement * caster.MaxMana;

            if (spellStatType == "Physical")
            {
                healEffect = spell.Power * caster.CurrentAttackPower;
            }
            else if (spellStatType == "Magical")
            {
                healEffect = spell.Power * caster.CurrentMagicPower;
            }
            else if (spellStatType == "Health")
            {
                healEffect = spell.Power * caster.MaxHP;
            }

            new HealCheck().Check(caster, caster, manaRequirement, healEffect, this.manaCheck);
        }

        private void BuffSpellCast(string spellStatType, Spell spell, IUnit caster, IUnit target, string positiveOrNegativeBuff)
        {
            double manaRequirement = spell.ManaRequirement * caster.MaxMana;

            var buffCheck = new BuffCheck();

            if (spell.BuffOrEffectTarget.Contains('/'))
            {
                string primaryBuffTarget = spell.BuffOrEffectTarget.Split('/')[0];
                string secondaryBuffTarget = spell.BuffOrEffectTarget.Split('/')[1];

                if (primaryBuffTarget == "Self" || secondaryBuffTarget == "Self")
                {
                    buffCheck.Check(caster, caster, manaRequirement, spell.Power, spellStatType, this.manaCheck, positiveOrNegativeBuff);
                }
                else
                {
                    buffCheck.Check(caster, target, manaRequirement, spell.Power, spellStatType, this.manaCheck, positiveOrNegativeBuff);
                }
            }
            else
            {
                if (spell.BuffOrEffectTarget == "Self")
                {
                    buffCheck.Check(caster, caster, manaRequirement, spell.Power, spellStatType, this.manaCheck, positiveOrNegativeBuff);
                }
                else
                {
                    buffCheck.Check(caster, target, manaRequirement, spell.Power, spellStatType, this.manaCheck, positiveOrNegativeBuff);
                }
            }
        }

        private void DamageSpellCast(string spellStatType, string statsProvider, Spell spell, IUnit caster, IUnit target)
        {
            double damage = 0;
            double manaRequirement = spell.ManaRequirement * caster.MaxMana;
            var spellDamageCheck = new SpellDamageCheck();

            if (spellStatType.Contains("/")) // Combined Damage
            {
                damage = this.MixedDamageSpellCast(statsProvider, spellStatType, spell, caster, target);

                spellDamageCheck.Check(caster, target, manaRequirement, damage, this.manaCheck, "Mixed", spell.ResistanceAffect);
            }

            string spellDamageType;
            if (spellStatType == "Physical")
            {
                if (statsProvider == "Self")
                {
                    damage = spell.Power * caster.CurrentAttackPower;
                }
                else
                {
                    damage = spell.Power * target.CurrentAttackPower;
                }

                spellDamageType = "Physical";
            }
            else
            {
                if (spellStatType == "Magical")
                {
                    if (statsProvider == "Self")
                    {
                        damage = spell.Power * caster.CurrentMagicPower;
                    }
                    else
                    {
                        damage = spell.Power * target.CurrentMagicPower;
                    }
                }
                else if (spellStatType == "MaxHP")
                {
                    if (statsProvider == "Self")
                    {
                        damage = spell.Power * caster.MaxHP;
                    }
                    else
                    {
                        damage = spell.Power * target.MaxHP;
                    }
                }
                else if (spellStatType == "CurrentHP")
                {
                    if (statsProvider == "Self")
                    {
                        damage = spell.Power * caster.CurrentHP;
                    }
                    else
                    {
                        damage = spell.Power * target.CurrentHP;
                    }
                }
                else if (spellStatType == "CurrentMana")
                {
                    if (statsProvider == "Self")
                    {
                        damage = spell.Power * caster.CurrentMana;
                    }
                    else
                    {
                        damage = spell.Power * target.CurrentMana;
                    }
                }

                spellDamageType = "Magical";
            }

            spellDamageCheck.Check(caster, target, manaRequirement, damage, this.manaCheck, spellDamageType, spell.ResistanceAffect);
        }

        private double MixedDamageSpellCast(string statsProvider, string spellStatType, Spell spell, IUnit caster, IUnit target)
        {
            string mainStatType = spellStatType.Split('/')[0];
            string secondaryStatType = spellStatType.Split('/')[1];

            double primaryDamage = 0;
            double secondaryDamage = 0;

            if (statsProvider.Contains('/')) // Two stats providers (Unit and Target)
            {
                string primaryStatProvider = statsProvider.Split('/')[0];
                string secondaryStatProvider = statsProvider.Split('/')[1];

                // Primary Stats
                if (mainStatType == "Physical")
                {
                    if (primaryStatProvider == "Self")
                    {
                        primaryDamage = spell.Power * caster.CurrentAttackPower;
                    }
                    else
                    {
                        primaryDamage = spell.Power * target.CurrentAttackPower;
                    }
                }

                if (mainStatType == "Magical")
                {
                    if (primaryStatProvider == "Self")
                    {
                        primaryDamage = spell.Power * caster.CurrentMagicPower;
                    }
                    else
                    {
                        primaryDamage = spell.Power * target.CurrentMagicPower;
                    }
                }
                else if (mainStatType == "MaxHP")
                {
                    if (primaryStatProvider == "Self")
                    {
                        primaryDamage = spell.Power * caster.MaxHP;
                    }
                    else
                    {
                        primaryDamage = spell.Power * target.MaxHP;
                    }
                }
                else if (mainStatType == "CurrentHP")
                {
                    if (primaryStatProvider == "Self")
                    {
                        primaryDamage = spell.Power * caster.CurrentHP;
                    }
                    else
                    {
                        primaryDamage = spell.Power * target.CurrentHP;
                    }
                }
                else if (mainStatType == "CurrentMana")
                {
                    if (primaryStatProvider == "Self")
                    {
                        primaryDamage = spell.Power * caster.CurrentMana;
                    }
                    else
                    {
                        primaryDamage = spell.Power * target.CurrentMana;
                    }
                }

                // Secondary Stats
                if (secondaryStatType == "Physical")
                {
                    if (secondaryStatProvider == "Self")
                    {
                        secondaryDamage = spell.SecondaryPower * caster.CurrentAttackPower;
                    }
                    else
                    {
                        secondaryDamage = spell.SecondaryPower * target.CurrentAttackPower;
                    }
                }
                else if (secondaryStatType == "Magical")
                {
                    if (secondaryStatProvider == "Self")
                    {
                        secondaryDamage = spell.SecondaryPower * caster.CurrentMagicPower;
                    }
                    else
                    {
                        secondaryDamage = spell.SecondaryPower * target.CurrentMagicPower;
                    }
                }
                else if (secondaryStatType == "MaxHP")
                {
                    if (secondaryStatProvider == "Self")
                    {
                        secondaryDamage = spell.SecondaryPower * caster.MaxHP;
                    }
                    else
                    {
                        secondaryDamage = spell.SecondaryPower * target.MaxHP;
                    }
                }
                else if (secondaryStatType == "CurrentHP")
                {
                    if (secondaryStatProvider == "Self")
                    {
                        secondaryDamage = spell.SecondaryPower * caster.CurrentHP;
                    }
                    else
                    {
                        secondaryDamage = spell.SecondaryPower * target.CurrentHP;
                    }
                }
                else if (secondaryStatProvider == "CurrentMana")
                {
                    if (secondaryStatProvider == "Self")
                    {
                        secondaryDamage = spell.SecondaryPower * caster.CurrentMana;
                    }
                    else
                    {
                        secondaryDamage = spell.SecondaryPower * target.CurrentMana;
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
                        primaryDamage = spell.Power * caster.CurrentAttackPower;
                    }
                    else
                    {
                        primaryDamage = spell.Power * target.CurrentAttackPower;
                    }
                }
                else if (mainStatType == "Magical")
                {
                    if (statsProvider == "Self")
                    {
                        primaryDamage = spell.Power * caster.CurrentMagicPower;
                    }
                    else
                    {
                        primaryDamage = spell.Power * target.CurrentMagicPower;
                    }
                }
                else if (mainStatType == "MaxHP")
                {
                    if (statsProvider == "Self")
                    {
                        primaryDamage = spell.Power * caster.MaxHP;
                    }
                    else
                    {
                        primaryDamage = spell.Power * target.MaxHP;
                    }
                }
                else if (mainStatType == "CurrentHP")
                {
                    if (statsProvider == "Self")
                    {
                        primaryDamage = spell.Power * caster.CurrentHP;
                    }
                    else
                    {
                        primaryDamage = spell.Power * target.CurrentHP;
                    }
                }
                else if (mainStatType == "CurrentMana")
                {
                    if (statsProvider == "Self")
                    {
                        primaryDamage = spell.Power * caster.CurrentMana;
                    }
                    else
                    {
                        primaryDamage = spell.Power * target.CurrentMana;
                    }
                }

                // Secondary Stats
                if (secondaryStatType == "Physical")
                {
                    if (statsProvider == "Self")
                    {
                        secondaryDamage = spell.SecondaryPower * caster.CurrentAttackPower;
                    }
                    else
                    {
                        secondaryDamage = spell.SecondaryPower * target.CurrentAttackPower;
                    }
                }
                else if (secondaryStatType == "Magical")
                {
                    if (statsProvider == "Self")
                    {
                        secondaryDamage = spell.SecondaryPower * caster.CurrentMagicPower;
                    }
                    else
                    {
                        secondaryDamage = spell.SecondaryPower * target.CurrentMagicPower;
                    }
                }
                else if (secondaryStatType == "MaxHP")
                {
                    if (statsProvider == "Self")
                    {
                        secondaryDamage = spell.SecondaryPower * caster.MaxHP;
                    }
                    else
                    {
                        secondaryDamage = spell.SecondaryPower * target.MaxHP;
                    }
                }
                else if (secondaryStatType == "CurrentHP")
                {
                    if (statsProvider == "Self")
                    {
                        secondaryDamage = spell.SecondaryPower * caster.CurrentHP;
                    }
                    else
                    {
                        secondaryDamage = spell.SecondaryPower * target.CurrentHP;
                    }
                }
                else if (secondaryStatType == "CurrentMana")
                {
                    if (statsProvider == "Self")
                    {
                        secondaryDamage = spell.SecondaryPower * caster.CurrentMana;
                    }
                    else
                    {
                        secondaryDamage = spell.SecondaryPower * target.CurrentMana;
                    }
                }
            }

            double damage = this.HPDamageCap(caster, primaryDamage, secondaryDamage);

            return damage;
        }

        private double HPDamageCap(IUnit caster, double primaryDamage, double secondaryDamage)
        {
            double magicDamageCap = 0.8 * caster.CurrentMagicPower;
            double physicalDamageCap = 0.65 * caster.CurrentAttackPower;

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

        private void EffectCast(string[] effectInfo, Spell spell, IUnit caster, IUnit target)
        {
            var effectCheck = new EffectCheck();

            string spellTarget = spell.BuffOrEffectTarget;
            double manaRequirement = spell.ManaRequirement * caster.MaxMana;

            string firstEffectType = effectInfo[0];
            string firstPositiveOrNegativeEffect = effectInfo[1];
            string secondEffectType = string.Empty;
            string secondPositiveOrNegativeEffect = string.Empty;

            if (effectInfo.Count() > 2)
            {
                secondEffectType = effectInfo[2];
                secondPositiveOrNegativeEffect = effectInfo[3];
            }

            if (spell.BuffOrEffectTarget.Contains('/'))
            {
                string[] targets = spell.BuffOrEffectTarget.Split('/');

                string firstTarget = targets[0];
                string secondTarget = targets[1];

                if (effectInfo.Count() > 2) // Two Effects and Two Providers (Caster and Target)
                {
                    if (firstTarget == "Self")
                    {
                        effectCheck.Check(caster, caster, manaRequirement, spell.EffectPower, firstEffectType, this.manaCheck, firstPositiveOrNegativeEffect);
                    }
                    else
                    {
                        effectCheck.Check(caster, target, manaRequirement, spell.EffectPower, firstEffectType, this.manaCheck, firstPositiveOrNegativeEffect);
                    }

                    if (secondTarget == "Self")
                    {
                        effectCheck.Check(caster, caster, manaRequirement, spell.SecondaryPower, secondEffectType, this.manaCheck, secondPositiveOrNegativeEffect);
                    }
                    else
                    {
                        effectCheck.Check(caster, target, manaRequirement, spell.SecondaryPower, secondEffectType, this.manaCheck, secondPositiveOrNegativeEffect);
                    }
                }
                else // One Effect and Two Providers (Caster and Target)
                {
                    if (firstTarget == "Self" || secondTarget == "Self")
                    {
                        effectCheck.Check(caster, caster, manaRequirement, spell.EffectPower, firstEffectType, this.manaCheck, firstPositiveOrNegativeEffect);
                    }
                    else
                    {
                        effectCheck.Check(caster, target, manaRequirement, spell.EffectPower, firstEffectType, this.manaCheck, firstPositiveOrNegativeEffect);
                    }
                }
            }
            else // Two Effects and Single Provider (Caster or Target)
            {
                if (effectInfo.Count() > 2)
                {
                    if (spellTarget == "Self")
                    {
                        effectCheck.Check(caster, caster, manaRequirement, spell.EffectPower, firstEffectType, this.manaCheck, firstPositiveOrNegativeEffect);
                        effectCheck.Check(caster, caster, manaRequirement, spell.SecondaryPower, secondEffectType, this.manaCheck, secondPositiveOrNegativeEffect);
                    }
                    else
                    {
                        effectCheck.Check(caster, target, manaRequirement, spell.EffectPower, firstEffectType, this.manaCheck, firstPositiveOrNegativeEffect);
                        effectCheck.Check(caster, target, manaRequirement, spell.SecondaryPower, secondEffectType, this.manaCheck, secondPositiveOrNegativeEffect);
                    }
                }

                if (spellTarget == "Self") // One Effect and One Provider
                {
                    effectCheck.Check(caster, caster, manaRequirement, spell.EffectPower, firstEffectType, this.manaCheck, firstPositiveOrNegativeEffect);
                }
                else
                {
                    effectCheck.Check(caster, target, manaRequirement, spell.EffectPower, firstEffectType, this.manaCheck, firstPositiveOrNegativeEffect);
                }
            }
        }
    }
}
