namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class TrinketInventory
    {
        public TrinketInventory()
        {
            this.Count = 1;
        }

        public ulong TrinketId { get; set; }

        public Trinket Trinket { get; set; }

        public ulong InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
