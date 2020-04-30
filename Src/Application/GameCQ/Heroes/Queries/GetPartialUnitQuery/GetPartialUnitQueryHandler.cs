namespace Application.GameCQ.Heroes.Queries.GetPartialUnitQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using MediatR;

    public class GetPartialUnitQueryHandler : MapperHandler, IRequestHandler<GetPartialUnitQuery, UnitPartialViewModel>
    {
        public GetPartialUnitQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<UnitPartialViewModel> Handle(GetPartialUnitQuery request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            var unit = this.Context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            return this.Mapper.Map<UnitPartialViewModel>(unit);
        }
    }
}
