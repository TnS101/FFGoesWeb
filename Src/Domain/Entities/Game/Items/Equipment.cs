namespace Domain.Entities.Game.Items
{
    using Domain.Base;
    using System.Collections.Generic;

    public class Equipment
    {
        public Equipment(int unitId)
        {
            Items = new HashSet<Item>();
            this.UnitId = unitId;
            this.Capacity = 50;
        }

        public int Id { get; set; }

        public int UnitId { get; set; }

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
