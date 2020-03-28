namespace Application.CQ.Admin.Item.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.GameCQ.Item.Queries;
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
            return new ItemListViewModel
            {
                Items = await this.context.Items.ProjectTo<ItemFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
