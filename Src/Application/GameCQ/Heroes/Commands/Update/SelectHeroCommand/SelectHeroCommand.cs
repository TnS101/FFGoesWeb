namespace Application.GameCQ.Heroes.Commands.Update.SelectHeroCommand
{
    using System.Security.Claims;
    using MediatR;

    public class SelectHeroCommand : IRequest<string>
    {
        public string UnitId { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
