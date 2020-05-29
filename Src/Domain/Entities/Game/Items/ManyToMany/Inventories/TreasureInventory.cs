namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class TreasureInventory
    {
        public TreasureInventory()
        {
            this.Count = 1;
        }

        public int TreasureId { get; set; }

        public Treasure Treasure { get; set; }

        public long InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
