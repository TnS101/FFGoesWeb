namespace Application.GameCQ.Items.Queries.GetPersonalItemsQuery
{
    using System.Security.Claims;
    using MediatR;

    public class GetPersonalItemsQuery : IRequest<ItemListViewModel>
    {
        public string Slot { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
