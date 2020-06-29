namespace Application.CQ.Users.Statuses.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllStatusesQueryHandler : MapperHandler, IRequestHandler<GetAllStatusesQuery, StatusListViewModel>
    {
        public GetAllStatusesQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<StatusListViewModel> Handle(GetAllStatusesQuery request, CancellationToken cancellationToken)
        {
            return new StatusListViewModel
            {
                Statuses = await this.Context.Statuses.AsNoTracking().ProjectTo<StatusFullViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync(),
            };
        }
    }
}
