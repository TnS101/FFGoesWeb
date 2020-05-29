namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    public class WeaponEquipment
    {
        public long WeaponId { get; set; }

        public Weapon Weapon { get; set; }

        public long EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
