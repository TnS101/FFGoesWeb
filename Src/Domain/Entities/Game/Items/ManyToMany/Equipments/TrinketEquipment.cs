namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    public class TrinketEquipment
    {
        public int TrinketId { get; set; }

        public Trinket Trinket { get; set; }

        public string EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
