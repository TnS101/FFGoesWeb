namespace Application.GameCQ.Unit.Queries
{
    using MediatR;

    public class GetUnitListQuery : IRequest<UnitListViewModel>
    {
        public string UserId { get; set; }
    }
}
