namespace Application.CQ.Admin.TreasureKey.Commands.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.GameCQ.TreasureKey.Queries;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllTreasureKeysQueryHandler : IRequestHandler<GetAllTreasureKeysQuery, TreasureKeyListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetAllTreasureKeysQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TreasureKeyListViewModel> Handle(GetAllTreasureKeysQuery request, CancellationToken cancellationToken)
        {
            return new TreasureKeyListViewModel
            {
                Keys = await this.context.TreasureKeys.ProjectTo<TreasureKeyFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
