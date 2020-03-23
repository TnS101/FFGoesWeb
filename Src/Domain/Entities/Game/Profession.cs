namespace Domain.Entities.Game
{
    using System;
    using System.Collections.Generic;

    public class Profession
    {
        public Profession()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Units = new HashSet<Unit>();
        }
        public string Id { get; set; }

        public string Type { get; set; }

        public string Bonus { get; set; }

        public ICollection<Unit> Units { get; set; }
    }
}
