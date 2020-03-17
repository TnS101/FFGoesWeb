namespace Application.GameCQ.Treasure.Queries
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public class GetAllTreasureQueryHandler : IRequestHandler<GetAllTreasureQuery, TreasureListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        public GetAllTreasureQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TreasureListViewModel> Handle(GetAllTreasureQuery request, CancellationToken cancellationToken)
        {
            return new TreasureListViewModel
            {
                Treasures = await this.context.TreasureKeys.ProjectTo<TreasureFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
