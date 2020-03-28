namespace Application.CQ.Admin.GameContent.Items.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.GameCQ.Item.Queries;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, ItemListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetAllItemsQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ItemListViewModel> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            if (request.Slot == "Weapon")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Weapons.ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else if (request.Slot == "Armor")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Armors.ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else if (request.Slot == "Trinket")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Trinkets.ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else if (request.Slot == "Treasure")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Treasures.ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else if (request.Slot == "Treasure Keys")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.TreasureKeys.ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Materials.ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
        }
    }
}
