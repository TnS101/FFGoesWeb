namespace Application.GameCQ.Heroes.Commands.Delete
{
    using MediatR;

    public class DeleteHeroCommand : IRequest<string>
    {
        public string HeroId { get; set; }
    }
}
