namespace Application.GameCQ.Unit.Commands.Create
{
    using MediatR;
    using System.Security.Claims;

    public class CreateUnitCommand : IRequest<string>
    {
        public ClaimsPrincipal User { get; set; }

        public string ClassType { get; set; }

        public string Race { get; set; }

        public string Name { get; set; }
    }
}
