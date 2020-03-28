namespace Application.GameCQ.Enemies.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Generators;
    using Application.GameCQ.Unit.Queries;
    using AutoMapper;
    using MediatR;

    public class GenerateEnemyCommandHandler : IRequestHandler<GenerateEnemyCommand, UnitFullViewModel>
    {
        private readonly EnemyGenerator enemyGenerator;
        private readonly IMapper mapper;
        private readonly IFFDbContext context;

        public GenerateEnemyCommandHandler(IMapper mapper, IFFDbContext context)
        {
            this.enemyGenerator = new EnemyGenerator();
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<UnitFullViewModel> Handle(GenerateEnemyCommand request, CancellationToken cancellationToken)
        {
            var enemy = await this.enemyGenerator.Generate(request.PlayerLevel, this.context);

            return this.mapper.Map<UnitFullViewModel>(enemy);
        }
    }
}
