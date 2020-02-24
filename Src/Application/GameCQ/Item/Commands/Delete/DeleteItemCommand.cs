namespace Application.GameCQ.Item.Commands.Delete
{
    using MediatR;

    public class DeleteItemCommand : IRequest
    {
        public int ItemId { get; set; }
    }
}
