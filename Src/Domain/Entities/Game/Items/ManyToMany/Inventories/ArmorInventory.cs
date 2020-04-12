namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class ArmorInventory
    {
        public ArmorInventory()
        {
            this.Count = 1;
        }

        public int? ArmorId { get; set; }

        public Armor Armor { get; set; }

        public string InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
