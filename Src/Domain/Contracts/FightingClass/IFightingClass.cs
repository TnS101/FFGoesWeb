namespace Domain.Contracts.FightingClass
{
    using Domain.Base;
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;

    public interface IFightingClass
    {
        int Id { get; }

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

        ICollection<Hero> Heroes { get; }
    }
}
