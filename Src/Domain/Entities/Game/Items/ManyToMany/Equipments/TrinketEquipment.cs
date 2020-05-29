namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    public class TrinketEquipment
    {
        public long TrinketId { get; set; }

        public Trinket Trinket { get; set; }

        public long EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
