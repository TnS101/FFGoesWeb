namespace Application.GameCQ.Unit.Queries
{
    using System.Security.Claims;
    using MediatR;

    public class GetPartialUnitQuery : IRequest<UnitPartialViewModel>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
