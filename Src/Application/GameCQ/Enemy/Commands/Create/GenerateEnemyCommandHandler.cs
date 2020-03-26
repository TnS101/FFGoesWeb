namespace Application.GameCQ.Enemy.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.GameCQ.Unit.Queries;
    using AutoMapper;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Generators;
    using MediatR;

    public class GenerateEnemyCommandHandler : IRequestHandler<GenerateEnemyCommand, UnitFullViewModel>
    {
        private readonly EnemyGenerator enemyGenerator;
        private readonly IMapper mapper;

        public GenerateEnemyCommandHandler(IMapper mapper)
        {
            this.enemyGenerator = new EnemyGenerator();
            this.mapper = mapper;
        }

        public async Task<UnitFullViewModel> Handle(GenerateEnemyCommand request, CancellationToken cancellationToken)
        {
            var enemy = await this.enemyGenerator.Generate(request.PlayerLevel);

            return this.mapper.Map<UnitFullViewModel>(enemy);
        }
    }
}
