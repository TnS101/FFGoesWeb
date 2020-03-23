namespace Domain.Entities.Game
{
    using System;

    public class TreasureKey : Item
    {
        public TreasureKey()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string Rarity { get; set; }

        public string ImageURL { get; set; }
    }
}
