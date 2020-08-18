namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Units;

    public class RelicInventory
    {
        public long RelicId { get; set; }

        public Relic Relic { get; set; }

        public long HeroId { get; set; }

        public Hero Hero { get; set; }

        public int Count { get; set; }
    }
}
