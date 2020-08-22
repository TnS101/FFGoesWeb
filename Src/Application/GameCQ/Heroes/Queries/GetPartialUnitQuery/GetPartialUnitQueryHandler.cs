namespace Application.GameCQ.Heroes.Queries.GetPartialUnitQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetPartialUnitQueryHandler : MapperHandler, IRequestHandler<GetPartialUnitQuery, UnitPartialViewModel>
    {
        public GetPartialUnitQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<UnitPartialViewModel> Handle(GetPartialUnitQuery request, CancellationToken cancellationToken)
        {
            var unit = await this.Context.Heroes.FirstOrDefaultAsync(u => u.UserId == request.UserId && u.IsSelected);

            return this.Mapper.Map<UnitPartialViewModel>(unit);
        }
    }
}
