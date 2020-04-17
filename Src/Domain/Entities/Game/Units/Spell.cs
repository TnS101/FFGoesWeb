using Domain.Entities.Game.Units.ManyToMany;
using System.Collections.Generic;

namespace Domain.Entities.Game.Units
{
    public class Spell
    {
        public Spell()
        {
            this.HeroSpells = new HashSet<HeroSpells>();
        }

        public int Id { get; set; }

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

        public ICollection<HeroSpells> HeroSpells { get; set; }
    }
}
