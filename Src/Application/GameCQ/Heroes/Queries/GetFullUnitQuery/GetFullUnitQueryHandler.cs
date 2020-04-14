namespace Application.GameCQ.Heroes.Queries.GetFullUnitQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetFullUnitQueryHandler : IRequestHandler<GetFullUnitQuery, UnitFullViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public GetFullUnitQueryHandler(IFFDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<UnitFullViewModel> Handle(GetFullUnitQuery request, CancellationToken cancellationToken)
        {
            if (request.User != null)
            {
                var user = await this.userManager.GetUserAsync(request.User);
                var hero = await this.context.Heroes.FirstOrDefaultAsync(h => h.UserId == user.Id && h.IsSelected);

                var mappedHero = this.mapper.Map<UnitFullViewModel>(hero);

                var spells = await this.context.Spells.Where(s => s.ClassType == hero.ClassType).ToListAsync();

                mappedHero.Spells = spells;

                return mappedHero;
            }
            else
            {
                var hero = await this.context.Heroes.FindAsync(request.HeroId);

                return this.mapper.Map<UnitFullViewModel>(hero);
            }
        }
    }
}
