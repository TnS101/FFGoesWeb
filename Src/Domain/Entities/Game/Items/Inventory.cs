namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;

    public class Inventory
    {
        public Inventory(int heroId)
        {
            this.ArmorInventories = new HashSet<ArmorInventories>();
            this.WeaponInventories = new HashSet<WeaponInventories>();
            this.TrinketInventories = new HashSet<TrinketInventories>();
            this.MaterialInventories = new HashSet<MaterialInventories>();
            this.TreasureKeyInventories = new HashSet<TreasureKeyInventories>();
            this.TreasureInventories = new HashSet<TreasureInventories>();
            this.HeroId = heroId;
            this.Capacity = 50;
        }

        public int Id { get; set; }

        public int HeroId { get; set; }

        public int Capacity { get; set; }

        public Hero Hero { get; set; }

        public ICollection<ArmorInventories> ArmorInventories { get; set; }

        public ICollection<WeaponInventories> WeaponInventories { get; set; }

        public ICollection<TrinketInventories> TrinketInventories { get; set; }

        public ICollection<MaterialInventories> MaterialInventories { get; set; }

        public ICollection<TreasureKeyInventories> TreasureKeyInventories { get; set; }

        public ICollection<TreasureInventories> TreasureInventories { get; set; }
    }
}
