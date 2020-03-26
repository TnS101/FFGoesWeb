namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.UnitCreation
{
    using global::Domain.Entities.Game;

    public class RaceCheck
    {
        public void Check(Unit player, string race)
        {
            if (race == "Human")
            {
                player.Race = "Human";
                player.MaxHP += player.MaxHP * 0.15;
                player.CurrentHP = player.MaxHP;
            }

            if (race == "Dwarf")
            {
                player.Race = "Dwarf";
                player.ArmorValue += player.ArmorValue * 0.20;
                player.CurrentArmorValue = player.ArmorValue;
            }

            if (race == "Elf")
            {
                player.Race = "Elf";
                player.MagicPower += player.MagicPower * 0.15;
                player.CurrentMagicPower = player.MagicPower;
            }

            if (race == "Orc")
            {
                player.Race = "Orc";
                player.AttackPower += 0.10 * player.AttackPower;
                player.CurrentAttackPower = player.AttackPower;
            }

            if (race == "Goblin")
            {
                player.Race = "Goblin";
                player.ManaRegen += (int)player.MaxMana / 10;
                player.CurrentMana = player.ManaRegen;
            }

            if (race == "Troll")
            {
                player.Race = "Troll";
                player.RessistanceValue += 0.30 * player.RessistanceValue;
                player.CurrentRessistanceValue = player.RessistanceValue;
            }
        }
    }
}
