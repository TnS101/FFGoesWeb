namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class MaterialInventories
    {
        public int MaterialId { get; set; }

        public Material Material { get; set; }

        public int InventoryId { get; set; }

        public Inventory Inventory { get; set; }
    }
}
