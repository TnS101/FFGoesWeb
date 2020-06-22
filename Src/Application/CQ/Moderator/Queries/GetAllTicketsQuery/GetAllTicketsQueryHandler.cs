namespace Application.CQ.Moderator.Queries.GetAllTicketsQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllTicketsQueryHandler : MapperHandler, IRequestHandler<GetAllTicketsQuery, TicketsListViewModel>
    {
        public GetAllTicketsQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<TicketsListViewModel> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
        {
            return new TicketsListViewModel
            {
                Tickets = await this.Context.Tickets.ProjectTo<TicketPartialViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync(),
            };
        }
    }
}
