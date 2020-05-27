namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    public class TrinketEquipment
    {
        public ulong TrinketId { get; set; }

        public Trinket Trinket { get; set; }

        public ulong EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
