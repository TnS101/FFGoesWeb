namespace Application.GameCQ.Heroes.Commands.Update.SelectHeroCommand
{
    using System.Security.Claims;
    using MediatR;

    public class SelectHeroCommand : IRequest<string>
    {
        public int Id { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
