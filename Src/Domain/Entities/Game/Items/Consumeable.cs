namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System.Collections.Generic;

    public class Consumeable
    {
        public Consumeable()
        {
            this.ConsumeableInventories = new HashSet<ConsumeableInventory>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public double StatReplenish { get; set; }

        public bool IsCraftable { get; set; }

        public ICollection<ConsumeableInventory> ConsumeableInventories { get; set; }
    }
}
