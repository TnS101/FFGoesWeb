namespace Application.GameCQ.Item.Commands.Create
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand>
    {
        private readonly IFFDbContext context;
        

        public CreateItemCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            this.context.Items.Add(new FinalFantasyTryoutGoesWeb.Domain.Entities.Game.Item
            {
                Name = request.Name,
                Agility = request.Agility,
                ArmorValue = request.ArmorValue,
                AttackPower = request.AttackPower,
                ClassType = request.ClassType,
                Intellect = request.Intellect,
                Level = request.Level,
                RessistanceValue = request.RessistanceValue,
                Slot = request.Slot,
                Spirit = request.Spirit,
                Stamina = request.Stamina,
                Strength = request.Strength
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
