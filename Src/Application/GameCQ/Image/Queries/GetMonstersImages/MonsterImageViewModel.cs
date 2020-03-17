using Application.Common.Mappings;
using Application.GameCQ.Image.Queries;
using AutoMapper;

namespace Application.GameCQ.Monster.Queries
{
    public class MonsterImageViewModel : IHaveCustomMappings
    {
        public string Path { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Domain.Entities.Game.Image, ImageFullViewModel>();
        }
    }
}
