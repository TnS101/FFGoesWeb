namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class ArmorInventory
    {
        public long ArmorId { get; set; }

        public Armor Armor { get; set; }

        public long InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
