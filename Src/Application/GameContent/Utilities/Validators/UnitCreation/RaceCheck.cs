namespace Application.GameContent.Utilities.Validators.UnitCreation
{
    using Domain.Entities.Game.Units;

    public class RaceCheck
    {
        public void Check(Hero hero, string race)
        {
            switch (race)
            {
                case "Human": hero.MaxHP += hero.MaxHP * 0.15; hero.CurrentHP = hero.MaxHP; break;
                case "Dwarf": hero.ArmorValue += hero.ArmorValue * 0.20; hero.CurrentArmorValue = hero.ArmorValue; break;
                case "Elf": hero.MagicPower += hero.MagicPower * 0.15; hero.CurrentMagicPower = hero.MagicPower; break;
                case "Orc": hero.AttackPower += 0.10 * hero.AttackPower; hero.CurrentAttackPower = hero.AttackPower; break;
                case "Goblin": hero.ManaRegen += (int)hero.MaxMana / 10; hero.CurrentMana = hero.ManaRegen; break;
                case "Troll": hero.ResistanceValue += 0.30 * hero.ResistanceValue; hero.CurrentResistanceValue = hero.ResistanceValue; break;
                default: return;
            }

            hero.Race = race;
        }
    }
}
