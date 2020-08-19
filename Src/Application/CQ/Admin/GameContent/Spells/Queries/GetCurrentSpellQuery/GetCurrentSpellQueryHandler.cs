namespace Application.CQ.Admin.GameContent.Spells.Queries.GetCurrentSpellQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using MediatR;

    public class GetCurrentSpellQueryHandler : MapperHandler, IRequestHandler<GetCurrentSpellQuery, SpellFullViewModel>
    {
        public GetCurrentSpellQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<SpellFullViewModel> Handle(GetCurrentSpellQuery request, CancellationToken cancellationToken)
        {
            var spell = await this.Context.Spells.FindAsync(request.SpellId);
            var mapped = this.Mapper.Map<SpellFullViewModel>(spell);

            mapped.ClassType = this.Context.FightingClasses.Find(spell.FightingClassId).Type;

            return mapped;
        }
    }
}
