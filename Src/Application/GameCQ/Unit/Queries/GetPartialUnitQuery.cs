namespace Application.GameCQ.Unit.Queries
{
    using MediatR;

    public class GetPartialUnitQuery : IRequest<UnitPartialViewModel>
    {
        public string UnitId { get; set; }
    }
}
