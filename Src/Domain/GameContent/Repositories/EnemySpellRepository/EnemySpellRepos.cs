namespace FinalFantasyTryoutGoesWeb.Domain.GameContent.Repositories.EnemySpellRepository
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Validators.SpellCheck;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Validators.SpellChecks.MainStats;
    

    public class EnemySpellRepos
    {
        private static readonly SpellCheck spellCheck = new SpellCheck();
        private readonly ManaCheck manaCheck = spellCheck.ManaCheck;

        public EnemySpellRepos()
        {
        }

        private void Beast_FuriousRoar(Unit caster, Unit target)
        {
            string spellName = "Furious Roar";
            string buffType = "Attack";
            double effect = 0.2 * caster.AttackPower;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType, manaCheck);
        }

        private void Beast_Bite(Unit caster, Unit target)
        {
            string spellName = "Bite";
            string effectType = "hRegen";
            int effect = 1;
            double manaRequirment = 0.2 * caster.MaxMana;
            double damage = caster.AttackPower * 1.2 - target.CurrentArmorValue;
            spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, effect, effectType, manaCheck);
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName, manaCheck);
        }

        private void Beast_ThickHide(Unit caster, Unit target)
        {
            string spellName = "Thick Hide";
            string buffType = "Armor";
            double effect = caster.ArmorValue * 0.8;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType, manaCheck);
        }

        private void Beast_LickWounds(Unit caster, Unit target)
        {
            string spellName = "Lick Wounds";
            string negativeEffectType = "Attack";
            double healEffect = 0.2 * caster.MaxHP;
            double negativeEffect = 0.15 * caster.AttackPower;
            double manaRequirment = 0.4 * caster.MaxMana;
            spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, negativeEffect, negativeEffectType, manaCheck);
            spellCheck.HealCheck.Check(caster, caster, manaRequirment, healEffect, spellName,manaCheck);
        }

        //Demon
        private void Demon_Corruption(Unit caster, Unit target)
        {
            string spellName = "Corruption";
            string debuffType = "hRegen";
            int effect = caster.Level;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.DeBuffCheck.Check(caster, target, manaRequirment, effect, spellName, debuffType,manaCheck);
        }

        private void Demon_ShadowBlast(Unit caster, Unit target)
        {
            string spellName = "Shadow Blast";
            double damage = 1.2 * caster.CurrentMagicPower - target.CurrentRessistanceValue;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Demon_EyeOfTheVoid(Unit caster, Unit target)
        {
            string spellName = "Eye Of The Void";
            string debuffType = "Res";
            double effect = 0.4 * target.RessistanceValue;
            double manaRequirment = 0.2 * caster.MaxMana;
            spellCheck.DeBuffCheck.Check(caster, target, manaRequirment, effect, spellName, debuffType,manaCheck);
        }

        private void Demon_RippingHellFire(Unit caster, Unit target)
        {
            string spellName = "Ripping Hell-Fire";
            double damage = 1.5 * caster.CurrentMagicPower - target.RessistanceValue;
            double manaRequirment = 0.8 * caster.MaxMana;
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        //Giant
        private void Giant_OverGrowth(Unit caster, Unit target)
        {
            string spellName = "Overgrowth";
            string buffType = "Attack";
            string negativeEffectType = "hRegen";
            double effect = 0.35 * caster.ArmorValue;
            int negativeEffect = caster.Level;
            double manaRequirment = 0.4 * caster.MaxMana;
            spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType,manaCheck);
        }

        private void Giant_CalmingMind(Unit caster, Unit target)
        {
            string spellName = "Calming Mind";
            string buffType = "mRegen";
            int effect = 2 + caster.Level;
            double manaRequirment = 0.1 * caster.MaxMana;
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, effect, spellName, buffType,manaCheck);
        }

        private void Giant_RagingMind(Unit caster, Unit target)
        {
            string spellName = "Raging Mind";
            string buffType = "Attack";
            string negativeEffectType = "Damage";
            double buffEffect = 0.30 * caster.AttackPower;
            double negativeEffect = 0.20 * caster.MaxHP;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, buffEffect, spellName, buffType,manaCheck);
        }

        private void Giant_OverpoweringFist(Unit caster, Unit target)
        {
            string spellName = "Overpowering Fist";
            double damage = 1.2 * caster.CurrentAttackPower - 0.5 * target.CurrentArmorValue;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        //Gryphon
        private void Gryphon_DivingClaw(Unit caster, Unit target)
        {
            string spellName = "Diving Claw";
            double damage = 1.2 * caster.CurrentArmorValue - 0.5 * target.CurrentArmorValue;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Gryphon_PetrifyingGaze(Unit caster, Unit target)
        {
            string spellName = "Petryfying Gaze";
            string debuffType = "hRegen";
            int effect = target.CurrentHealthRegen;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.DeBuffCheck.Check(caster, target, manaRequirment, effect, spellName, debuffType,manaCheck);
        }

        private void Gryphon_Gust(Unit caster, Unit target)
        {
            string spellName = "Gust";
            string debuffType = "Attack";
            double effect = 0.2 * target.AttackPower;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.DeBuffCheck.Check(caster, target, manaRequirment, effect, spellName, debuffType,manaCheck);
        }

        private void Gryphon_Peck(Unit caster, Unit target)
        {
            string spellName = "Peck";
            double damage = 1.2 * caster.CurrentAttackPower - target.CurrentArmorValue;
            double manaRequirment = 0.2 * caster.MaxMana;
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        //Reptile
        private void Reptile_PoisonSpit(Unit caster, Unit target)
        {
            string spellName = "Poison Spit";
            double damage = 1.2 * caster.CurrentMagicPower - target.CurrentRessistanceValue;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Reptile_ReflectingScales(Unit caster, Unit target)
        {
            string spellName = "Reflecting Scales";
            string effectType = "Armor";
            double damage = 0.5 * target.CurrentAttackPower;
            double manaRequirment = 0.3 * caster.MaxMana;
            double effect = 0.2 * caster.ArmorValue;
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, effect, effectType,manaCheck);
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Reptile_SkinChange(Unit caster, Unit target)
        {
            string spellName = "Skin Change";
            string buffType = "Res";
            string negativeEffectType = "Armor";
            double buffEffect = 0.5 * caster.RessistanceValue;
            double negativeEffect = 0.25 * caster.ArmorValue;
            double manaRequirment = 0.4 * caster.MaxMana;
            spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, buffEffect, spellName, buffType,manaCheck);
        }

        private void Reptile_Scratch(Unit caster, Unit target)
        {
            string spellName = "Scratch";
            double damage = 1.3 * caster.CurrentAttackPower - target.CurrentArmorValue;
            double manaRequirment = 0.15 * caster.MaxMana;
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        //Saint
        private void Saint_SacredWords(Unit caster, Unit target)
        {
            string spellName = "Sacred Words";
            double effect = caster.MagicPower + 0.5 * caster.MaxHP;
            double manaRequirment = 0.4 * caster.MaxMana;
            spellCheck.HealCheck.Check(caster, caster, manaRequirment, effect, spellName,manaCheck);
        }

        private void Saint_Illumination(Unit caster, Unit target)
        {
            string spellName = "Illumination";
            string debuffType = "Magic";
            string negativeEffectType = "mRegen";
            double debuffEffect = 0.3 * caster.MagicPower;
            int negativeEffect = caster.Level + 2;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.DeBuffCheck.Check(caster, target, manaRequirment, debuffEffect, spellName, debuffType,manaCheck);
        }

        private void Saint_HolySmite(Unit caster, Unit target)
        {
            string spellName = "Holy Smite";
            double damage = caster.MagicPower - target.CurrentRessistanceValue;
            double manaRequirment = 0.15 * caster.MaxMana;
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Saint_JudgementDay(Unit caster, Unit target)
        {
            string spellName = "Judgement Day";
            string negativeEffectType = "Mana";
            double damage = 1.3 * caster.CurrentMagicPower - target.CurrentRessistanceValue;
            double negativeEffect = 0.2 * caster.MaxMana;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        //Skeleton
        private void Skeleton_TombStone(Unit caster, Unit target)
        {
            string spellName = "Tomb Stone";
            string buffType = "Armor";
            string negativeEffectType = "hRegen";
            double buffEffect = caster.ArmorValue;
            int negativeEffect = caster.HealthRegen - caster.Level - 2;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, buffEffect, spellName, buffType,manaCheck);
        }

        private void Skeleton_WrathOfTheNecropolis(Unit caster, Unit target)
        {
            string spellName = "Wrath Of The Necropolis";
            double damage = caster.CurrentAttackPower + caster.CurrentMagicPower - target.CurrentArmorValue;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Skeleton_Suffocation(Unit caster, Unit target)
        {
            string spellName = "Suffocation";
            string negativeEffectType = "hRegen";
            double damage = 1.1 * caster.CurrentAttackPower - target.CurrentArmorValue;
            int negativeEffect = caster.CurrentHealthRegen;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Skeleton_HorrifyingScream(Unit caster, Unit target)
        {
            string spellName = "Horrifying Scream";
            string debuffType = "Attack";
            double effect = 0.2 * target.AttackPower;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.DeBuffCheck.Check(caster, target, manaRequirment, effect, spellName, debuffType,manaCheck);
        }

        //Wyrm
        private void Wyrm_TidalSlash(Unit caster, Unit target)
        {
            string spellName = "Tidal Slash";
            string positiveEffectType = "Magic";
            double damage = 1.1 * caster.CurrentMagicPower - target.CurrentRessistanceValue;
            double possitiveEffect = 0.15 * caster.MagicPower;
            double manaRequirment = 0.15 * caster.MaxMana;
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, possitiveEffect, positiveEffectType,manaCheck);
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Wyrm_Dive(Unit caster, Unit target)
        {
            string spellName = "Dive";
            double manaRequirment = 0.3 * caster.MaxMana;
            string buffType = "Armor";
            string possitiveEffectType = "Res";
            double buffEffect = 0.2 * caster.ArmorValue;
            double possitiveEffect = 0.3 * caster.RessistanceValue;
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType,manaCheck);
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, buffEffect, spellName, buffType,manaCheck);
        }

        private void Wyrm_HyperSpeed(Unit caster, Unit target)
        {
            string spellName = "Hyper Speed";
            double manaRequirment = 0.3 * caster.MaxMana;
            string buffType = "hRegen";
            string possitiveEffectType = "mRegen";
            int buffEffect = caster.Level;
            int possitiveEffect = caster.ManaRegen - caster.Level;
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType,manaCheck);
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, buffEffect, spellName, buffType,manaCheck);
        }

        private void Wyrm_Thunder(Unit caster, Unit target)
        {
            string spellName = "Thunder";
            double manaRequirment = 0.5 * caster.MaxMana;
            string negativeEffectType = "Res";
            double damage = 1.3 * caster.CurrentMagicPower - caster.CurrentRessistanceValue;
            double negativeEffect = 0.4 * target.RessistanceValue;
            spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.SpellDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        //Zombie
        private void Zombie_InfectingBite(Unit caster, Unit target)
        {
            string spellName = "Infecting Bite";
            double manaRequirment = 0.4 * caster.MaxMana;
            string negativeEffectType = "hRegen";
            double damage = 1.2 * caster.CurrentAttackPower - target.CurrentArmorValue;
            int negativeEffect = caster.CurrentHealthRegen;
            spellCheck.NegativeEffectCheck.Check(caster, target, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Zombie_Feed(Unit caster, Unit target)
        {
            string spellName = "Feed";
            double manaRequirment = 0.5 * caster.MaxMana;
            string possitiveEffectType = "Health";
            double damage = 1.3 * caster.CurrentAttackPower - target.CurrentArmorValue;
            double possitiveEffect = 0.3 * caster.MaxHP;
            spellCheck.PositiveEffectCheck.Check(caster, target, manaRequirment, possitiveEffect, possitiveEffectType,manaCheck);
            spellCheck.PhysicalDamageCheck.Check(caster, target, manaRequirment, damage, spellName,manaCheck);
        }

        private void Zombie_Mutation(Unit caster, Unit target)
        {
            string spellName = "Mutation";
            double manaRequirment = 0.5 * caster.MaxMana;
            string buffType = "Attack";
            string possitiveEffectType = "Health";
            double buffEffect = 0.4 * caster.AttackPower;
            double possitiveEffect = 0.3 * caster.MaxHP;
            spellCheck.PositiveEffectCheck.Check(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType,manaCheck);
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, buffEffect, spellName, buffType,manaCheck);
        }

        private void Zombie_Decay(Unit caster, Unit target)
        {
            string spellName = "Decay";
            double manaRequirment = 0.1 * caster.MaxMana;
            string buffType = "Armor";
            string negativeEffectType = "hRegen";
            double buffEffect = 0.3 * caster.ArmorValue;
            double negativeEffect = caster.Level;
            spellCheck.NegativeEffectCheck.Check(caster, caster, manaRequirment, negativeEffect, negativeEffectType,manaCheck);
            spellCheck.BuffCheck.Check(caster, caster, manaRequirment, buffEffect, spellName, buffType,manaCheck);
        }
    }
}
