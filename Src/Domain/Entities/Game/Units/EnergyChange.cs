namespace Domain.Entities.Game.Units
{
    using System;

    public class EnergyChange
    {
        public EnergyChange()
        {
        }

        public ulong Id { get; set; }

        public ulong HeroId { get; set; }

        public Hero Hero { get; set; }

        public string Type { get; set; }

        public DateTime LastChangedOn { get; set; }
    }
}
