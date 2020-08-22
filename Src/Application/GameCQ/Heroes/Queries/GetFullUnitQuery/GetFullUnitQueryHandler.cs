namespace Application.GameCQ.Heroes.Queries.GetFullUnitQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
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
            var hero = await this.Context.Heroes.FirstOrDefaultAsync(h => h.Id == request.HeroId && h.UserId == request.UserId);

            var mappedHero = this.Mapper.Map<UnitFullViewModel>(hero);

            mappedHero.Spells = await this.Context.Spells.Where(s => s.FightingClassId == hero.FightingClassId).AsNoTracking().ProjectTo<SpellMinViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync();

            return mappedHero;
        }
    }
}
