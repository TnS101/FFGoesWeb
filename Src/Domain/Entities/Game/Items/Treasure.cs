namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System.Collections.Generic;

    public class Treasure
    {
        public Treasure()
        {
            this.TreasureInventories = new HashSet<TreasureInventory>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Rarity { get; set; }

        public int Reward { get; set; }

        public string ImagePath { get; set; }

        public string Slot { get; set; }

        public ICollection<TreasureInventory> TreasureInventories { get; set; }
    }
}
