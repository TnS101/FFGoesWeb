namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class ToolInventory
    {
        public int ToolId { get; set; }

        public Tool Tool { get; set; }

        public long InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
