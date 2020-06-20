namespace Application.GameCQ.Battles.Commands.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Generators;
    using Application.GameContent.Utilities.LevelUtility;
    using Application.GameContent.Utilities.Stats;
    using Domain.Entities.Game.Units;
    using MediatR;

    public class EndBattleCommandHandler : BaseHandler, IRequestHandler<EndBattleCommand, long>
    {
        public EndBattleCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<long> Handle(EndBattleCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.Context.Heroes.FindAsync(request.HeroId);

            if (request.ZoneName == "World")
            {
                hero.XP += (this.EnemyCombinedStats(request.Monster) / 18) * ((hero.Happiness / 40) + 1);
                hero.CoinAmount += (int)Math.Round(this.EnemyCombinedStats(request.Monster) / 30);
            }
            else
            {
                hero.ProffesionXP += this.EnemyCombinedStats(request.Monster) / 20;
            }

            var reset = new StatReset();
            reset.Reset(hero);

            await new ItemGenerator().Generate(hero, this.Context, request.Monster, request.ZoneName, cancellationToken);

            if (hero.XP >= hero.XPCap)
            {
                await new Level().Up(hero, this.Context);
            }

            this.Context.Heroes.Update(hero);

            await this.Context.SaveChangesAsync(cancellationToken);

            return hero.Id;
        }

        private double EnemyCombinedStats(Monster monster)
        {
            return monster.MaxHP + monster.MaxMana + monster.AttackPower + monster.MagicPower
                + monster.ArmorValue + monster.ResistanceValue + monster.HealthRegen + monster.ManaRegen + monster.CritChance;
        }
    }
}
