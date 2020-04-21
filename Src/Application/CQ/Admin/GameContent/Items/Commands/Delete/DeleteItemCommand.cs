namespace Application.CQ.Admin.GameContent.Items.Commands.Delete
{
    using MediatR;

    public class DeleteItemCommand : IRequest<string>
    {
        public string ItemId { get; set; }

        public string Slot { get; set; }
    }
}
