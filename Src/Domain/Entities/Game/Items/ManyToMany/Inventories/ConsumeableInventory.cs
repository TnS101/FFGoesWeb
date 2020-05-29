namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class ConsumeableInventory
    {
        public ConsumeableInventory()
        {
            this.Count = 1;
        }

        public int ConsumeableId { get; set; }

        public Consumeable Consumeable { get; set; }

        public long InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
