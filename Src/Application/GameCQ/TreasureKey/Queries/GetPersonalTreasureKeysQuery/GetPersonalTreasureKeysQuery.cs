namespace Application.GameCQ.TreasureKey.Queries
{
    using Application.CQ.Admin.TreasureKey.Commands.Queries;
    using MediatR;

    public class GetPersonalTreasureKeysQuery : IRequest<TreasureKeyListViewModel>
    {
        public int UnitId { get; set; }
    }
}
