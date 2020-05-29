namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    public class ArmorEquipment
    {
        public long ArmorId { get; set; }

        public Armor Armor { get; set; }

        public long EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
