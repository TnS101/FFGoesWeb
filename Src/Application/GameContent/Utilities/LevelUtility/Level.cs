namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.LevelUtility
{
    using global::Domain.Entities.Game;

    public class Level
    {
        public void Up(Unit unit)
        {
            if (unit.XP >= unit.XPCap)
            {
                unit.Level++;
                unit.AttackPower += 2;
                unit.CurrentAttackPower += 2;
                unit.ArmorValue += 1;
                unit.CurrentArmorValue += 1;
                unit.CritChance += 0.05;
                unit.CurrentCritChance += 0.05;
                unit.HealthRegen += 1;
                unit.CurrentHealthRegen += 1;
                unit.MaxHP += 10;
                unit.CurrentHP += 10;
                unit.MagicPower += 3;
                unit.CurrentMagicPower += 3;
                unit.RessistanceValue += 1.5;
                unit.CurrentRessistanceValue += 0.5;
                unit.XPCap += unit.XPCap * 0.20;
                unit.XP = unit.XP - unit.XPCap;
                unit.CurrentHP = unit.MaxHP;
                unit.CurrentMana = unit.CurrentMana;

                if (unit.XP < 0)
                {
                    unit.XP = 0;
                }
            }
        }
    }
}
