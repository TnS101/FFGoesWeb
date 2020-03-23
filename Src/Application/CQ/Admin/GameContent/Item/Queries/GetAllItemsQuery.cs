using Application.GameCQ.Item.Queries;
using MediatR;

namespace Application.CQ.Admin.Item.Queries
{
    public class GetAllItemsQuery : IRequest<ItemListViewModel>
    {
    }
}
