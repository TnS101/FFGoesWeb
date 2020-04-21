namespace Application.CQ.Admin.GameContent.Units.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class DeleteUnitCommandHandler : IRequestHandler<DeleteUnitCommand, string>
    {
        private readonly IFFDbContext context;

        public DeleteUnitCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            string returnString;

            if (request.UnitType == "Monster")
            {
                var monster = await this.context.Monsters.FindAsync(request.UnitId);

                var spells = await this.context.Spells.Where(s => s.ClassType == monster.Name).ToListAsync();

                this.context.Spells.RemoveRange(spells);
                this.context.Monsters.Remove(monster);

                returnString = GConst.MonsterCommandRedirect;
            }
            else
            {
                var fightingClass = await this.context.FightingClasses.FindAsync(request.UnitId);

                var spells = await this.context.Spells.Where(s => s.ClassType == fightingClass.ClassType).ToListAsync();

                var heroes = await this.context.Heroes.Where(h => h.FightingClassId == fightingClass.Id).ToListAsync();

                this.context.Heroes.RemoveRange(heroes);

                this.context.Spells.RemoveRange(spells);

                this.context.FightingClasses.Remove(fightingClass);

                returnString = GConst.UnitCommandRedirect;
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return returnString;
        }
    }
}
