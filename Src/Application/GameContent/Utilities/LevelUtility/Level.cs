namespace Application.GameContent.Utilities.LevelUtility
{
    using Domain.Entities.Game.Units;

    public class Level
    {
        public void Up(Hero hero)
        {
            if (hero.XP >= hero.XPCap)
            {
                hero.Level++;
                hero.AttackPower += 2;
                hero.CurrentAttackPower += 2;
                hero.ArmorValue += 1;
                hero.CurrentArmorValue += 1;
                hero.CritChance += 0.05;
                hero.CurrentCritChance += 0.05;
                hero.HealthRegen += 1;
                hero.CurrentHealthRegen += 1;
                hero.MaxHP += 10;
                hero.CurrentHP += 10;
                hero.MagicPower += 3;
                hero.CurrentMagicPower += 3;
                hero.RessistanceValue += 1.5;
                hero.CurrentRessistanceValue += 0.5;
                hero.XPCap += hero.XPCap * 0.20;
                hero.XP = hero.XP - hero.XPCap;
                hero.CurrentHP = hero.MaxHP;
                hero.CurrentMana = hero.CurrentMana;

                if (hero.XP < 0)
                {
                    hero.XP = 0;
                }
            }
        }
    }
}
