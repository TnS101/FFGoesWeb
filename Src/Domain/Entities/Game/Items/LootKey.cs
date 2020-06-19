namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System.Collections.Generic;

    public class LootKey
    {
        public LootKey()
        {
            this.LootKeyInventories = new HashSet<LootKeyInventory>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string ImagePath { get; set; }

        public string Slot { get; set; }

        public ICollection<LootKeyInventory> LootKeyInventories { get; set; }
    }
}
