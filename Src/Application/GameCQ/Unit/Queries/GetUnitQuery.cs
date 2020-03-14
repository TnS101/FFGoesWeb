namespace Application.GameCQ.Unit.Queries
{
    using MediatR;

    public class GetUnitQuery : IRequest<UnitViewModel>
    {
        public int UnitId { get; set; }
    }
}
