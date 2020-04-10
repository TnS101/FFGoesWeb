namespace Application.GameContent.Utilities.BattleOptions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Validators.SpellCheck;
    using Application.GameContent.Utilities.Validators.SpellChecks.MainStats;
    using Domain.Base;
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;

    public class SpellCastOption
    {
        private readonly SpellCheck spellCheck;
        private readonly ManaCheck manaCheck;

        public SpellCastOption()
        {
            this.spellCheck = new SpellCheck();
            this.manaCheck = new ManaCheck();
        }

        public async Task SpellCast(Unit caster, Unit target, string spellName, IFFDbContext context)
        {
            if (caster.Type == "Player")
            {
                var spell = await context.Spells.FirstOrDefaultAsync(s => s.Name == spellName);

                this.ProcessSpell(spell, caster, target);
            }
            else
            {
                Random rng = new Random();

                int spellNumber = rng.Next(0, 4);

                var spells = await context.Spells.Where(s => s.ClassType == caster.Name).ToListAsync();

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

            if (target.CurrentHP <= 0)
            {
                target.CurrentHP = 0;
            }
        }

        private void ProcessSpell(Spell spell, Unit caster, Unit target)
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

        private void HealSpellCast(string spellStatType, Spell spell, Unit caster)
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

            this.spellCheck.HealCheck.Check(caster, caster, manaRequirement, healEffect, this.manaCheck);
        }

        private void BuffSpellCast(string spellStatType, Spell spell, Unit caster, Unit target, string positiveOrNegativeBuff)
        {
            double manaRequirement = spell.ManaRequirement * caster.MaxMana;

            if (spell.BuffOrEffectTarget.Contains('/'))
            {
                string primaryBuffTarget = spell.BuffOrEffectTarget.Split('/')[0];
                string secondaryBuffTarget = spell.BuffOrEffectTarget.Split('/')[1];

                if (primaryBuffTarget == "Self" || secondaryBuffTarget == "Self")
                {
                    this.spellCheck.BuffCheck.Check(caster, caster, manaRequirement, spell.Power, spellStatType, this.manaCheck, positiveOrNegativeBuff);
                }
                else
                {
                    this.spellCheck.BuffCheck.Check(caster, target, manaRequirement, spell.Power, spellStatType, this.manaCheck, positiveOrNegativeBuff);
                }
            }
            else
            {
                if (spell.BuffOrEffectTarget == "Self")
                {
                    this.spellCheck.BuffCheck.Check(caster, caster, manaRequirement, spell.Power, spellStatType, this.manaCheck, positiveOrNegativeBuff);
                }
                else
                {
                    this.spellCheck.BuffCheck.Check(caster, target, manaRequirement, spell.Power, spellStatType, this.manaCheck, positiveOrNegativeBuff);
                }
            }
        }

        private void DamageSpellCast(string spellStatType, string statsProvider, Spell spell, Unit caster, Unit target)
        {
            double damage = 0;
            double manaRequirement = spell.ManaRequirement * caster.MaxMana;
            string spellDamageType = string.Empty;

            if (spellStatType == "Physical")
            {
                if (statsProvider == "Self")
                {
                    damage = (spell.Power * caster.CurrentAttackPower) - spell.ResistanceAffect;
                }
                else
                {
                    damage = (spell.Power * target.CurrentAttackPower) - spell.ResistanceAffect;
                }

                spellDamageType = "Physical";
            }
            else if (spellStatType.Contains('/')) // Combined Damage
            {
                damage = this.MixedDamageSpellCast(statsProvider, spellStatType, spell, caster, target, spellDamageType);
            }
            else
            {
                if (spellStatType == "Magical")
                {
                    if (statsProvider == "Self")
                    {
                        damage = (spell.Power * caster.CurrentMagicPower) - spell.ResistanceAffect;
                    }
                    else
                    {
                        damage = (spell.Power * target.CurrentMagicPower) - spell.ResistanceAffect;
                    }
                }
                else if (spellStatType == "MaxHP")
                {
                    if (statsProvider == "Self")
                    {
                        damage = (spell.Power * caster.MaxHP) - spell.ResistanceAffect;
                    }
                    else
                    {
                        damage = (spell.Power * target.MaxHP) - spell.ResistanceAffect;
                    }
                }
                else if (spellStatType == "CurrentHP")
                {
                    if (statsProvider == "Self")
                    {
                        damage = (spell.Power * caster.CurrentHP) - spell.ResistanceAffect;
                    }
                    else
                    {
                        damage = (spell.Power * target.CurrentHP) - spell.ResistanceAffect;
                    }
                }

                spellDamageType = "Magical";
            }

            this.spellCheck.SpellDamageCheck.Check(caster, target, manaRequirement, damage, this.manaCheck, spellDamageType);
        }

        private double MixedDamageSpellCast(string statsProvider, string spellStatType, Spell spell, Unit caster, Unit target, string spellDamageType)
        {
            string mainStatType = spellStatType.Split('/')[0];
            string secondaryStatType = spellStatType.Split('/')[1];

            double primaryDamage = 0;
            double secondaryDamage = 0;

            if (statsProvider.Contains('/')) // Two stats providers (Unit and Target)
            {
                string primaryStatProvider = statsProvider.Split('/')[0];
                string secondaryStatProvider = statsProvider.Split('/')[1];

                if (mainStatType == "Physical" || secondaryStatType == "Physical")
                {
                    if (primaryStatProvider == "Self")
                    {
                        primaryDamage = spell.Power * caster.CurrentAttackPower;
                    }
                    else
                    {
                        primaryDamage = spell.Power * target.CurrentAttackPower;
                    }

                    if (secondaryStatProvider == "Self")
                    {
                        secondaryDamage = spell.SecondaryPower * caster.CurrentAttackPower;
                    }
                    else
                    {
                        secondaryDamage = spell.SecondaryPower * target.CurrentAttackPower;
                    }
                }

                if (mainStatType == "Magical" || secondaryStatType == "Magical")
                {
                    if (primaryStatProvider == "Self")
                    {
                        primaryDamage = spell.Power * caster.CurrentMagicPower;
                    }
                    else
                    {
                        primaryDamage = spell.Power * target.CurrentMagicPower;
                    }

                    if (secondaryStatProvider == "Self")
                    {
                        secondaryDamage = spell.SecondaryPower * caster.CurrentMagicPower;
                    }
                    else
                    {
                        secondaryDamage = spell.SecondaryPower * target.CurrentMagicPower;
                    }
                }
                else if (mainStatType == "MaxHP" || secondaryStatType == "MaxHP")
                {
                    if (primaryStatProvider == "Self")
                    {
                        primaryDamage = spell.Power * caster.MaxHP;
                    }
                    else
                    {
                        primaryDamage = spell.Power * target.MaxHP;
                    }

                    if (secondaryStatProvider == "Self")
                    {
                        secondaryDamage = spell.SecondaryPower * caster.MaxHP;
                    }
                    else
                    {
                        secondaryDamage = spell.SecondaryPower * target.MaxHP;
                    }

                    this.HPDamageCap(caster, primaryDamage, secondaryDamage);
                }
                else if (mainStatType == "CurrentHP" || secondaryStatType == "CurrentHP")
                {
                    if (primaryStatProvider == "Self")
                    {
                        primaryDamage = spell.Power * caster.CurrentHP;
                    }
                    else
                    {
                        primaryDamage = spell.Power * target.CurrentHP;
                    }

                    if (secondaryStatProvider == "Self")
                    {
                        secondaryDamage = spell.SecondaryPower * caster.CurrentHP;
                    }
                    else
                    {
                        secondaryDamage = spell.SecondaryPower * target.CurrentHP;
                    }

                    this.HPDamageCap(caster, primaryDamage, secondaryDamage);
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

                    this.HPDamageCap(caster, primaryDamage, secondaryDamage);
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

                    this.HPDamageCap(caster, primaryDamage, secondaryDamage);
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

                    this.HPDamageCap(caster, primaryDamage, secondaryDamage);
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

                    this.HPDamageCap(caster, primaryDamage, secondaryDamage);
                }
            }

            double damage = (primaryDamage + secondaryDamage) - spell.ResistanceAffect;

            spellDamageType = "Mixed";

            return damage;
        }

        private void HPDamageCap(Unit caster, double primaryDamage, double secondaryDamage)
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
        }

        private void EffectCast(string[] effectInfo, Spell spell, Unit caster, Unit target)
        {
            string spellTarget = spell.BuffOrEffectTarget;
            double manaRequirement = spell.ManaRequirement * caster.MaxMana;

            int counter = 0;

            for (int i = 0; i < effectInfo.Length; i++)
            {
                string effectType = string.Empty;
                string positiveOrNegativeEffect = string.Empty;

                if (i % 2 == 0)
                {
                    effectType = effectInfo[i];
                }
                else
                {
                    positiveOrNegativeEffect = effectInfo[i];
                }

                if (spell.BuffOrEffectTarget.Contains('/'))
                {
                    string[] targets = spell.BuffOrEffectTarget.Split('/');

                    if (counter < 2)
                    {
                        spellTarget = targets[counter];
                        counter++;
                    }
                }

                if (spellTarget == "Self")
                {
                    this.spellCheck.EffectCheck.Check(caster, caster, manaRequirement, spell.EffectPower, effectType, this.manaCheck, positiveOrNegativeEffect);
                }
                else
                {
                    this.spellCheck.EffectCheck.Check(caster, target, manaRequirement, spell.EffectPower, effectType, this.manaCheck, positiveOrNegativeEffect);
                }
            }
        }
    }
}
