namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    public class WeaponEquipment
    {
        public ulong WeaponId { get; set; }

        public Weapon Weapon { get; set; }

        public ulong EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
