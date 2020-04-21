namespace Application.CQ.Admin.GameContent.Spells.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class DeleteSpellCommandHandler : IRequestHandler<DeleteSpellCommand, string>
    {
        private readonly IFFDbContext context;

        public DeleteSpellCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(DeleteSpellCommand request, CancellationToken cancellationToken)
        {
            var spellToRemove = await this.context.Spells.FindAsync(request.SpellId);

            this.context.Spells.Remove(spellToRemove);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.AdminSpellCommandRedirect;
        }
    }
}
