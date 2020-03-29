namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class ArmorInventories
    {
        public int ArmorId { get; set; }

        public Armor Armor { get; set; }

        public int InventoryId { get; set; }

        public Inventory Inventory { get; set; }
    }
}
