namespace Application.GameCQ.Heroes.Commands.Delete
{
    using MediatR;

    public class DeleteHeroCommand : IRequest<string>
    {
        public long HeroId { get; set; }
    }
}
