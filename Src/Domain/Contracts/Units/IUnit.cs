﻿namespace Domain.Contracts.Units
{
    public interface IUnit
    {
        string Name { get; set; }

        string Type { get; set; }

        int Level { get; set; }

        double MaxHP { get; set; }

        double CurrentHP { get; set; }

        double HealthRegen { get; set; }

        double CurrentHealthRegen { get; set; }

        double MaxMana { get; set; }

        double CurrentMana { get; set; }

        double ManaRegen { get; set; }

        double CurrentManaRegen { get; set; }

        double AttackPower { get; set; }

        double CurrentAttackPower { get; set; }

        double MagicPower { get; set; }

        double CurrentMagicPower { get; set; }

        double ArmorValue { get; set; }

        double CurrentArmorValue { get; set; }

        double ResistanceValue { get; set; }

        double CurrentResistanceValue { get; set; }

        double CritChance { get; set; }

        double CurrentCritChance { get; set; }

        bool IsStunned { get; set; }

        bool IsSilenced { get; set; }

        bool IsBlinded { get; set; }

        bool IsConfused { get; set; }

        bool IsProvoked { get; set; }

        string ImagePath { get; set; }

        int CoinAmount { get; set; }
    }
}
