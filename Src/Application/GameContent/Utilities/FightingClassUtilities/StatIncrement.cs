namespace Application.GameContent.Utilities.FightingClassUtilites
{
    using Domain.Base;
    using Domain.Entities.Game.Units;

    public class StatIncrement
    {
        public StatIncrement()
        {
        }

        public void Increment(FightingClass fightingClass, Unit unit)
        {
            unit.ClassType = fightingClass.ClassType;
            unit.MaxHP = fightingClass.MaxHP;
            unit.CurrentHP = fightingClass.MaxHP;
            unit.HealthRegen = fightingClass.HealthRegen;
            unit.CurrentHealthRegen = fightingClass.HealthRegen;
            unit.MaxMana = fightingClass.MaxMana;
            unit.CurrentMana = fightingClass.MaxMana;
            unit.ManaRegen = fightingClass.ManaRegen;
            unit.CurrentManaRegen = fightingClass.ManaRegen;
            unit.AttackPower = fightingClass.AttackPower;
            unit.CurrentAttackPower = fightingClass.AttackPower;
            unit.MagicPower = fightingClass.MagicPower;
            unit.CurrentMagicPower = fightingClass.MagicPower;
            unit.ArmorValue = fightingClass.ArmorValue;
            unit.CurrentArmorValue = fightingClass.ArmorValue;
            unit.RessistanceValue = fightingClass.RessistanceValue;
            unit.CurrentRessistanceValue = fightingClass.RessistanceValue;
            unit.CritChance = fightingClass.CritChance;
            unit.CurrentCritChance = fightingClass.CritChance;
            unit.ImageURL = fightingClass.ImageURL;
            unit.IconURL = fightingClass.IconURL;
        }

        public void MonsterIncrement(Monster baseMonster, Monster monster)
        {
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
            monster.RessistanceValue = baseMonster.RessistanceValue;
            monster.CurrentRessistanceValue = baseMonster.RessistanceValue;
            monster.CritChance = baseMonster.CritChance;
            monster.CurrentCritChance = baseMonster.CritChance;
            monster.ImageURL = baseMonster.ImageURL;
        }
    }
}
