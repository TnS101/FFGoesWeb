namespace Application.CQ.Admin.GameContent.FightingClasses.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class DeleteFightingClassCommandHandler : BaseHandler, IRequestHandler<DeleteFightingClassCommand, string>
    {
        public DeleteFightingClassCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(DeleteFightingClassCommand request, CancellationToken cancellationToken)
        {
            var fightingClass = await this.Context.FightingClasses.FindAsync(request.FightingClassId);

            var spells = this.Context.Spells.Where(s => s.FightingClassId == fightingClass.Id);

            var heroes = this.Context.Heroes.Where(h => h.FightingClassId == fightingClass.Id);

            this.Context.Heroes.RemoveRange(heroes);

            this.Context.Spells.RemoveRange(spells);

            this.Context.FightingClasses.Remove(fightingClass);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.AdminFightingClassCommandRedirect;
        }
    }
}
