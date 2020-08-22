namespace Application.GameCQ.Items.Commands.Delete
{
    using MediatR;

    public class DiscardItemCommand : IRequest<DiscardItemJsonResult>
    {
        public long HeroId { get; set; }

        public long ItemId { get; set; }

        public string Slot { get; set; }

        public int Count { get; set; }

        public string UserId { get; set; }
    }
}
