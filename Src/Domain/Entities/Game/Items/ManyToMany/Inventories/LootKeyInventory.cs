﻿namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class LootKeyInventory
    {
        public LootKeyInventory()
        {
            this.Count = 1;
        }

        public int LootKeyId { get; set; }

        public LootKey LootKey { get; set; }

        public long InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}