namespace Application.GameCQ.Image.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetFightingClassImagesQueryHandler : IRequestHandler<GetFightingClassImagesQuery, ImageListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetFightingClassImagesQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ImageListViewModel> Handle(GetFightingClassImagesQuery request, CancellationToken cancellationToken)
        {
            return new ImageListViewModel
            {
                Images = await this.context.Images.Where(i => i.IconURL != null).ProjectTo<ImageFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
