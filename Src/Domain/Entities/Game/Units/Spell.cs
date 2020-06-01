namespace Domain.Entities.Game.Units
{
    public class Spell
    {
        public int Id { get; set; }

        public int? FightingClassId { get; set; }

        public FightingClass FightingClass { get; set; }

        public int? MonsterId { get; set; }

        public Monster Monster { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string BuffOrEffectTarget { get; set; }

        public double Power { get; set; }

        public double ManaRequirement { get; set; }

        public string AdditionalEffect { get; set; }

        public double EffectPower { get; set; }

        public double ResistanceAffect { get; set; }

        public double SecondaryPower { get; set; }
    }
}
