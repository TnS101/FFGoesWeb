namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class ConsumeableInventory
    {
        public int ConsumeableId { get; set; }

        public Consumeable Consumeable { get; set; }

        public int InventoryId { get; set; }

        public Inventory Inventory { get; set; }
    }
}
