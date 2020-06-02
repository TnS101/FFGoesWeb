namespace Application.GameCQ.Heroes.Commands.Update.SelectHeroCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class SelectHeroCommandHandler : BaseHandler, IRequestHandler<SelectHeroCommand, string>
    {
        public SelectHeroCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(SelectHeroCommand request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            var oldHero = await this.Context.Heroes.FirstOrDefaultAsync(u => u.UserId == user.Id && u.IsSelected);

            if (oldHero != null)
            {
                oldHero.IsSelected = false;

                this.Context.Heroes.Update(oldHero);
            }

            var hero = await this.Context.Heroes.FindAsync(request.HeroId);

            hero.IsSelected = true;

            this.Context.Heroes.Update(hero);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.WorldRedirect;
        }
    }
}
