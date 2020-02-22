namespace FinalFantasyTryoutGoesWeb.Domain.GameContent.Contracts
{
    public interface IFightingClass
    {
        string ClassType { get; }
        double MaxHP { get; }
        int HealthRegen { get; }
        double MaxMana { get; }
        int ManaRegen { get; }
        double AttackPower { get; }
        double ArmorValue { get; }
        double RessistanceValue { get; }
        double MagicPower { get; }
        double CritChance { get; }
    }
}
