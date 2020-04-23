namespace Application.CQ.Admin.GameContent.Spells.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class DeleteSpellCommandHandler : BaseHandler, IRequestHandler<DeleteSpellCommand, string>
    {
        public DeleteSpellCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(DeleteSpellCommand request, CancellationToken cancellationToken)
        {
            var spellToRemove = await this.Context.Spells.FindAsync(request.SpellId);

            this.Context.Spells.Remove(spellToRemove);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.AdminSpellCommandRedirect;
        }
    }
}
