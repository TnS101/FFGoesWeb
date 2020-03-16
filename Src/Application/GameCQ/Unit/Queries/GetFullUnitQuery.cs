namespace Application.GameCQ.Unit.Queries
{
    using MediatR;

    public class GetFullUnitQuery : IRequest<UnitFullViewModel>
    {
        public string UnitId { get; set; }
    }
}
