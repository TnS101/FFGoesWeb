namespace Application.GameCQ.Heroes.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class DeleteHeroCommandHandler : BaseHandler, IRequestHandler<DeleteHeroCommand, string>
    {
        public DeleteHeroCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(DeleteHeroCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.Context.Heroes.FirstOrDefaultAsync(h => h.Id == request.HeroId && h.UserId == request.UserId);

            var energyChanges = this.Context.EnergyChanges.Where(ec => ec.HeroId == hero.Id);

            this.Context.WeaponsInventories.RemoveRange(this.Context.WeaponsInventories.Where(e => e.HeroId == hero.Id));
            this.Context.ArmorsInventories.RemoveRange(this.Context.ArmorsInventories.Where(e => e.HeroId == hero.Id));
            this.Context.TrinketsInventories.RemoveRange(this.Context.TrinketsInventories.Where(e => e.HeroId == hero.Id));
            this.Context.CardsInventories.RemoveRange(this.Context.CardsInventories.Where(e => e.HeroId == hero.Id));
            this.Context.RelicsInventories.RemoveRange(this.Context.RelicsInventories.Where(e => e.HeroId == hero.Id));

            this.Context.ConsumeablesInventories.RemoveRange(this.Context.ConsumeablesInventories.Where(e => e.HeroId == hero.Id));
            this.Context.LootBoxesInventories.RemoveRange(this.Context.LootBoxesInventories.Where(e => e.HeroId == hero.Id));
            this.Context.LootKeysInventories.RemoveRange(this.Context.LootKeysInventories.Where(e => e.HeroId == hero.Id));
            this.Context.MaterialsInventories.RemoveRange(this.Context.MaterialsInventories.Where(e => e.HeroId == hero.Id));
            this.Context.RelicsInventories.RemoveRange(this.Context.RelicsInventories.Where(e => e.HeroId == hero.Id));
            this.Context.ToolsInventories.RemoveRange(this.Context.ToolsInventories.Where(e => e.HeroId == hero.Id));
            this.Context.ToyInventories.RemoveRange(this.Context.ToyInventories.Where(e => e.HeroId == hero.Id));

            this.Context.WeaponsEquipments.RemoveRange(this.Context.WeaponsEquipments.Where(e => e.HeroId == hero.Id));
            this.Context.ArmorsEquipments.RemoveRange(this.Context.ArmorsEquipments.Where(e => e.HeroId == hero.Id));
            this.Context.TrinketEquipments.RemoveRange(this.Context.TrinketEquipments.Where(e => e.HeroId == hero.Id));
            this.Context.CardsEquipments.RemoveRange(this.Context.CardsEquipments.Where(e => e.HeroId == hero.Id));
            this.Context.RelicsEquipments.RemoveRange(this.Context.RelicsEquipments.Where(e => e.HeroId == hero.Id));

            this.Context.EnergyChanges.RemoveRange(energyChanges);

            this.Context.Heroes.Remove(hero);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.HeroCommandRedirect;
        }
    }
}
