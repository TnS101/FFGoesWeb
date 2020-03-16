using System;

namespace FinalFantasyTryoutGoesWeb.Domain.Entities.Game
{
    public class Spell
    {
        public Spell()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public double ManaRequirment { get; set; }

        public string ClassType { get; set; }

        public string UserType { get; set; }
    }
}
