namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Units;

    public class TrinketInventory
    {
        public long TrinketId { get; set; }

        public Trinket Trinket { get; set; }

        public long HeroId { get; set; }

        public Hero Hero { get; set; }

        public int Count { get; set; }
    }
}
