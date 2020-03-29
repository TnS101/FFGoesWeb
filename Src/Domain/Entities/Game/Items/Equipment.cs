namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;

    public class Equipment
    {
        public Equipment(int heroId)
        {
            this.WeaponEquipments = new HashSet<WeaponEquipment>();
            this.ArmorEquipments = new HashSet<ArmorEquipment>();
            this.TrinketEquipments = new HashSet<TrinketEquipment>();
            this.Capacity = 9;
            this.HeroId = heroId;
        }

        public int Id { get; set; }

        public int HeroId { get; set; }

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

        public ICollection<WeaponEquipment> WeaponEquipments { get; set; }

        public ICollection<ArmorEquipment> ArmorEquipments { get; set; }

        public ICollection<TrinketEquipment> TrinketEquipments { get; set; }
    }
}
