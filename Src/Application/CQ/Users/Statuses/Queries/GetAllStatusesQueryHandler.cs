namespace Application.CQ.Users.Statuses.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllStatusesQueryHandler : IRequestHandler<GetAllStatusesQuery, StatusListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetAllStatusesQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<StatusListViewModel> Handle(GetAllStatusesQuery request, CancellationToken cancellationToken)
        {
            return new StatusListViewModel
            {
                Statuses = await this.context.Statuses.ProjectTo<StatusFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
