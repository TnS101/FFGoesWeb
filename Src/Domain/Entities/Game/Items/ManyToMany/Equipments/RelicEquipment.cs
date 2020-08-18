namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    using Domain.Entities.Game.Units;

    public class RelicEquipment
    {
        public long RelicId { get; set; }

        public Relic Relic { get; set; }

        public long HeroId { get; set; }

        public Hero Hero { get; set; }
    }
}
