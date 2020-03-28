namespace Application.GameCQ.Heroes.Commands.Update.HeroLevelUpCommand
{
    using MediatR;

    public class HeroLevelUpCommand : IRequest
    {
        public int HeroId { get; set; }
    }
}
