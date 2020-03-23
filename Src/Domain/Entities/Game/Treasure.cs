using System;

namespace Domain.Entities.Game
{
    public class Treasure : Item
    {
        public Treasure()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Rarity { get; set; }

        public int Reward { get; set; }

        public string ImageURL { get; set; }
    }
}
