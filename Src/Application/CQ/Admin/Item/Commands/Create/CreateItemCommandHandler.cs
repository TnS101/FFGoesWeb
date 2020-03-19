namespace Application.CQ.Admin.Item.Commands.Create
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
                Level = request.Level,
                ClassType = request.ClassType,
                Stamina = request.Stamina,
                Strength = request.Strength,
                Agility = request.Agility,
                Intellect = request.Intellect,
                Spirit = request.Spirit,
                AttackPower = request.AttackPower,
                ArmorValue = request.ArmorValue,
                Slot = request.Slot
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
