namespace Domain.Contracts.Units
{
    public interface IUnit
    {
        string Name { get; }

        string Type { get; }

        int Level { get; }

        double MaxHP { get; set; }

        int HealthRegen { get; set; }

        double MaxMana { get; set; }

        int ManaRegen { get; set; }

        double AttackPower { get; set; }

        double MagicPower { get; set; }

        double ArmorValue { get; set; }

        double RessistanceValue { get; set; }

        double CritChance { get; set; }

        int GoldAmount { get; }

        string Race { get; set; }

        string Rarity { get; set; }

        string ClassType { get; set; }
    }
}
