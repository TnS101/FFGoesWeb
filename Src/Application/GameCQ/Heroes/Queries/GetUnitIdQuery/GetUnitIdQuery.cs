namespace Application.GameCQ.Heroes.Queries.GetUnitIdQuery
{
    using System.Security.Claims;
    using MediatR;

    public class GetUnitIdQuery : IRequest<UnitIdViewModel>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
