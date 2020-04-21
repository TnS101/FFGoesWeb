﻿namespace Application.CQ.Admin.GameContent.Spells.Commands.Create
{
    using MediatR;

    public class CreateSpellCommand : IRequest<string>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string BuffOrEffectTarget { get; set; }

        public double Power { get; set; }

        public double ManaRequirement { get; set; }

        public string AdditionalEffect { get; set; }

        public double EffectPower { get; set; }

        public string ClassType { get; set; }

        public double ResistanceAffect { get; set; }

        public double SecondaryPower { get; set; }
    }
}
