﻿namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class LootBoxInventory
    {
        public int LootBoxId { get; set; }

        public LootBox LootBox { get; set; }

        public long InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
