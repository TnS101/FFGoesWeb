namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    public class ArmorEquipment
    {
        public ulong ArmorId { get; set; }

        public Armor Armor { get; set; }

        public ulong EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
