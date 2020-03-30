namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class TreasureKeyInventory
    {
        public string TreasureKeyId { get; set; }

        public TreasureKey TreasureKey { get; set; }

        public string InventoryId { get; set; }

        public Inventory Inventory { get; set; }
    }
}
