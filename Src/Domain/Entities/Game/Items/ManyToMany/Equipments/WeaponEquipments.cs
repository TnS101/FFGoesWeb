namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    public class WeaponEquipments
    {
        public int WeaponId { get; set; }

        public Weapon Weapon { get; set; }

        public int EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
