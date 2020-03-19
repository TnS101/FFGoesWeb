namespace Application.GameCQ.Item.Queries
{
    using MediatR;

    public class GetPersonalItemsQuery : IRequest<ItemListViewModel>
    {
        public string UnitId { get; set; }
    }
}
