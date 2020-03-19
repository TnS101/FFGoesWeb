namespace Application.GameCQ.Unit.Queries
{
    using MediatR;
    using System.Security.Claims;

    public class GetUnitListQuery : IRequest<UnitListViewModel>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
