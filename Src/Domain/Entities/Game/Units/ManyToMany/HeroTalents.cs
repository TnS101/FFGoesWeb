namespace Domain.Entities.Game.Units.ManyToMany
{
    public class HeroTalents
    {
        public long HeroId { get; set; }

        public Hero Hero { get; set; }

        public int? TalentId { get; set; }
        
        public Talent Talent { get; set; }

        public string Condition { get; set; }
    }
}
