namespace Application.CQ.Admin.GameContent.Items.Queries.GetCurrentItemQuery
{
    using MediatR;

    public class GetCurrentItemQuery : IRequest<ItemFullViewModel>
    {
        public string ItemId { get; set; }

        public string Slot { get; set; }
    }
}
