namespace Domain.Entities.Game
{
    using System;
    using System.Collections.Generic;

    public class Inventory
    {
        public Inventory(string unitId)
        {
            Items = new HashSet<Item>();
            this.Id = Guid.NewGuid().ToString();
            this.UnitId = unitId;
        }

        public string Id { get; set; }

        public string UnitId { get; set; }

        public Unit Unit { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
