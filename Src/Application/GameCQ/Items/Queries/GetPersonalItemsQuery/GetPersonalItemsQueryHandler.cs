namespace Application.GameCQ.Items.Queries.GetPersonalItemsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetPersonalItemsQueryHandler : IRequestHandler<GetPersonalItemsQuery, ItemListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetPersonalItemsQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ItemListViewModel> Handle(GetPersonalItemsQuery request, CancellationToken cancellationToken)
        {
            if (request.Slot == "Weapon")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Weapons.Where(i => i.Inventory.HeroId == request.HeroId).ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else if (request.Slot == "Armor")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Armors.Where(i => i.Inventory.HeroId == request.HeroId).ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else if (request.Slot == "Trinket")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Trinkets.Where(i => i.Inventory.HeroId == request.HeroId).ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else if (request.Slot == "Treasure")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Treasures.Where(i => i.Inventory.HeroId == request.HeroId).ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else if (request.Slot == "Treasure Key")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.TreasureKeys.Where(i => i.Inventory.HeroId == request.HeroId).ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Materials.Where(i => i.Inventory.HeroId == request.HeroId).ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
        }
    }
}
