namespace Application.GameCQ.Unit.Commands.Update.SelectUnitCommand
{
    using System.Security.Claims;
    using MediatR;

    public class SelectUnitCommand : IRequest<string>
    {
        public string Id { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
