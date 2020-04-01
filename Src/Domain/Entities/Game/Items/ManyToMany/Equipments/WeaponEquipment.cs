namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    public class WeaponEquipment
    {
        public int WeaponId { get; set; }

        public Weapon Weapon { get; set; }

        public string EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
