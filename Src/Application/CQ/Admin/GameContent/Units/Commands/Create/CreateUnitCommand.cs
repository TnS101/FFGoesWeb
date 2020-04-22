﻿namespace Application.CQ.Admin.GameContent.Units.Commands.Create
{
    using MediatR;

    public class CreateUnitCommand : IRequest<string>
    {
        public string Name { get; set; }

        public string ClassType { get; set; }

        public double MaxHP { get; set; }

        public double HealthRegen { get; set; }

        public double MaxMana { get; set; }

        public double ManaRegen { get; set; }

        public double AttackPower { get; set; }

        public double MagicPower { get; set; }

        public double ArmorValue { get; set; }

        public double ResistanceValue { get; set; }

        public double CritChance { get; set; }

        public string Description { get; set; }

        public string UnitType { get; set; }
    }
}