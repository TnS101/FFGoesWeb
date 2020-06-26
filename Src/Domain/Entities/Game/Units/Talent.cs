namespace Domain.Entities.Game.Units
{
    using Domain.Entities.Game.Units.ManyToMany;
    using System.Collections.Generic;

    public class Talent
    {
        public Talent()
        {
            this.HeroTalents = new HashSet<HeroTalents>();
        }
        public int Id { get; set; }

        public int FightingClassId { get; set; }

        public FightingClass FightingClass { get; set; }

        public int? SpellId { get; set; }

        public Spell Spell { get; set; }
            
        public string Name { get; set; }    
            
        public string Decsription { get; set; }

        public string Condition { get; set; }

        public ICollection<HeroTalents> HeroTalents { get; set; }
    }
}
