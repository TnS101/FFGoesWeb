namespace Application.GameCQ.Consumeables.Commands.Delete
{
    using MediatR;

    public class ConsumeCommand : IRequest
    {
        public int ConsumeableId { get; set; }

        public long HeroId { get; set; }

        public string UserId { get; set; }
    }
}
