namespace FinalFantasyTryoutGoesWeb.Domain.Entities.Game
{
    public class Treasure : Item
    {
        public Treasure()
        {
        }

        public int Id { get; set; }

        public string Rarity { get; set; }

        public int Reward { get; set; }

        public string ImageURL { get; set; }
    }
}
