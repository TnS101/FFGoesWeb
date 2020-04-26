namespace Application.GameCQ.Items.Commands.Delete
{
    using MediatR;

    public class DiscardItemCommand : IRequest<string>
    {
        public string HeroId { get; set; }

        public string ItemId { get; set; }

        public string Slot { get; set; }

        public int Count { get; set; }
    }
}
