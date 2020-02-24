﻿namespace Application.GameCQ.Item.Queries
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;

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
            return new ItemListViewModel
            {
                Items = await this.context.Items.Where(i => i.Inventory.UnitId == request.UnitId).ProjectTo<ItemFullViewModel>(mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
