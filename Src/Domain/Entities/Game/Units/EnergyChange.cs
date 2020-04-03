namespace Domain.Entities.Game.Units
{
    using System;

    public class EnergyChange
    {
        public EnergyChange()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string HeroId { get; set; }

        public Hero Hero { get; set; }

        public string Type { get; set; }

        public DateTime LastChangedOn { get; set; }
    }
}
