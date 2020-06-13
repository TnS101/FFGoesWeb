namespace Application.GameCQ.Items.Queries.GetPersonalItemsQuery
{
    using MediatR;

    public class GetPersonalItemsQuery : IRequest<ItemListViewModel>
    {
        public string Slot { get; set; }

        public long HeroId { get; set; }

        public string UserId { get; set; }
    }
}
