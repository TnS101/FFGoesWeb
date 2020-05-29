namespace Application.GameCQ.Heroes.Queries.GetFullUnitQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetFullUnitQueryHandler : MapperHandler, IRequestHandler<GetFullUnitQuery, UnitFullViewModel>
    {
        public GetFullUnitQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<UnitFullViewModel> Handle(GetFullUnitQuery request, CancellationToken cancellationToken)
        {
            if (request.HeroId != null)
            {
                var hero = await this.Context.Heroes.FindAsync(request.HeroId);

                var spells = await this.Context.Spells.Where(s => s.FightingClassId == hero.FightingClassId).ToListAsync();

                var mappedHero = this.Mapper.Map<UnitFullViewModel>(hero);

                mappedHero.Spells = spells;

                return mappedHero;
            }

            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            var userHero = await this.Context.Heroes.FirstOrDefaultAsync(h => h.UserId == user.Id && h.IsSelected);

            var userMappedHero = this.Mapper.Map<UnitFullViewModel>(userHero);

            return userMappedHero;
        }
    }
}
