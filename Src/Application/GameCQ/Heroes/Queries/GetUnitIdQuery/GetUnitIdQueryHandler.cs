namespace Application.GameCQ.Heroes.Queries.GetUnitIdQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetUnitIdQueryHandler : UserHandler, IRequestHandler<GetUnitIdQuery, UnitIdViewModel>
    {
        public GetUnitIdQueryHandler(IFFDbContext context, UserManager<AppUser> userManager)
            : base(context, userManager)
        {
        }

        public async Task<UnitIdViewModel> Handle(GetUnitIdQuery request, CancellationToken cancellationToken)
        {
            var user = await this.UserManager.GetUserAsync(request.User);

            var hero = await this.Context.Heroes.FirstOrDefaultAsync(h => h.UserId == user.Id && h.IsSelected);

            return new UnitIdViewModel
            {
                Id = hero.Id,
            };
        }
    }
}
