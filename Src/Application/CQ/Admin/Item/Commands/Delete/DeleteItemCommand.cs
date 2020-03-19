namespace Application.CQ.Admin.Item.Commands.Delete
{
    using MediatR;

    public class DeleteItemCommand : IRequest
    {
        public string ItemId { get; set; }
    }
}
