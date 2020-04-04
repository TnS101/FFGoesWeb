namespace Application.GameCQ.Monsters.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Generators;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using AutoMapper;
    using MediatR;

    public class GenerateMonsterCommandHandler : IRequestHandler<GenerateMonsterCommand, UnitFullViewModel>
    {
        private readonly EnemyGenerator enemyGenerator;
        private readonly IMapper mapper;
        private readonly IFFDbContext context;

        public GenerateMonsterCommandHandler(IMapper mapper, IFFDbContext context)
        {
            this.enemyGenerator = new EnemyGenerator();
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<UnitFullViewModel> Handle(GenerateMonsterCommand request, CancellationToken cancellationToken)
        {
            var enemy = await this.enemyGenerator.Generate(request.PlayerLevel, this.context, request.ZoneName);

            return this.mapper.Map<UnitFullViewModel>(enemy);
        }
    }
}
