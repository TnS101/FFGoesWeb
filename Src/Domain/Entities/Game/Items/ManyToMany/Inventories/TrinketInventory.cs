namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class TrinketInventory
    {
        public long TrinketId { get; set; }

        public Trinket Trinket { get; set; }

        public long InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
