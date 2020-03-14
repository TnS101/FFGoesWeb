namespace Application.GameCQ.Spell.Queries
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetPersonalSpellsQueryHandler : IRequestHandler<GetPersonalSpellsQuery, SpellListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper; 
        public GetPersonalSpellsQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<SpellListViewModel> Handle(GetPersonalSpellsQuery request, CancellationToken cancellationToken)
        {
            return new SpellListViewModel
            {
                Spells = await this.context.Spells.Where(s => s.ClassType == request.ClassType).ProjectTo<SpellFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
