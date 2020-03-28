namespace Application.GameCQ.Item.Queries
{
    using MediatR;

    public class GetPersonalItemsQuery : IRequest<ItemListViewModel>
    {
        public int HeroId { get; set; }

        public string Slot { get; set; }
    }
}
