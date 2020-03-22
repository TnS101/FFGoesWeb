namespace Application.CQ.Admin.Treasure.Queries.GetAllTreasureQuery
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Application.GameCQ.Treasure.Queries;

    public class GetAllTreasuresQueryHandler : IRequestHandler<GetAllTreasuresQuery, TreasureListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        public GetAllTreasuresQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TreasureListViewModel> Handle(GetAllTreasuresQuery request, CancellationToken cancellationToken)
        {
            return new TreasureListViewModel
            {
                Treasures = await this.context.Treasures.ProjectTo<TreasureFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
