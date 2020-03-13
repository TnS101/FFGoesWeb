using Application.GameCQ.Item.Queries;
using AutoMapper;
using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.GameCQ.Equipment.Queries
{
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
            return new EquipmentViewModel
            {
                Items = await this.context.Items.Where(i => i.Inventory.UnitId == request.UnitId).ProjectTo<ItemFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
