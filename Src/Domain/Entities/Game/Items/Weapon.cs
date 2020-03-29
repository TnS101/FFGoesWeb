﻿namespace Domain.Entities.Game.Items
{
    using Domain.Contracts.Items.AdditionalTypes;
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System.Collections.Generic;

    public class Weapon : IBaseItem
    {
        public Weapon()
        {
            this.WeaponEquipments = new HashSet<WeaponEquipments>();
            this.WeaponInventories = new HashSet<WeaponInventories>();
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

        public string ImageURL { get; set; }

        public ICollection<WeaponInventories> WeaponInventories { get; set; }

        public ICollection<WeaponEquipments> WeaponEquipments { get; set; }
    }
}
