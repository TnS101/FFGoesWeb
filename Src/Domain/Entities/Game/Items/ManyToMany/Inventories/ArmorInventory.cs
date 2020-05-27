namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    public class ArmorInventory
    {
        public ArmorInventory()
        {
            this.Count = 1;
        }

        public ulong ArmorId { get; set; }

        public Armor Armor { get; set; }

        public ulong InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int Count { get; set; }
    }
}
