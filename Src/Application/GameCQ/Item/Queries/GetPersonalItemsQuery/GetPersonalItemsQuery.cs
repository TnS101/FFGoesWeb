namespace Application.GameCQ.Item.Queries
{
    using MediatR;

    public class GetPersonalItemsQuery : IRequest<ItemListViewModel>
    {
        public int UnitId { get; set; }
    }
}
