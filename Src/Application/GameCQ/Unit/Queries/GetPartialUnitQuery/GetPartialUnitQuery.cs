namespace Application.GameCQ.Unit.Queries
{
    using MediatR;
    using System.Security.Claims;

    public class GetPartialUnitQuery : IRequest<UnitPartialViewModel>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
