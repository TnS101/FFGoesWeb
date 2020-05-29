namespace Application.CQ.Admin.GameContent.Monsters.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class DeleteMonsterCommandHandler : BaseHandler, IRequestHandler<DeleteMonsterCommand, string>
    {
        public DeleteMonsterCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(DeleteMonsterCommand request, CancellationToken cancellationToken)
        {
            var monster = await this.Context.Monsters.FindAsync(request.MonsterId);

            var spells = await this.Context.Spells.Where(s => s.MonsterId == monster.Id).ToListAsync();

            this.Context.Spells.RemoveRange(spells);

            this.Context.Monsters.Remove(monster);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.AdminMonsterCommandRedirect;
        }
    }
}
