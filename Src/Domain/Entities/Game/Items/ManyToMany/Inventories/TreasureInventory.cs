namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class TreasureInventory
    {
        public string TreasureId { get; set; }

        public Treasure Treasure { get; set; }

        public string InventoryId { get; set; }

        public Inventory Inventory { get; set; }
    }
}
