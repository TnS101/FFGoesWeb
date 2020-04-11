namespace Domain.Entities.Game.Units
{
    public class HeroSpells
    {
        public int SpellId { get; set; }

        public Spell Spell { get; set; }

        public string HeroId { get; set; }

        public Hero Hero { get; set; }
    }
}
