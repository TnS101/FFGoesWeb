namespace Application.GameCQ.Unit.Commands.Update.SelectUnitCommand
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class SelectUnitCommandHandler : IRequestHandler<SelectUnitCommand, string>
    {
        private readonly IFFDbContext context;

        public SelectUnitCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(SelectUnitCommand request, CancellationToken cancellationToken)
        {
            var newUnit = await this.context.Units.FindAsync(request.UnitId);

            var user = await this.context.AppUsers.FindAsync(newUnit.UserId);

            var oldUnit = this.context.Units.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            oldUnit.IsSelected = false;

            newUnit.IsSelected = true;

            this.context.Units.Update(oldUnit);

            this.context.Units.Update(newUnit);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.WorldRedirect;
        }
    }
}
