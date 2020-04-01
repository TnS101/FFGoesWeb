namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class TreasureInventory
    {
        public int TreasureId { get; set; }

        public Treasure Treasure { get; set; }

        public string InventoryId { get; set; }

        public Inventory Inventory { get; set; }
    }
}
