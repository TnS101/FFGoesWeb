namespace Application.GameCQ.Heroes.Queries.GetUnitIdQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetUnitIdQueryHandler : BaseHandler, IRequestHandler<GetUnitIdQuery, UnitIdViewModel>
    {
        public GetUnitIdQueryHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<UnitIdViewModel> Handle(GetUnitIdQuery request, CancellationToken cancellationToken)
        {
            var hero = await this.Context.Heroes.FirstOrDefaultAsync(h => h.UserId == request.UserId && h.IsSelected);

            return new UnitIdViewModel
            {
                Id = hero.Id,
            };
        }
    }
}
