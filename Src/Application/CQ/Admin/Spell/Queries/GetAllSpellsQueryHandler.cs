namespace Application.CQ.Admin.Spell.Queries
{
    using Application.GameCQ.Spell.Queries;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllSpellsQueryHandler : IRequestHandler<GetAllSpellsQuery, SpellListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetAllSpellsQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<SpellListViewModel> Handle(GetAllSpellsQuery request, CancellationToken cancellationToken)
        {
            return new SpellListViewModel
            {
                Spells = await this.context.Spells.ProjectTo<SpellFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
