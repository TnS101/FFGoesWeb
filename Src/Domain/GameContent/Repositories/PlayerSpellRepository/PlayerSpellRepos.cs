namespace FinalFantasyTryoutGoesWeb.Domain.GameContent.Repositories.PlayerSpellRepository
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Validators.SpellCheck;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Validators.SpellChecks.MainStats;

    public class PlayerSpellRepos
    {
        private readonly SpellCheck spellCheck = new SpellCheck();
        private readonly ManaCheck manaCheck = new ManaCheck();

        public PlayerSpellRepos()
        {
        }

        //Warrior
        private void Warrior_HeadSmash(Unit caster, Unit target)
        {
            string spellName = "Head Smash";
            string effectType = "Damage";
            double manaRequirment = 0.5 * caster.MaxMana;
            double effect = 0.08 * caster.MaxHP;
            double damage = caster.CurrentAttackPower * 1.5 - target.CurrentArmorValue;
            spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, effect, effectType,manaCheck);
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Warrior_HyperStrength(Unit caster, Unit target)
        {
            string spellName = "Hyper Strength";
            string buffType = "Attack";
            double effect = 0.3 * caster.CurrentAttackPower;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType,manaCheck);
        }

        private void Warrior_RagingBlow(Unit caster, Unit target)
        {
            string spellName = "Raging Blow";
            string effectType = "mRegen";
            double damage = 1 * caster.AttackPower - 0.8 * target.CurrentArmorValue;
            int effect = caster.Level;
            double manaRequirment = 0.15 * caster.MaxMana;
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, effect, effectType,manaCheck);
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Warrior_Disarm(Unit caster, Unit target)
        {
            string spellName = "Disarm";
            string debuffType = "Armor";
            double effect = 0.75 * target.ArmorValue;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.DeBuffCheck.Check(caster, target, manaRequirment, effect, spellName, debuffType,manaCheck);
        }

        //Hunter
        private void Hunter_HastingArrow(Unit caster, Unit target)
        {
            string spellName = "Hasting Arrow";
            string effectType = "Crit";
            int effect = 5;
            double damage = caster.CurrentAttackPower * 1.2;
            double manaRequirment = caster.MaxMana * 0.2;
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, effect, effectType, manaCheck);
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Hunter_GrassHop(Unit caster, Unit target)
        {
            string spellName = "Grass Hop";
            string buffType = "Armor";
            double effect = 0.70 * caster.ArmorValue;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType,manaCheck);
        }

        private void Hunter_VolleyShot(Unit caster, Unit target)
        {
            string spellName = "Volley Shot";
            double damage = 1.4 * caster.CurrentAttackPower;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Hunter_SharpEye(Unit caster, Unit target)
        {
            string spellName = "Sharp Eye";
            string buffType = "Attack";
            double effect = 0.3 * caster.AttackPower;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType,manaCheck);
        }

        //Mage
        private void Mage_WaterBall(Unit caster, Unit target)
        {
            string spellName = "Water Ball";
            string effectType = "mRegen";
            double manaRequirment = 0.30 * caster.MaxMana;
            int effect = (int)caster.MaxMana / 10;
            double damage = caster.CurrentMagicPower * 0.7 - target.CurrentRessistanceValue;
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, effect, effectType,manaCheck);
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Mage_FireBall(Unit caster, Unit target)
        {
            string spellName = "Fire Ball";
            string effectType = "hRegen";
            double manaRequirment = 0.25 * caster.MaxMana;
            int effect = 1;
            double damage = target.MaxHP * 0.05 + caster.CurrentMagicPower * 0.7 - target.CurrentRessistanceValue * 0.8;
            spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, effect, effectType,manaCheck);
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Mage_ManaConversion(Unit caster, Unit target)
        {
            string spellName = "Mana Conversion";
            string buffType = "Mana";
            string negativeEffectType = "Armor";
            double manaRequirment = 0;
            double effect = 0.25 * caster.MaxMana;
            double negativeEffect = 0.25 * caster.ArmorValue;
            spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType,manaCheck);
        }

        private void Mage_AllOutBlast(Unit caster, Unit target)
        {
            string spellName = "All-Out Blast!";
            double damage = caster.CurrentMagicPower * 2 - target.CurrentRessistanceValue * 0.8;
            double manaRequirment = caster.MaxMana;
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        //Naturalist
        private void Naturalist_NaturesTouch(Unit caster, Unit target)
        {
            string spellName = "Nature's Touch";
            string effectType = "Armor";
            double armorIncrease = target.ArmorValue * 0.2;
            double manaRequirment = 0.5 * caster.MaxMana;
            double effect = caster.CurrentMagicPower * 0.5 + caster.CurrentManaRegen;
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, armorIncrease, effectType,manaCheck);
            spellCheck.HealCheck.Check(caster, target, manaRequirment, effect, spellName,manaCheck);
        }

        private void Naturalist_ThornBlast(Unit caster, Unit target)
        {
            string spellName = "Thorn Blast";
            string effectType = "Armor";
            double manaRequirment = 0.35 * caster.MaxMana;
            double effect = target.ArmorValue * 0.3;
            double damage = target.MaxHP * 0.05 + caster.CurrentMagicPower * 0.8 - target.CurrentRessistanceValue;
            spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, effect, effectType,manaCheck);
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
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
            spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType,manaCheck);
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, buffEffect, spellName, buffEffectType,manaCheck);
        }

        private void Naturalist_PouringRain(Unit caster, Unit target)
        {
            string spellname = "Pouring Rain";
            string buffType = "Mana";
            string negativeEffectType = "mRegen";
            double manaRequirment = 0;
            double possitiveEffect = 0.3 * caster.MaxMana;
            int negativeEffect = caster.Level;
            spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, possitiveEffect, spellname, buffType,manaCheck);
        }

        //Necroid
        private void Necroid_ShadowTouch(Unit caster, Unit target)
        {
            string spellName = "Shadow Touch";
            string effectType = "Res";
            double manaRequirment = 0.25 * caster.MaxMana;
            double effect = 3;
            double damage = target.MaxHP * 0.08 + caster.CurrentMana * 0.10 - target.CurrentRessistanceValue;
            spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, effect, effectType,manaCheck);
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Necroid_LifeDrain(Unit caster, Unit target)
        {
            string spellName = "Life Drain";
            string effectType = "SelfHP";
            double manaRequirment = 0.35 * caster.MaxMana;
            double effect = target.MaxHP * 0.5 + caster.CurrentMagicPower * 0.5;
            double damage = effect - target.CurrentRessistanceValue;
            spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, damage, effectType,manaCheck);
            spellCheck.HealCheck.Check(caster, target, manaRequirment, effect, spellName,manaCheck);
        }

        private void Necroid_Blind(Unit caster, Unit target)
        {
            string spellName = "Blind";
            string debuffType = "Attack";
            double manaRequirment = 0.15 * caster.MaxMana;
            double negativeEffect = 0.2 * target.CurrentAttackPower;
            spellCheck.DeBuffCheck.Check(caster, target, manaRequirment, negativeEffect, spellName, debuffType,manaCheck);
        }

        private void Necroid_MutualDarkness(Unit caster, Unit target)
        {
            string spellName = "Mutual Darkness";
            string negativeEffectType = "Damage";
            double manaRequirment = 0;
            double negativeEffect = 0.08 * caster.MaxHP;
            double damage = 0.15 * caster.MaxHP - target.CurrentRessistanceValue;
            spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        //Paladin
        private void Paladin_HolyStrike(Unit caster, Unit target)
        {
            string spellName = "Holy Strike";
            string effectType = "Magic";
            double effect = 0.10 * caster.MagicPower;
            double manaRequirment = 0.15 * caster.MaxMana;
            double damage = 1.1 * caster.CurrentAttackPower - 0.5 * target.CurrentArmorValue;
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, effect, effectType,manaCheck);
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Paladin_BurningLight(Unit caster, Unit target)
        {
            string spellName = "Burning Light";
            double manaRequirment = 0.15 * caster.MaxMana;
            double damage = 1.15 * caster.CurrentMagicPower;
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Paladin_ViciousSpellGuard(Unit caster, Unit target)
        {
            string spellName = "Vicious SpellGuard";
            string buffType = "Res";
            double effect = 0.5 * caster.RessistanceValue;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType,manaCheck);
        }

        private void Paladin_DivineRune(Unit caster, Unit target)
        {
            string spellName = "Divine Rune";
            string buffType = "Attack";
            double effect = 0.15 * caster.AttackPower;
            double manaRequirment = 0.15 * caster.MaxMana;
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType,manaCheck);
        }

        //Priest
        private void Priest_HolyLight(Unit caster, Unit target)
        {
            string spellName = "Holy Light";
            double manaRequirment = 0.3 * caster.MaxMana;
            double effect = 0.1 * caster.MaxHP + caster.CurrentMagicPower;
            spellCheck.HealCheck.Check(caster, caster, manaRequirment, effect, spellName,manaCheck);
        }

        private void Priest_ManaDrain(Unit caster, Unit target)
        {
            string spellName = "Mana Drain";
            string buffType = "Mana";
            string negativeEffectType = "Mana";
            double buffEffect = 0.25 * target.MaxMana;
            double negativeEffect = 0.25 * target.MaxMana;
            double manaRequirment = 0.10 * caster.MaxHP;
            spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, buffEffect, spellName, buffType,manaCheck);
        }

        private void Priest_StaffSmash(Unit caster, Unit target)
        {
            string spellName = "Staff Smash";
            string negativeEffectType = "Armor";
            double manaRequirment = 0.12 * caster.MaxMana;
            double damage = 1.3 * caster.CurrentAttackPower - target.CurrentArmorValue;
            double negativeEffect = 0.2 * target.ArmorValue;
            spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Priest_Blessing(Unit caster, Unit target)
        {
            string spellName = "Blessing";
            string buffType = "Magic";
            string effectType = "hRegen";
            double buffEffect = 0.25 * caster.MagicPower;
            double effect = caster.Level + 1;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, effect, effectType,manaCheck);
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType,manaCheck);
        }

        //Rogue
        private void Rogue_Stab(Unit caster, Unit target)
        {
            string spellName = "Stab";
            string posssitiveEffectType = "Attack";
            double effect = 0.1 * caster.AttackPower;
            double damage = 1.1 * caster.CurrentAttackPower - target.CurrentArmorValue;
            double manaRequirment = 0.12 * caster.MaxMana;
            spellCheck.PositiveEffectCheck.Check(caster, target, manaRequirment, effect, posssitiveEffectType,manaCheck);
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Rogue_PoisonDagger(Unit caster, Unit target)
        {
            string spellName = "Poison Dagger";
            double damage = (0.2 * caster.CurrentAttackPower + 1.2 * caster.CurrentMagicPower);
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Rogue_Evasion(Unit caster, Unit target)
        {
            string spellName = "Evasion";
            string buffType = "Armor";
            string effectType = "mRegen";
            double manaRequirment = 0.5 * caster.MaxHP;
            double buffEffect = 0.5 * caster.ArmorValue;
            double effect = caster.Level;
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, effect, effectType,manaCheck);
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, buffEffect, spellName, buffType,manaCheck);
        }

        private void Rogue_Thievery(Unit caster, Unit target)
        {
            string spellName = "Thievery";
            string buffType = "Gold";
            double effect = 10 + caster.Level * 2;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType,manaCheck);
        }

        //Shaman
        private void Shaman_ThunderStrike(Unit caster, Unit target)
        {
            string spellName = "Thunder Strike";
            string negativeEffectType = "Res";
            double damage = 1.2 * caster.CurrentMagicPower + 0.25 * caster.CurrentAttackPower - target.CurrentRessistanceValue;
            double negativeEffect = 0.5 * target.RessistanceValue;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Shaman_EarthStrike(Unit caster, Unit target)
        {
            string spellName = "Earth Strike";
            string possitiveEffectType = "Health";
            double manaRequirment = 0.5 * caster.MaxMana;
            double damage = 1.2 * caster.CurrentAttackPower + 0.20 * caster.CurrentMagicPower - target.CurrentArmorValue;
            double possitiveEffect = 0.5 * caster.CurrentAttackPower;
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType,manaCheck);
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Shaman_FlameStrike(Unit caster, Unit target)
        {
            string spellName = "Flame Strike";
            string possitiveEffectType = "Attack";
            double manaRequirment = 0.25 * caster.MaxMana;
            double damage = 1.2 * caster.CurrentAttackPower - target.CurrentArmorValue;
            double possitiveEffect = 0.15 * caster.AttackPower;
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType,manaCheck);
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Shaman_WaterStrike(Unit caster, Unit target)
        {
            string spellName = "Water Strike";
            string possitiveEffectType = "mRegen";
            double manaRequirment = 0.25 * caster.MaxMana;
            double damage = 1.1 * caster.CurrentMagicPower - target.CurrentRessistanceValue;
            int possitiveEffect = 5 + caster.Level;
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType,manaCheck);
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }
    }
}
