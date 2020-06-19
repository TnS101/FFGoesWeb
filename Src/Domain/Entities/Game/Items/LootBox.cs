namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System.Collections.Generic;

    public class LootBox
    {
        public LootBox()
        {
            this.LootBoxInventories = new HashSet<LootBoxInventory>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int RewardAmplifier { get; set; }

        public bool RequiresKey { get; set; }

        public string ImagePath { get; set; }

        public string Slot { get; set; }

        public ICollection<LootBoxInventory> LootBoxInventories { get; set; }
    }
}
