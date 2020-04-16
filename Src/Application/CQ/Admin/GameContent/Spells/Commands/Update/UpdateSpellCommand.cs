namespace Application.CQ.Admin.GameContent.Spells.Commands.Update
{
    using MediatR;

    public class UpdateSpellCommand : IRequest<string>
    {
        public int SpellId { get; set; }

        public string NewName { get; set; }

        public string NewType { get; set; }

        public string NewBuffOrEffectTarget { get; set; }

        public double NewPower { get; set; }

        public double NewManaRequirement { get; set; }

        public string NewAdditionalEffect { get; set; }

        public double NewEffectPower { get; set; }

        public string NewClassType { get; set; }

        public double NewResistanceAffect { get; set; }

        public double NewSecondaryPower { get; set; }
    }
}
