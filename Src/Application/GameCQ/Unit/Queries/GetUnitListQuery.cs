namespace Application.GameCQ.Unit.Queries
{
    using MediatR;

    public class GetUnitListQuery : IRequest<UnitListViewModel>
    {
        public int UserId { get; set; }
    }
}
