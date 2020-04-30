namespace Application.GameCQ.Heroes.Queries.GetFullUnitQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetFullUnitQueryHandler : FullHandler, IRequestHandler<GetFullUnitQuery, UnitFullViewModel>
    {
        public GetFullUnitQueryHandler(IFFDbContext context, UserManager<AppUser> userManager, IMapper mapper)
            : base(context, userManager, mapper)
        {
        }

        public async Task<UnitFullViewModel> Handle(GetFullUnitQuery request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);
            var hero = await this.Context.Heroes.FirstOrDefaultAsync(h => h.UserId == user.Id && h.IsSelected);

            var mappedHero = this.Mapper.Map<UnitFullViewModel>(hero);

            var spells = await this.Context.Spells.Where(s => s.ClassType == hero.ClassType).ToListAsync();

            mappedHero.Spells = spells;

            return mappedHero;
        }
    }
}
