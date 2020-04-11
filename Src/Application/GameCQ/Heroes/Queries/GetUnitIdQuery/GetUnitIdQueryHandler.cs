namespace Application.GameCQ.Heroes.Queries.GetUnitIdQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetUnitIdQueryHandler : IRequestHandler<GetUnitIdQuery, UnitIdViewModel>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public GetUnitIdQueryHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<UnitIdViewModel> Handle(GetUnitIdQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var hero = await this.context.Heroes.FirstOrDefaultAsync(h => h.UserId == user.Id && h.IsSelected);

            return new UnitIdViewModel
            {
                Id = hero.Id,
            };
        }
    }
}
