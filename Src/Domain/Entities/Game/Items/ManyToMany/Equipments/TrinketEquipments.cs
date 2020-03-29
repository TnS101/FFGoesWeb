namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    public class TrinketEquipments
    {
        public int TrinketId { get; set; }

        public Trinket Trinket { get; set; }

        public int EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
