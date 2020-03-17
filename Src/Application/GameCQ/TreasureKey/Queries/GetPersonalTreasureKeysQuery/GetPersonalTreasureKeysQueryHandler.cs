namespace Application.GameCQ.TreasureKey.Queries
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    public class GetPersonalTreasureKeysQueryHandler : IRequestHandler<GetPersonalTreasureKeysQuery, TreasureKeyListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        public GetPersonalTreasureKeysQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TreasureKeyListViewModel> Handle(GetPersonalTreasureKeysQuery request, CancellationToken cancellationToken)
        {
            var unit = await this.context.Units.FindAsync(request.UnitId);

            var inventory = this.context.Items.Where(i => i.Name.Split()[1] == "Key" && i.InventoryId == unit.InventoryId);

            return new TreasureKeyListViewModel
            {
                Keys = await inventory.ProjectTo<TreasureKeyFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
