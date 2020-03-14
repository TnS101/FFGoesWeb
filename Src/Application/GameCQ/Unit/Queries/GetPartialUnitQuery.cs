namespace Application.GameCQ.Unit.Queries
{
    using MediatR;

    public class GetPartialUnitQuery : IRequest<UnitPartialViewModel>
    {
        public int UnitId { get; set; }
    }
}
