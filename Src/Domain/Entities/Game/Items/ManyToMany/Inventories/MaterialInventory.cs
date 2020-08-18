namespace Domain.Entities.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Units;

    public class MaterialInventory
    {
        public int MaterialId { get; set; }

        public Material Material { get; set; }

        public long HeroId { get; set; }

        public Hero Hero { get; set; }

        public int Count { get; set; }
    }
}
