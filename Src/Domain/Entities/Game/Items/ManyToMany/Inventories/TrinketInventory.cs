﻿namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class TrinketInventory
    {
        public int TrinketId { get; set; }

        public Trinket Trinket { get; set; }

        public string InventoryId { get; set; }

        public Inventory Inventory { get; set; }
    }
}