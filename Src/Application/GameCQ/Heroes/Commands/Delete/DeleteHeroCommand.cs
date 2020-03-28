namespace Application.GameCQ.Heroes.Commands.Delete
{
    using MediatR;

    public class DeleteHeroCommand : IRequest<string>
    {
        public int HeroId { get; set; }
    }
}
