namespace Application.GameCQ.Heroes.Commands.Update.HeroLevelUpCommand
{
    using MediatR;

    public class HeroLevelUpCommand : IRequest
    {
        public string HeroId { get; set; }

        public string StatPick { get; set; }
    }
}
