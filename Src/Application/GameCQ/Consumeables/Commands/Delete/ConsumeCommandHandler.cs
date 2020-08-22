namespace Application.GameCQ.Consumeables.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ConsumeCommandHandler : BaseHandler, IRequestHandler<ConsumeCommand>
    {
        public ConsumeCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<Unit> Handle(ConsumeCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.Context.Heroes.FirstOrDefaultAsync(h => h.Id == request.HeroId && h.UserId == request.UserId);

            var consumeable = await this.Context.Consumeables.FindAsync(request.ConsumeableId);

            var consumeableInventory = await this.Context.ConsumeablesInventories.FirstOrDefaultAsync(ci => ci.ConsumeableId == consumeable.Id && ci.HeroId == hero.Id);

            if (consumeableInventory.Count > 1)
            {
                consumeableInventory.Count--;
            }
            else
            {
                this.Context.ConsumeablesInventories.Remove(consumeableInventory);
            }

            hero.Hunger += consumeable.HungerReplenish;
            hero.Thirst += consumeable.ThirstReplenish;

            if (consumeable.Stat == "HP")
            {
                hero.CurrentHP += consumeable.StatReplenish;
            }
            else
            {
                hero.CurrentMana += consumeable.StatReplenish;
            }

            await this.Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
