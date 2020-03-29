namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class WeaponInventories
    {
        public int WeaponId { get; set; }

        public Weapon Weapon { get; set; }

        public int InventoryId { get; set; }

        public Inventory Inventory { get; set; }
    }
}
