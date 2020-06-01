namespace Application.GameCQ.Heroes.Commands.Update.SelectHeroCommand
{
    using MediatR;

    public class SelectHeroCommand : IRequest<string>
    {
        public long HeroId { get; set; }

        public string UserId { get; set; }
    }
}
