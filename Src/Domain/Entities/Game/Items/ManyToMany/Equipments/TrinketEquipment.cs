namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    using Domain.Entities.Game.Units;

    public class TrinketEquipment
    {
        public long TrinketId { get; set; }

        public Trinket Trinket { get; set; }

        public long HeroId { get; set; }

        public Hero Hero { get; set; }
    }
}
