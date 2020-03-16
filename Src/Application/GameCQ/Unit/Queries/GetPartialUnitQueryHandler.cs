namespace Application.GameCQ.Unit.Queries
{
    using AutoMapper;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetPartialUnitQueryHandler : IRequestHandler<GetPartialUnitQuery, UnitPartialViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        public GetPartialUnitQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<UnitPartialViewModel> Handle(GetPartialUnitQuery request, CancellationToken cancellationToken)
        {
            var unit = await this.context.Units.Where(u => u.UserId == request.UserId && u.IsSelected).MinAsync(cancellationToken);

            return this.mapper.Map<UnitPartialViewModel>(unit);
        }
    }
}
