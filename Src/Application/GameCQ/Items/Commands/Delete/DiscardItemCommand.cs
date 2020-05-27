namespace Application.GameCQ.Items.Commands.Delete
{
    using MediatR;

    public class DiscardItemCommand : IRequest<string>
    {
        public ulong HeroId { get; set; }

        public ulong ItemId { get; set; }

        public string Slot { get; set; }

        public int Count { get; set; }
    }
}
