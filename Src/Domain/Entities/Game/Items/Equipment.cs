namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;

    public class Equipment
    {
        public Equipment(long heroId)
        {
            this.WeaponEquipments = new HashSet<WeaponEquipment>();
            this.ArmorEquipments = new HashSet<ArmorEquipment>();
            this.TrinketEquipments = new HashSet<TrinketEquipment>();
            this.RelicEquipments = new HashSet<RelicEquipment>();
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

        public ICollection<ArmorEquipment> ArmorEquipments { get; set; }

        public ICollection<TrinketEquipment> TrinketEquipments { get; set; }

        public ICollection<WeaponEquipment> WeaponEquipments { get; set; }

        public ICollection<RelicEquipment> RelicEquipments { get; set; }
    }
}
