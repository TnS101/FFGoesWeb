namespace Application.CQ.Admin.Item.Commands.Delete
{
    using MediatR;

    public class DeleteItemCommand : IRequest<string>
    {
        public int ItemId { get; set; }

        public string Slot { get; set; }
    }
}
