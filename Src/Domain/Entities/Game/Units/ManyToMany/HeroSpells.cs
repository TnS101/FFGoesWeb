namespace Domain.Entities.Game.Units.ManyToMany
{
    public class HeroSpells
    {
        public int SpellId { get; set; }

        public Spell Spell { get; set; }

        public string HeroId { get; set; }

        public Hero Hero { get; set; }
    }
}
