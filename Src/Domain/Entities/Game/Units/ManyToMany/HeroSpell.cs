namespace Domain.Entities.Game.Units.ManyToMany
{
    public class HeroSpell
    {
        public int SpellId { get; set; }

        public Spell Spell { get; set; }

        public long HeroId { get; set; }

        public Hero Hero { get; set; }
    }
}
