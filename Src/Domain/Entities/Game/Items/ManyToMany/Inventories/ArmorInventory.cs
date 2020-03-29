namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class ArmorInventory
    {
        public int ArmorId { get; set; }

        public Armor Armor { get; set; }

        public int InventoryId { get; set; }

        public Inventory Inventory { get; set; }
    }
}
