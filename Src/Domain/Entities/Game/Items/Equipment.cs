namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;

    public class Equipment
    {
        public Equipment(long heroId)
        {
            this.WeaponEquipment = new HashSet<WeaponEquipment>();
            this.ArmorEquipment = new HashSet<ArmorEquipment>();
            this.TrinketEquipment = new HashSet<TrinketEquipment>();
            this.RelicEquipment = new HashSet<RelicEquipment>();
            this.CardEquipment = new HashSet<CardEquipment>();
            this.HeroId = heroId;
        }

        public long Id { get; set; }

        public long HeroId { get; set; }

        public Hero Hero { get; set; }

        public int Capacity { get; set; }

        public bool HelmetSlot { get; set; }

        public bool ChestplateSlot { get; set; }

        public bool ShoulderSlot { get; set; }

        public bool BracerSlot { get; set; }

        public bool BootsSlot { get; set; }

        public bool LeggingsSlot { get; set; }

        public bool TrinketSlot { get; set; }

        public bool GlovesSlot { get; set; }

        public bool WeaponSlot { get; set; }

        public bool RelicSlot { get; set; }

        public int CardCount { get; set; }

        public ICollection<ArmorEquipment> ArmorEquipment { get; set; }

        public ICollection<TrinketEquipment> TrinketEquipment { get; set; }

        public ICollection<WeaponEquipment> WeaponEquipment { get; set; }

        public ICollection<RelicEquipment> RelicEquipment { get; set; }

        public ICollection<CardEquipment> CardEquipment { get; set; }
    }
}
