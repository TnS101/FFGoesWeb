namespace Application.CQ.Admin.GameContent.Items.Queries
{
    using Application.GameCQ.Item.Queries;
    using MediatR;

    public class GetAllItemsQuery : IRequest<ItemListViewModel>
    {
        public string Slot { get; set; }
    }
}
