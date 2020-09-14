namespace Application.GameCQ.Battles.Queries.GetBattleUnitsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Validators.Condition;
    using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetBattleUnitsQueryHandler : MapperHandler, IRequestHandler<GetBattleUnitsQuery, BattleUnitsListViewModel>
    {
        public GetBattleUnitsQueryHandler(IMapper mapper, IFFDbContext context)
            : base(context, mapper)
        {
        }

        public async Task<BattleUnitsListViewModel> Handle(GetBattleUnitsQuery request, CancellationToken cancellationToken)
        {
            var dbHero = this.Context.Heroes.FromSqlRaw($"GetBattleHero {request.HeroId}").AsEnumerable().First();
            var hero = this.Mapper.Map<BattleUnitViewModel>(dbHero);
            var fightingClass = await this.Context.FightingClasses.FindAsync(dbHero.FightingClassId);

            var dbSpells = this.Context.Spells.Where(s => s.FightingClassId == dbHero.FightingClassId).AsNoTracking();
            var conditionValidator = new ConditionValidator();

            foreach (var spell in dbSpells)
            {
                conditionValidator.Process(spell, dbHero, request.Enemy, null, null, true);
                var mappedSpell = this.Mapper.Map<SpellMinViewModel>(spell);
                mappedSpell.ClassType = fightingClass.Type;

                hero.Spells.Add(mappedSpell);
            }

            return new BattleUnitsListViewModel
            {
                Hero = hero,
                Enemy = this.Mapper.Map<BattleUnitViewModel>(request.Enemy),
            };
        }
    }
}
