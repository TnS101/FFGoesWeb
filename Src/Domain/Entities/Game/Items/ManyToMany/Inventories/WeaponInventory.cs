namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class WeaponInventory
    {
        public WeaponInventory()
        {
            this.Count = 1;
        }

        public string WeaponId { get; set; }

        public Weapon Weapon { get; set; }

        public string InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
