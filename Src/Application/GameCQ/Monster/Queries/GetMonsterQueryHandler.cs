using AutoMapper;
using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.GameCQ.Monster.Queries
{
    public class GetMonsterQueryHandler : IRequestHandler<GetMonstersQuery, MonsterListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetMonsterQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<MonsterListViewModel> Handle(GetMonstersQuery request, CancellationToken cancellationToken)
        {
            return new MonsterListViewModel
            {
                Monsters = await this.context.Images.Where(i => i.IconURL == null && i.Description != null).ProjectTo<MonsterViewModel>(this.mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
