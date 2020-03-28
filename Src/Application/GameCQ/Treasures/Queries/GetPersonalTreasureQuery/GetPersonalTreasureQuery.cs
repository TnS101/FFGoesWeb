namespace Application.GameCQ.Treasure.Queries
{
    using Application.CQ.Admin.Treasure.Queries.GetAllTreasureQuery;
    using MediatR;

    public class GetPersonalTreasureQuery : IRequest<TreasureListViewModel>
    {
        public int UnitId { get; set; }
    }
}
