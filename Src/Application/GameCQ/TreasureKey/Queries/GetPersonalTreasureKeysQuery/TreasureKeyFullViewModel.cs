namespace Application.GameCQ.TreasureKey.Queries
{
    using Application.Common.Mappings;
    using AutoMapper;

    public class TreasureKeyFullViewModel : IHaveCustomMappings
    {
        public string Rarity { get; set; }

        public string ImageURL { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<FinalFantasyTryoutGoesWeb.Domain.Entities.Game.TreasureKey,TreasureKeyFullViewModel>();
        }
    }
}
