namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Units;

    public class LootBoxInventory
    {
        public int LootBoxId { get; set; }

        public LootBox LootBox { get; set; }

        public long HeroId { get; set; }

        public Hero Hero { get; set; }

        public int Count { get; set; }
    }
}
