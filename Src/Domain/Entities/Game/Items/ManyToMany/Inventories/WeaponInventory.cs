﻿namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class WeaponInventory
    {
        public int WeaponId { get; set; }

        public Weapon Weapon { get; set; }

        public string InventoryId { get; set; }

        public Inventory Inventory { get; set; }
    }
}
