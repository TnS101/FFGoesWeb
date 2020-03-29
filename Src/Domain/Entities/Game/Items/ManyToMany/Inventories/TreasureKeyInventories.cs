namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class TreasureKeyInventories
    {
        public int TreasureKeyId { get; set; }

        public TreasureKey TreasureKey { get; set; }

        public int InventoryId { get; set; }

        public Inventory Inventory { get; set; }
    }
}
