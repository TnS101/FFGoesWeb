using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.GameCQ.Monsters.Queries.GetMonsterInfoQuery
{
    public class GetMonsterInfoQueryHandler : IRequestHandler<GetMonsterInfoQuery, MonsterFullViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetMonsterInfoQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<MonsterFullViewModel> Handle(GetMonsterInfoQuery request, CancellationToken cancellationToken)
        {
            var monster = await this.context.Monsters.FindAsync(request.MonsterId);

            return this.mapper.Map<MonsterFullViewModel>(monster);
        }
    }
}
