namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class TreasureKeyInventory
    {
        public TreasureKeyInventory()
        {
            this.Count = 1;
        }

        public int TreasureKeyId { get; set; }

        public TreasureKey TreasureKey { get; set; }

        public long InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
