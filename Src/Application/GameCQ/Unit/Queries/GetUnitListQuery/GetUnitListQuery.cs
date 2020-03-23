namespace Application.GameCQ.Unit.Queries
{
    using System.Security.Claims;
    using MediatR;

    public class GetUnitListQuery : IRequest<UnitListViewModel>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
