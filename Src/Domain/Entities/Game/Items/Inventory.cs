namespace Domain.Entities.Game.Items
{
    using Domain.Base;
    using System.Collections.Generic;

    public class Inventory
    {
        public Inventory(int unitId)
        {
            Items = new HashSet<Item>();
            this.UnitId = unitId;
        }

        public int Id { get; set; }

        public int UnitId { get; set; }

        public Unit Unit { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
