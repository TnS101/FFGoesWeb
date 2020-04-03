namespace Application.GameCQ.Heroes.Commands.Create
{
    using System.Security.Claims;
    using MediatR;

    public class CreateHeroCommand : IRequest<string[]>
    {
        public ClaimsPrincipal User { get; set; }

        public string ClassType { get; set; }

        public string Race { get; set; }

        public string Name { get; set; }
    }
}
