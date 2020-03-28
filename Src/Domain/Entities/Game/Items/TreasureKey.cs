namespace Domain.Entities.Game.Items
{
    using Domain.Base;

    public class TreasureKey : Item
    {
        public TreasureKey()
        {
        }
        public override string Rarity { get; set; }

        public override string ImageURL { get; set; }
    }
}
