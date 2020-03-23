namespace Application.CQ.Admin.Item.Commands.Delete
{
    using MediatR;

    public class DeleteItemCommand : IRequest<string>
    {
        public string ItemId { get; set; }
    }
}
