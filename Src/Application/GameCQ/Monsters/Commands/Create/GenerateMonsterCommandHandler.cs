namespace Application.GameCQ.Monsters.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Generators;
    using Domain.Entities.Game.Units;
    using MediatR;

    public class GenerateMonsterCommandHandler : IRequestHandler<GenerateMonsterCommand, Monster>
    {
        private readonly EnemyGenerator enemyGenerator;
        private readonly IFFDbContext context;

        public GenerateMonsterCommandHandler(IFFDbContext context)
        {
            this.enemyGenerator = new EnemyGenerator();
            this.context = context;
        }

        public async Task<Monster> Handle(GenerateMonsterCommand request, CancellationToken cancellationToken)
        {
            var enemy = await this.enemyGenerator.Generate(request.PlayerLevel, this.context, request.ZoneName);

            return enemy;
        }
    }
}
