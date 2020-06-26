using Domain.Entities.Game.Items;
using System.Collections.Generic;

namespace Domain.Entities.Game.Units
{
    public class Spell
    {
        public Spell()
        {
            this.Cards = new HashSet<Card>();
            this.Talents = new HashSet<Talent>();
        }

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

        public string Condition { get; set; }

        public bool SatisfiesCondition { get; set; }

        public ICollection<Card> Cards { get; set; }

        public ICollection<Talent> Talents { get; set; }
    }
}
