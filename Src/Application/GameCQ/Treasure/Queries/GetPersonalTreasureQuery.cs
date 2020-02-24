namespace Application.GameCQ.Treasure.Queries
{
    using MediatR;

    public class GetPersonalTreasureQuery : IRequest<TreasureListViewModel>
    {
        public int UnitId { get; set; }
    }
}
