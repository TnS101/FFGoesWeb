namespace Application.GameCQ.Equipments.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetEquipmentQueryHandler : IRequestHandler<GetEquipmentQuery, EquipmentViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetEquipmentQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<EquipmentViewModel> Handle(GetEquipmentQuery request, CancellationToken cancellationToken)
        {
            if (request.Slot == "Weapon")
            {
                return new EquipmentViewModel
                {
                    Items = await this.context.Weapons.Where(i => i.Inventory.HeroId == request.HeroId).ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else if (request.Slot == "Armor")
            {
                return new EquipmentViewModel
                {
                    Items = await this.context.Armors.Where(i => i.Inventory.HeroId == request.HeroId).ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else
            {
                return new EquipmentViewModel
                {
                    Items = await this.context.Trinkets.Where(i => i.Inventory.HeroId == request.HeroId).ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
        }
    }
}
