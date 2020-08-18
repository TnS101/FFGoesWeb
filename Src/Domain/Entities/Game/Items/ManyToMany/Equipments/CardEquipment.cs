namespace Domain.Entities.Game.Items.ManyToMany.Equipments
{
    using Domain.Entities.Game.Units;

    public class CardEquipment
    {
        public long CardId { get; set; }

        public Card Card { get; set; }

        public long HeroId { get; set; }

        public Hero Hero { get; set; }
    }
}
