namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;

    public class Inventory
    {
        public Inventory(long heroId)
        {
            this.ArmorInventories = new HashSet<ArmorInventory>();
            this.WeaponInventories = new HashSet<WeaponInventory>();
            this.TrinketInventories = new HashSet<TrinketInventory>();
            this.MaterialInventories = new HashSet<MaterialInventory>();
            this.LootKeyInventories = new HashSet<LootKeyInventory>();
            this.LootBoxInventories = new HashSet<LootBoxInventory>();
            this.ConsumeableInventories = new HashSet<ConsumeableInventory>();
            this.ToolInventories = new HashSet<ToolInventory>();
            this.RelicInventories = new HashSet<RelicInventory>();
            this.CardInventories = new HashSet<CardInventory>();
            this.ToyInventories = new HashSet<ToyInventory>();
            this.HeroId = heroId;
        }

        public long Id { get; set; }

        public long HeroId { get; set; }

        public Hero Hero { get; set; }

        public int Capacity { get; set; }

        public ICollection<ConsumeableInventory> ConsumeableInventories { get; set; }

        public ICollection<ArmorInventory> ArmorInventories { get; set; }

        public ICollection<WeaponInventory> WeaponInventories { get; set; }

        public ICollection<TrinketInventory> TrinketInventories { get; set; }

        public ICollection<MaterialInventory> MaterialInventories { get; set; }

        public ICollection<LootBoxInventory> LootBoxInventories { get; set; }

        public ICollection<LootKeyInventory> LootKeyInventories { get; set; }

        public ICollection<ToolInventory> ToolInventories { get; set; }

        public ICollection<RelicInventory> RelicInventories { get; set; }

        public ICollection<CardInventory> CardInventories { get; set; }

        public ICollection<ToyInventory> ToyInventories { get; set; }
    }
}
