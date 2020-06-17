namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class ToyInventory
    {
        public int ToyId { get; set; }

        public Toy Toy { get; set; }

        public long InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
