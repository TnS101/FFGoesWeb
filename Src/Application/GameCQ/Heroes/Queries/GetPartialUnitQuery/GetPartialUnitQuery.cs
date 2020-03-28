namespace Application.GameCQ.Heroes.Queries.GetPartialUnitQuery
{
    using System.Security.Claims;
    using MediatR;

    public class GetPartialUnitQuery : IRequest<UnitPartialViewModel>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
