namespace Domain.Entities.Game.Items
{
    using Domain.Contracts.Items.AdditionalTypes;
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System;
    using System.Collections.Generic;

    public class Weapon : IBaseItem
    {
        public Weapon()
        {
            this.WeaponEquipments = new HashSet<WeaponEquipment>();
            this.WeaponInventories = new HashSet<WeaponInventory>();
        }

        public int Id { get; set; }

        public double AttackPower { get; set; }

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

        public string ImagePath { get; set; }

        public bool IsCraftable { get; set; }

        public string Type { get; set; }

        public ICollection<WeaponInventory> WeaponInventories { get; set; }

        public ICollection<WeaponEquipment> WeaponEquipments { get; set; }
    }
}
