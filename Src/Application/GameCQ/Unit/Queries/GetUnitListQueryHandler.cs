namespace Application.GameCQ.Unit.Queries
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUnitListQueryHandler : IRequestHandler<GetUnitListQuery, UnitListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetUnitListQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<UnitListViewModel> Handle(GetUnitListQuery request, CancellationToken cancellationToken)
        {
            return new UnitListViewModel
            {
                Units = await this.context.Units.Where(u => u.UserId == request.UserId).ProjectTo<UnitPartialViewModel>(this.mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
