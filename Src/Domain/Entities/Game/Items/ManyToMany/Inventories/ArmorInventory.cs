namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Units;

    public class ArmorInventory
    {
        public long ArmorId { get; set; }

        public Armor Armor { get; set; }

        public long HeroId { get; set; }

        public Hero Hero { get; set; }

        public int Count { get; set; }
    }
}
