namespace Domain.Contracts.Units
{
    public interface IUnit
    {
        string Name { get; }

        string Type { get; }

        int Level { get; }

        double MaxHP { get; set; }

        double HealthRegen { get; set; }

        double MaxMana { get; set; }

        double ManaRegen { get; set; }

        double AttackPower { get; set; }

        double MagicPower { get; set; }

        double ArmorValue { get; set; }

        double ResistanceValue { get; set; }

        double CritChance { get; set; }
    }
}
