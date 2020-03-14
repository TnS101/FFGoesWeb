namespace Application.Common.Interfaces
{
    public interface IUnitFullViewModel
    {
        string Name { get; set; }

        string ClassType { get; set; }

        string Race { get; set; }

        int Level { get; set; }

        double MaxHP { get; set; }

        double CurrentHP { get; set; }

        double MaxMana { get; set; }

        double CurrentMana { get; set; }

        double AttackPower { get; set; }

        double CurrentAttackPower { get; set; }

        double MagicPower { get; set; }

        double CurrentMagicPower { get; set; }

        double ArmorValue { get; set; }

        double RessistanceValue { get; set; }
    }
}
