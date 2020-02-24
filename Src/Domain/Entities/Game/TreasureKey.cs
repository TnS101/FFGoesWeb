namespace FinalFantasyTryoutGoesWeb.Domain.Entities.Game
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;

    public class TreasureKey : Item
    {
        public int Id { get; set; }

        public string Rarity { get; set; }

        public string ImageURL { get; set; }
    }
}
