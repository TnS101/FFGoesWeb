namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class TreasureInventories
    {
        public int TreasureId { get; set; }

        public Treasure Treasure { get; set; }

        public int InventoryId { get; set; }

        public Inventory Inventory { get; set; }
    }
}
