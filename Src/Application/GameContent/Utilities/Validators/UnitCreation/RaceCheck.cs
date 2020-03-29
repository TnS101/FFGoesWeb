﻿namespace Application.GameContent.Utilities.Validators.UnitCreation
{
    using Domain.Entities.Game.Units;

    public class RaceCheck
    {
        public void Check(Hero hero, string race)
        {
            if (race == "Human")
            {
                hero.Race = "Human";
                hero.MaxHP += hero.MaxHP * 0.15;
                hero.CurrentHP = hero.MaxHP;
            }

            if (race == "Dwarf")
            {
                hero.Race = "Dwarf";
                hero.ArmorValue += hero.ArmorValue * 0.20;
                hero.CurrentArmorValue = hero.ArmorValue;
            }

            if (race == "Elf")
            {
                hero.Race = "Elf";
                hero.MagicPower += hero.MagicPower * 0.15;
                hero.CurrentMagicPower = hero.MagicPower;
            }

            if (race == "Orc")
            {
                hero.Race = "Orc";
                hero.AttackPower += 0.10 * hero.AttackPower;
                hero.CurrentAttackPower = hero.AttackPower;
            }

            if (race == "Goblin")
            {
                hero.Race = "Goblin";
                hero.ManaRegen += (int)hero.MaxMana / 10;
                hero.CurrentMana = hero.ManaRegen;
            }

            if (race == "Troll")
            {
                hero.Race = "Troll";
                hero.RessistanceValue += 0.30 * hero.RessistanceValue;
                hero.CurrentRessistanceValue = hero.RessistanceValue;
            }
        }
    }
}
