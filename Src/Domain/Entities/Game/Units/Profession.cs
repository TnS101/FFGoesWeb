namespace Domain.Entities.Game.Units
{
    using System;
    using System.Collections.Generic;

    public class Profession
    {
        public Profession()
        {
            this.Heroes = new HashSet<Hero>();
        }
        public int Id { get; set; }

        public string Type { get; set; }

        public string Bonus { get; set; }

        public ICollection<Hero> Heroes { get; set; }
    }
}
