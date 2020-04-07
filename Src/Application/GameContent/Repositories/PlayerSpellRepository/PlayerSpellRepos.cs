namespace Application.GameContent.Repositories.PlayerSpellRepository
{
    using Domain.Base;
    using Application.GameContent.Utilities.Validators.SpellCheck;
    using Application.GameContent.Utilities.Validators.SpellChecks.MainStats;

    public class PlayerSpellRepos
    {
        private readonly SpellCheck spellCheck;
        private readonly ManaCheck manaCheck;

        public PlayerSpellRepos()
        {
            this.spellCheck = new SpellCheck();
            this.manaCheck = new ManaCheck();
        }

        // Warrior
        private void Warrior_HeadSmash(Unit caster, Unit target)
        {
            string spellName = "Head Smash";
            string effectType = "Damage";
            double manaRequirment = 0.4 * caster.MaxMana;
            double effect = 0.08 * caster.MaxHP;
            double damage = (caster.CurrentAttackPower * 1.35) - target.CurrentArmorValue;
            this.spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, effect, effectType, this.manaCheck);
            this.spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Warrior_HyperStrength(Unit caster, Unit target)
        {
            string spellName = "Hyper Strength";
            string buffType = "Attack";
            double effect = 0.2 * caster.AttackPower;
            double manaRequirment = 0.35 * caster.MaxMana;
            this.spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType, this.manaCheck);
        }

        private void Warrior_RagingBlow(Unit caster, Unit target)
        {
            string spellName = "Raging Blow";
            string effectType = "mRegen";
            double damage = caster.CurrentAttackPower - (0.8 * target.CurrentArmorValue);
            int effect = caster.Level;
            double manaRequirment = 0.15 * caster.MaxMana;
            this.spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, effect, effectType, this.manaCheck);
            this.spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Warrior_Disarm(Unit caster, Unit target)
        {
            string spellName = "Disarm";
            string debuffType = "Attack";
            double effect = 0.15 * target.CurrentAttackPower;
            double manaRequirment = 0.3 * caster.MaxMana;
            this.spellCheck.DeBuffCheck.Check(caster, target, manaRequirment, effect, spellName, debuffType, this.manaCheck);
        }

        // Hunter
        private void Hunter_HastingArrow(Unit caster, Unit target)
        {
            string spellName = "Hasting Arrow";
            string effectType = "Crit";
            int effect = 5;
            double damage = (caster.CurrentAttackPower * 1.2) - target.CurrentArmorValue;
            double manaRequirment = caster.MaxMana * 0.12;
            this.spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, effect, effectType, this.manaCheck);
            this.spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Hunter_GrassHop(Unit caster, Unit target)
        {
            string spellName = "Grass Hop";
            string buffType = "Armor";
            double effect = 0.70 * caster.ArmorValue;
            double manaRequirment = 0.5 * caster.MaxMana;
            this.spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType, this.manaCheck);
        }

        private void Hunter_PoisonShot(Unit caster, Unit target)
        {
            string spellName = "Poison Shot";
            double damage = (0.5 * caster.CurrentAttackPower) + (0.7 * caster.CurrentMagicPower) - (target.CurrentArmorValue * 0.5);
            double manaRequirment = 0.25 * caster.MaxMana;
            this.spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Hunter_SharpEye(Unit caster, Unit target)
        {
            string spellName = "Sharp Eye";
            string buffType = "Attack";
            double effect = 0.3 * caster.AttackPower;
            double manaRequirment = 0.5 * caster.MaxMana;
            this.spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType, this.manaCheck);
        }

        // Mage
        private void Mage_WaterBall(Unit caster, Unit target)
        {
            string spellName = "Water Ball";
            string effectType = "mRegen";
            double manaRequirment = 0.30 * caster.MaxMana;
            int effect = (int)caster.MaxMana / 10;
            double damage = (caster.CurrentMagicPower * 0.7) - target.CurrentRessistanceValue;
            this.spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, effect, effectType, this.manaCheck);
            this.spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Mage_FireBall(Unit caster, Unit target)
        {
            string spellName = "Fire Ball";
            string effectType = "hRegen";
            double manaRequirment = 0.25 * caster.MaxMana;
            int effect = 1;

            double maxHPDamage = target.MaxHP * 0.05;

            if (maxHPDamage >= caster.CurrentMagicPower * 0.8)
            {
                maxHPDamage = caster.CurrentMagicPower * 0.8;
            }

            double damage = maxHPDamage + (caster.CurrentMagicPower * 0.6) - (target.CurrentRessistanceValue * 0.68);
            this.spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, effect, effectType, this.manaCheck);
            this.spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Mage_ManaConversion(Unit caster, Unit target)
        {
            string spellName = "Mana Conversion";
            string buffType = "Mana";
            string negativeEffectType = "Armor";
            double manaRequirment = 0;
            double effect = 0.25 * caster.MaxMana;
            double negativeEffect = 0.20 * caster.ArmorValue;
            this.spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, negativeEffect, negativeEffectType, this.manaCheck);
            this.spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType, this.manaCheck);
        }

        private void Mage_AllOutBlast(Unit caster, Unit target)
        {
            string spellName = "All-Out Blast!";
            double damage = caster.CurrentMagicPower * 2;
            string negativeEffectType = "mRegen";
            int negativeEffect = caster.Level * 3;
            double manaRequirment = caster.MaxMana * 0.8;
            this.spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
            this.spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, negativeEffect, negativeEffectType, this.manaCheck);
        }

        // Naturalist
        private void Naturalist_NaturesTouch(Unit caster, Unit target)
        {
            string spellName = "Nature's Touch";
            string effectType = "Armor";
            double armorIncrease = caster.ArmorValue * 0.22;
            double manaRequirment = 0.4 * caster.MaxMana;
            double effect = (caster.CurrentMagicPower * 0.45) + caster.CurrentManaRegen;
            this.spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, armorIncrease, effectType, this.manaCheck);
            this.spellCheck.HealCheck.Check(caster, caster, manaRequirment, effect, spellName, this.manaCheck);
        }

        private void Naturalist_ThornBlast(Unit caster, Unit target)
        {
            string spellName = "Thorn Blast";
            string negativeEffectType = "Armor";
            double manaRequirment = 0.30 * caster.MaxMana;
            double negativeEffect = target.ArmorValue * 0.3;
            double damage = (caster.CurrentMagicPower * 0.75) - target.CurrentRessistanceValue;
            this.spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, negativeEffect, negativeEffectType, this.manaCheck);
            this.spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Naturalist_NaturesGift(Unit caster, Unit target)
        {
            string spellName = "Nature's Gift";
            string buffEffectType = "hRegen";
            string possitiveEffectType = "Magic";
            string negativeEffectType = "Damage";
            double manaRequirment = 0;
            int buffEffect = caster.HealthRegen;
            double possitiveEffect = 0.1 * caster.MagicPower;
            double negativeEffect = 0.05 * caster.MaxHP;
            this.spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, negativeEffect, negativeEffectType, this.manaCheck);
            this.spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType, this.manaCheck);
            this.spellCheck.BuffCheck.Check(caster, caster, manaRequirment, buffEffect, spellName, buffEffectType, this.manaCheck);
        }

        private void Naturalist_PouringRain(Unit caster, Unit target)
        {
            string spellname = "Pouring Rain";
            string buffType = "Mana";
            string negativeEffectType = "mRegen";
            double manaRequirment = caster.MaxMana * 0.1;
            double possitiveEffect = 0.3 * caster.MaxMana;
            int negativeEffect = caster.Level;
            this.spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, negativeEffect, negativeEffectType, this.manaCheck);
            this.spellCheck.BuffCheck.Check(caster, caster, manaRequirment, possitiveEffect, spellname, buffType, this.manaCheck);
        }

        // Necroid
        private void Necroid_ShadowTouch(Unit caster, Unit target)
        {
            string spellName = "Shadow Touch";
            string effectType = "Res";
            double manaRequirment = 0.30 * caster.MaxMana;
            double effect = target.CurrentRessistanceValue * 0.2;

            double maxHPDamage = target.MaxHP * 0.08;

            if (maxHPDamage >= caster.CurrentMagicPower * 0.7)
            {
                maxHPDamage = caster.CurrentMagicPower * 0.7;
            }

            double damage = maxHPDamage + (caster.CurrentMana * 0.12) - target.CurrentRessistanceValue;
            this.spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, effect, effectType, this.manaCheck);
            this.spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Necroid_LifeSyphon(Unit caster, Unit target)
        {
            string spellName = "Life Syphon";
            string effectType = "SelfHP";
            double manaRequirment = 0.4 * caster.MaxMana;

            double maxHPDamage = target.MaxHP * 0.1;

            if (maxHPDamage >= caster.CurrentMagicPower * 0.6)
            {
                maxHPDamage = caster.CurrentMagicPower * 0.6;
            }

            double effect = maxHPDamage + (caster.CurrentMagicPower * 0.5);
            double damage = effect - target.CurrentRessistanceValue;
            this.spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, damage, effectType, this.manaCheck);
            this.spellCheck.HealCheck.Check(caster, target, manaRequirment, effect, spellName, this.manaCheck);
        }

        private void Necroid_ArcaneBane(Unit caster, Unit target)
        {
            string spellName = "Arcane Bane";
            string debuffType = "Magic";
            double manaRequirment = 0.2 * caster.MaxMana;
            double negativeEffect = 0.2 * target.CurrentMagicPower;
            this.spellCheck.DeBuffCheck.Check(caster, target, manaRequirment, negativeEffect, spellName, debuffType, this.manaCheck);
        }

        private void Necroid_MutualDarkness(Unit caster, Unit target)
        {
            string spellName = "Mutual Darkness";
            string negativeEffectType = "Damage";
            double manaRequirment = 0;
            double negativeEffect = 0.07 * caster.MaxHP;
            double damage = (0.15 * caster.MaxHP) - target.CurrentRessistanceValue;
            this.spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, negativeEffect, negativeEffectType, this.manaCheck);
            this.spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        // Paladin
        private void Paladin_HolyStrike(Unit caster, Unit target)
        {
            string spellName = "Holy Strike";
            string effectType = "Magic";
            double effect = 0.10 * caster.MagicPower;
            double manaRequirment = 0.15 * caster.MaxMana;
            double damage = caster.CurrentAttackPower - (0.7 * target.CurrentArmorValue);
            this.spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, effect, effectType, this.manaCheck);
            this.spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Paladin_BurningLight(Unit caster, Unit target)
        {
            string spellName = "Burning Light";
            double manaRequirment = 0.15 * caster.MaxMana;
            double damage = (1.2 * caster.CurrentMagicPower) - target.CurrentRessistanceValue;
            this.spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Paladin_ViciousSpellGuard(Unit caster, Unit target)
        {
            string spellName = "Vicious Spell Guard";
            string buffType = "Res";
            double effect = 0.5 * caster.RessistanceValue;
            double manaRequirment = 0.3 * caster.MaxMana;
            this.spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType, this.manaCheck);
        }

        private void Paladin_DivineRune(Unit caster, Unit target)
        {
            string spellName = "Divine Rune";
            string buffType = "Attack";
            double effect = 0.15 * caster.AttackPower;
            double manaRequirment = 0.2 * caster.MaxMana;
            this.spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType, this.manaCheck);
        }

        // Priest
        private void Priest_HolyLight(Unit caster, Unit target)
        {
            string spellName = "Holy Light";
            double manaRequirment = 0.3 * caster.MaxMana;
            double effect = (0.1 * caster.MaxHP) + caster.CurrentMagicPower;
            this.spellCheck.HealCheck.Check(caster, caster, manaRequirment, effect, spellName, this.manaCheck);
        }

        private void Priest_ManaDrain(Unit caster, Unit target)
        {
            string spellName = "Mana Drain";
            string buffType = "Mana";
            string negativeEffectType = "Mana";
            double buffEffect = 0.20 * target.MaxMana;
            double negativeEffect = 0.20 * target.MaxMana;
            double manaRequirment = 0.08 * caster.MaxMana;
            this.spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, negativeEffect, negativeEffectType, this.manaCheck);
            this.spellCheck.BuffCheck.Check(caster, caster, manaRequirment, buffEffect, spellName, buffType, this.manaCheck);
        }

        private void Priest_StaffSmash(Unit caster, Unit target)
        {
            string spellName = "Staff Smash";
            string negativeEffectType = "Armor";
            double manaRequirment = 0.14 * caster.MaxMana;
            double damage = (1.22 * caster.CurrentAttackPower) - target.CurrentArmorValue;
            double negativeEffect = 0.18 * target.ArmorValue;
            this.spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, negativeEffect, negativeEffectType, this.manaCheck);
            this.spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Priest_Blessing(Unit caster, Unit target)
        {
            string spellName = "Blessing";
            string buffType = "Magic";
            string effectType = "hRegen";
            double buffEffect = 0.25 * caster.MagicPower;
            double effect = caster.Level * 2;
            double manaRequirment = 0.4 * caster.MaxMana;
            this.spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, effect, effectType, this.manaCheck);
            this.spellCheck.BuffCheck.Check(caster, caster, manaRequirment, buffEffect, spellName, buffType, this.manaCheck);
        }

        // Rogue
        private void Rogue_Stab(Unit caster, Unit target)
        {
            string spellName = "Stab";
            string posssitiveEffectType = "Attack";
            double effect = 0.1 * caster.AttackPower;
            double damage = (1.05 * caster.CurrentAttackPower) - target.CurrentArmorValue;
            double manaRequirment = 0.11 * caster.MaxMana;
            this.spellCheck.PositiveEffectCheck.Check(caster, target, manaRequirment, effect, posssitiveEffectType, this.manaCheck);
            this.spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Rogue_PoisonDagger(Unit caster, Unit target)
        {
            string spellName = "Poison Dagger";
            double damage = (0.2 * caster.CurrentAttackPower) + (1.1 * caster.CurrentMagicPower);
            double manaRequirment = 0.28 * caster.MaxMana;
            this.spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Rogue_Evasion(Unit caster, Unit target)
        {
            string spellName = "Evasion";
            string buffType = "Armor";
            string effectType = "mRegen";
            double manaRequirment = 0.4 * caster.MaxMana;
            double buffEffect = 0.5 * caster.ArmorValue;
            double effect = caster.Level * 2;
            this.spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, effect, effectType, this.manaCheck);
            this.spellCheck.BuffCheck.Check(caster, caster, manaRequirment, buffEffect, spellName, buffType, this.manaCheck);
        }

        private void Rogue_Thievery(Unit caster, Unit target)
        {
            string spellName = "Thievery";
            string buffType = "Gold";
            double effect = (target.MaxHP / 20) + (caster.Level * 2);
            double manaRequirment = 0.5 * caster.MaxMana;
            this.spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType, this.manaCheck);
        }

        // Shaman
        private void Shaman_ThunderStrike(Unit caster, Unit target)
        {
            string spellName = "Thunder Strike";
            string negativeEffectType = "Res";
            double damage = (1.2 * caster.CurrentMagicPower) + (0.20 * caster.CurrentAttackPower) - target.CurrentRessistanceValue;
            double negativeEffect = 0.4 * target.RessistanceValue;
            double manaRequirment = 0.5 * caster.MaxMana;
            this.spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, negativeEffect, negativeEffectType, this.manaCheck);
            this.spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Shaman_EarthStrike(Unit caster, Unit target)
        {
            string spellName = "Earth Strike";
            string possitiveEffectType = "Health";
            double manaRequirment = 0.4 * caster.MaxMana;
            double damage = (1.2 * caster.CurrentAttackPower) + (0.20 * caster.CurrentMagicPower) - target.CurrentArmorValue;
            double possitiveEffect = 0.5 * caster.CurrentAttackPower;
            this.spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType, this.manaCheck);
            this.spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Shaman_FlameStrike(Unit caster, Unit target)
        {
            string spellName = "Flame Strike";
            string possitiveEffectType = "Attack";
            double manaRequirment = 0.25 * caster.MaxMana;
            double damage = (1.2 * caster.CurrentAttackPower) - (target.CurrentArmorValue * 0.5) + (target.CurrentRessistanceValue * 0.5);
            double possitiveEffect = 0.15 * caster.AttackPower;
            this.spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType, this.manaCheck);
            this.spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }

        private void Shaman_WaterStrike(Unit caster, Unit target)
        {
            string spellName = "Water Strike";
            string possitiveEffectType = "mRegen";
            double manaRequirment = 0.25 * caster.MaxMana;
            double damage = (1.1 * caster.CurrentMagicPower) - target.CurrentRessistanceValue;
            int possitiveEffect = 2 * caster.Level;
            this.spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType, this.manaCheck);
            this.spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName, this.manaCheck);
        }
    }
}
