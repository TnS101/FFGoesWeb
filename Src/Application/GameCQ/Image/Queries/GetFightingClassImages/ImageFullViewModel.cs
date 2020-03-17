using Application.Common.Mappings;
using AutoMapper;

namespace Application.GameCQ.Image.Queries
{
    public class ImageFullViewModel : IMapFrom<Domain.Entities.Game.Image>
    {
        public string Path { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string IconURL { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<Domain.Entities.Game.Image, ImageFullViewModel>();
        }
    }
}
