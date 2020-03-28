namespace Application.CQ.Moderator.Queries.GetAllTicketsQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, TicketsListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetAllTicketsQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TicketsListViewModel> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
        {
            return new TicketsListViewModel
            {
                Tickets = await this.context.Tickets.ProjectTo<TicketPartialViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
