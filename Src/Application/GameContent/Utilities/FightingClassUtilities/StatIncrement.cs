namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.FightingClassUtilites
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent;

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
        }
    }
}
