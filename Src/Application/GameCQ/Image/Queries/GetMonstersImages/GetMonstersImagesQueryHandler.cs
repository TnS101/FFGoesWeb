namespace Application.GameCQ.Monster.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetMonstersImagesQueryHandler : IRequestHandler<GetMonstersImagesQuery, MonsterImageListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetMonstersImagesQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<MonsterImageListViewModel> Handle(GetMonstersImagesQuery request, CancellationToken cancellationToken)
        {
            return new MonsterImageListViewModel
            {
                Monsters = await this.context.Images.Where(i => i.IconURL == null && i.Description != null).ProjectTo<MonsterImageViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
