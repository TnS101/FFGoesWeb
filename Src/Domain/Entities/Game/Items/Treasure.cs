namespace Domain.Entities.Game.Items
{
    using Domain.Base;

    public class Treasure : Item
    {
        public Treasure()
        {
        }
        public override string Rarity { get; set; }

        public override int Reward { get; set; }

        public override string ImageURL { get; set; }
    }
}
