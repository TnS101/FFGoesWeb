namespace Domain.Entities.Game.Items
{
    using Domain.Base;

    public class Treasure : Item
    {
        public Treasure()
        {
        }
        public string Rarity { get; set; }

        public int Reward { get; set; }

        public override string ImageURL { get; set; }
    }
}
