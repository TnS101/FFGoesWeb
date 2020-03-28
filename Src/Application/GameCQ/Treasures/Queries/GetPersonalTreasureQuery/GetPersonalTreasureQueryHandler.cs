namespace Application.GameCQ.Treasure.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.CQ.Admin.Treasure.Queries.GetAllTreasureQuery;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetPersonalTreasureQueryHandler : IRequestHandler<GetPersonalTreasureQuery, TreasureListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetPersonalTreasureQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TreasureListViewModel> Handle(GetPersonalTreasureQuery request, CancellationToken cancellationToken)
        {
            var unit = await this.context.Units.FindAsync(request.UnitId);

            var treasures = this.context.Items.Where(i => i.Name.Split()[1] == "Treasure" && i.InventoryId == unit.InventoryId);

            return new TreasureListViewModel
            {
                Treasures = await treasures.ProjectTo<TreasureFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
