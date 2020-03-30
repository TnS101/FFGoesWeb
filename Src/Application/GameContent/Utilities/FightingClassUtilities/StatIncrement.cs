namespace Application.GameContent.Utilities.FightingClassUtilites
{
    using Domain.Entities.Game.Units;

    public class StatIncrement
    {
        public StatIncrement()
        {
        }

        public void Increment(FightingClass fightingClass, Hero hero)
        {
            hero.ClassType = fightingClass.ClassType;
            hero.MaxHP = fightingClass.MaxHP;
            hero.CurrentHP = fightingClass.MaxHP;
            hero.HealthRegen = fightingClass.HealthRegen;
            hero.CurrentHealthRegen = fightingClass.HealthRegen;
            hero.MaxMana = fightingClass.MaxMana;
            hero.CurrentMana = fightingClass.MaxMana;
            hero.ManaRegen = fightingClass.ManaRegen;
            hero.CurrentManaRegen = fightingClass.ManaRegen;
            hero.AttackPower = fightingClass.AttackPower;
            hero.CurrentAttackPower = fightingClass.AttackPower;
            hero.MagicPower = fightingClass.MagicPower;
            hero.CurrentMagicPower = fightingClass.MagicPower;
            hero.ArmorValue = fightingClass.ArmorValue;
            hero.CurrentArmorValue = fightingClass.ArmorValue;
            hero.ResistanceValue = fightingClass.RessistanceValue;
            hero.CurrentResistanceValue = fightingClass.RessistanceValue;
            hero.CritChance = fightingClass.CritChance;
            hero.CurrentCritChance = fightingClass.CritChance;
            hero.ImageURL = fightingClass.ImageURL;
            hero.IconURL = fightingClass.IconURL;
        }

        public void MonsterIncrement(Monster baseMonster, Monster monster)
        {
            monster.Name = baseMonster.Name;
            monster.MaxHP = baseMonster.MaxHP;
            monster.CurrentHP = baseMonster.MaxHP;
            monster.HealthRegen = baseMonster.HealthRegen;
            monster.CurrentHealthRegen = baseMonster.HealthRegen;
            monster.MaxMana = baseMonster.MaxMana;
            monster.CurrentMana = baseMonster.MaxMana;
            monster.ManaRegen = baseMonster.ManaRegen;
            monster.CurrentManaRegen = baseMonster.ManaRegen;
            monster.AttackPower = baseMonster.AttackPower;
            monster.CurrentAttackPower = baseMonster.AttackPower;
            monster.MagicPower = baseMonster.MagicPower;
            monster.CurrentMagicPower = baseMonster.MagicPower;
            monster.ArmorValue = baseMonster.ArmorValue;
            monster.CurrentArmorValue = baseMonster.ArmorValue;
            monster.ResistanceValue = baseMonster.ResistanceValue;
            monster.CurrentResistanceValue = baseMonster.ResistanceValue;
            monster.CritChance = baseMonster.CritChance;
            monster.CurrentCritChance = baseMonster.CritChance;
            monster.ImageURL = baseMonster.ImageURL;
        }
    }
}
