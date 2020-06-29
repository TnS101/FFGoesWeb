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
            return this.Mapper.Map<SpellFullViewModel>(await this.Context.Spells.FindAsync(request.SpellId));
        }
    }
}
