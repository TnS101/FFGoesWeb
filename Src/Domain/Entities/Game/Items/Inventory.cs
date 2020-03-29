namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;

    public class Inventory
    {
        public Inventory(int heroId)
        {
            this.ArmorInventories = new HashSet<ArmorInventory>();
            this.WeaponInventories = new HashSet<WeaponInventory>();
            this.TrinketInventories = new HashSet<TrinketInventory>();
            this.MaterialInventories = new HashSet<MaterialInventory>();
            this.TreasureKeyInventories = new HashSet<TreasureKeyInventory>();
            this.TreasureInventories = new HashSet<TreasureInventory>();
            this.HeroId = heroId;
            this.Capacity = 50;
        }

        public int Id { get; set; }

        public int HeroId { get; set; }

        public Hero Hero { get; set; }

        public int Capacity { get; set; }

        public ICollection<ArmorInventory> ArmorInventories { get; set; }

        public ICollection<WeaponInventory> WeaponInventories { get; set; }

        public ICollection<TrinketInventory> TrinketInventories { get; set; }

        public ICollection<MaterialInventory> MaterialInventories { get; set; }

        public ICollection<TreasureKeyInventory> TreasureKeyInventories { get; set; }

        public ICollection<TreasureInventory> TreasureInventories { get; set; }
    }
}
