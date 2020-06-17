namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    public class CardEquipment
    {
        public long CardId { get; set; }

        public Card Card { get; set; }

        public long EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
