namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System.Collections.Generic;

    public class Consumeable
    {
        public Consumeable()
        {
            this.ConsumeableInventories = new HashSet<ConsumeableInventory>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Stat { get; set; }

        public double StatReplenish { get; set; }

        public int HungerReplenish { get; set; }
        
        public int ThirstReplenish { get; set; }

        public string Effect { get; set; }

        public int EffectPower { get; set; }

        public int Duration { get; set; }

        public string ZoneName { get; set; }

        public bool IsCraftable { get; set; }

        public int BuyPrice { get; set; }

        public int SellPrice { get; set; }

        public string ImagePath { get; set; }

        public string Slot { get; set; }

        public ICollection<ConsumeableInventory> ConsumeableInventories { get; set; }
    }
}
