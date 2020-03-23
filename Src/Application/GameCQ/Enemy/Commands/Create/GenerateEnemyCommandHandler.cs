namespace Application.GameCQ.Enemy.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.GameCQ.Unit.Queries;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Generators;
    using MediatR;

    public class GenerateEnemyCommandHandler : IRequestHandler<GenerateEnemyCommand, UnitFullViewModel>
    {
        private readonly EnemyGenerator enemyGenerator;

        public GenerateEnemyCommandHandler()
        {
            this.enemyGenerator = new EnemyGenerator();
        }

        public async Task<UnitFullViewModel> Handle(GenerateEnemyCommand request, CancellationToken cancellationToken)
        {
            return this.enemyGenerator.Generate(request.PlayerLevel);
        }
    }
}
