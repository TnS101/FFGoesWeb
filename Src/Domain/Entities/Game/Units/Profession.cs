namespace Domain.Entities.Game.Units
{
    using System.Collections.Generic;

    public class Profession
    {
        public Profession()
        {
            this.Heroes = new HashSet<Hero>();
        }
        public int Id { get; set; }

        public string Type { get; set; }

        public double Bonus { get; set; }

        public string Description { get; set; }

        public string ProffesionZone { get; set; }

        public ICollection<Hero> Heroes { get; set; }
    }
}
