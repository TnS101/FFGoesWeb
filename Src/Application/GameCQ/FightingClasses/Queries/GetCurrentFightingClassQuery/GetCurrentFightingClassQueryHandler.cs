namespace Application.GameCQ.FightingClasses.Queries.GetCurrentFightingClassQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using MediatR;

    public class GetCurrentFightingClassQueryHandler : MapperHandler, IRequestHandler<GetCurrentFightingClassQuery, FightingClassFullViewModel>
    {
        public GetCurrentFightingClassQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<FightingClassFullViewModel> Handle(GetCurrentFightingClassQuery request, CancellationToken cancellationToken)
        {
            var fightingClass = await this.Context.FightingClasses.FindAsync(request.FightingClassId);

            return this.Mapper.Map<FightingClassFullViewModel>(fightingClass);
        }
    }
}
