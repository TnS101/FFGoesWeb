namespace FinalFantasyTryoutGoesWeb.Domain.Entities.Game
{
    public class Spell
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double ManaRequirment { get; set; }

        public string ClassType { get; set; }

        public string UserType { get; set; }
    }
}
