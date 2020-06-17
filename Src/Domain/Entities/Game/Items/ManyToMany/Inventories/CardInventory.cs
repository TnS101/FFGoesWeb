namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class CardInventory
    {
        public long CardId { get; set; }

        public Card Card { get; set; }

        public long InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
