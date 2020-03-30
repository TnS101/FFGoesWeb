namespace Application.GameCQ.Items.Queries.GetPersonalItemsQuery
{
    using MediatR;

    public class GetPersonalItemsQuery : IRequest<ItemListViewModel>
    {
        public string HeroId { get; set; }

        public string Slot { get; set; }
    }
}
