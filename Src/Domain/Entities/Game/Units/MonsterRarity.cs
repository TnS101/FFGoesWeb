namespace Domain.Entities.Game.Units
{
    using System.Collections.Generic;

    public class MonsterRarity
    {
        public MonsterRarity()
        {
            this.Monsters = new HashSet<Monster>();
        }

        public int Id { get; set; }

        public double StatAmplifier { get; set; }

        public string MonsterName { get; set; }

        public string Rarity { get; set; }

        public string ImageURL { get; set; }

        public ICollection<Monster> Monsters { get; set; }
    }
}
