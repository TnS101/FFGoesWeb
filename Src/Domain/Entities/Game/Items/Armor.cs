namespace Domain.Entities.Game.Items
{
    using Domain.Contracts.Items.AdditionalTypes;
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System;
    using System.Collections.Generic;

    public class Armor : IBaseItem
    {
        public Armor()
        {
            this.ArmorInventories = new HashSet<ArmorInventory>();
            this.ArmorEquipments = new HashSet<ArmorEquipment>();
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public double ArmorValue { get; set; }

        public double RessistanceValue { get; set; }

        public string Name { get; set; }

        public string Slot { get; set; }

        public int Level { get; set; }

        public string ClassType { get; set; }

        public int Stamina { get; set; }

        public int Strength { get; set; }

        public int Agility { get; set; }

        public int Intellect { get; set; }

        public int Spirit { get; set; }

        public int SellPrice { get; set; }

        public int BuyPrice { get; set; }

        public string ImageURL { get; set; }

        public ICollection<ArmorInventory> ArmorInventories { get; set; }

        public ICollection<ArmorEquipment> ArmorEquipments { get; set; }
    }
}
