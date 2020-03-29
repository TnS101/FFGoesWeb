namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    public class ArmorEquipment
    {
        public int ArmorId { get; set; }

        public Armor Armor { get; set; }

        public int EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
