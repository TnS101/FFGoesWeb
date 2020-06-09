namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    public class RelicEquipment
    {
        public long RelicId { get; set; }

        public Relic Relic { get; set; }

        public long EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
