namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class MaterialInventory
    {
        public int MaterialId { get; set; }

        public Material Material { get; set; }

        public string InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
