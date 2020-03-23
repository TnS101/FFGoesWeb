namespace Application.CQ.Admin.Item.Queries
{
    using Application.GameCQ.Item.Queries;
    using MediatR;

    public class GetAllItemsQuery : IRequest<ItemListViewModel>
    {
    }
}
