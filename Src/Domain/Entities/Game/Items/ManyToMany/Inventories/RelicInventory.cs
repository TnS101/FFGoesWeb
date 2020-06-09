namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class RelicInventory
    {
        public long RelicId { get; set; }

        public Relic Relic { get; set; }

        public long InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
