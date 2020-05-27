namespace Domain.Entities.Game.Items
{
    using Domain.Contracts.Items;
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System.Collections.Generic;

    public class Trinket : IEquipableItem
    {
        public Trinket()
        {
            this.TrinketEquipments = new HashSet<TrinketEquipment>();
            this.TrinketInventories = new HashSet<TrinketInventory>();
        }

        public ulong Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public string ClassType { get; set; }

        public int Stamina { get; set; }

        public int Strength { get; set; }

        public int Agility { get; set; }

        public int Intellect { get; set; }

        public int Spirit { get; set; }

        public int SellPrice { get; set; }

        public int BuyPrice { get; set; }

        public string ImagePath { get; set; }

        public bool IsCraftable { get; set; }

        public string Type { get; set; }

        public string Slot { get; set; }

        public ICollection<TrinketInventory> TrinketInventories { get; set; }

        public ICollection<TrinketEquipment> TrinketEquipments { get; set; }
    }
}
