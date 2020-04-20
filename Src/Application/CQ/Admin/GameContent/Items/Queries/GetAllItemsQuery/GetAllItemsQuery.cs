namespace Application.CQ.Admin.GameContent.Items.Queries.GetAllItemsQuery
{
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using MediatR;

    public class GetAllItemsQuery : IRequest<ItemListViewModel>
    {
        public string Slot { get; set; }
    }
}
