namespace Application.GameCQ.TreasureKey.Queries
{
    using MediatR;

    public class GetPersonalTreasureKeysQuery : IRequest<TreasureKeyListViewModel>
    {
        public int UnitId { get; set; }
    }
}
