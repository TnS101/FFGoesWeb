namespace Application.GameCQ.Monsters.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Generators;
    using Domain.Entities.Game.Units;
    using MediatR;

    public class GenerateMonsterCommandHandler : BaseHandler, IRequestHandler<GenerateMonsterCommand, Monster>
    {
        private readonly EnemyGenerator enemyGenerator;

        public GenerateMonsterCommandHandler(IFFDbContext context)
            : base(context)
        {
            this.enemyGenerator = new EnemyGenerator();
        }

        public async Task<Monster> Handle(GenerateMonsterCommand request, CancellationToken cancellationToken)
        {
            var enemy = await this.enemyGenerator.Generate(request.PlayerLevel, this.Context, request.ZoneName);

            return enemy;
        }
    }
}
