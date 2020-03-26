namespace Application.GameCQ.Unit.Commands.Update.SelectUnitCommand
{
    using MediatR;
    using System.Security.Claims;

    public class SelectUnitCommand : IRequest<string>
    {
        public string UnitId { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
