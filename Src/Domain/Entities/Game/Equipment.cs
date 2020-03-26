namespace Domain.Entities.Game
{
    using System;
    using System.Collections.Generic;

    public class Equipment
    {
        public Equipment(string unitId)
        {
            Items = new HashSet<Item>();
            this.Id = Guid.NewGuid().ToString();
            this.UnitId = unitId;
        }

        public string Id { get; set; }

        public string UnitId { get; set; }

        public Unit Unit { get; set; }

        public int Capacity { get; set; }

        public bool HelmetSlot { get; set; }

        public bool ChestplateSlot { get; set; }

        public bool ShoulderSlot { get; set; }

        public bool BracerSlot { get; set; }

        public bool BootsSlot { get; set; }

        public bool LeggingsSlot { get; set; }

        public bool TrinketSlot { get; set; }

        public bool GlovesSlot { get; set; }

        public bool WeaponSlot { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
