namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class ToolInventory
    {
        public ToolInventory()
        {
            this.Count = 1;
        }

        public int ToolId { get; set; }

        public Tool Tool { get; set; }

        public int InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
