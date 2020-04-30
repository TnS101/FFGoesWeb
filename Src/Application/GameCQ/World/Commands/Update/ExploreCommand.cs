namespace Application.GameCQ.World.Commands.Update
{
    using System.Security.Claims;
    using MediatR;

    public class ExploreCommand : IRequest<string>
    {
        public string UserId { get; set; }
    }
}
