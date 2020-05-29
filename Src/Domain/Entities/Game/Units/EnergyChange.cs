namespace Domain.Entities.Game.Units
{
    using System;

    public class EnergyChange
    {
        public long Id { get; set; }

        public long HeroId { get; set; }

        public Hero Hero { get; set; }

        public string Type { get; set; }

        public DateTime LastChangedOn { get; set; }
    }
}
