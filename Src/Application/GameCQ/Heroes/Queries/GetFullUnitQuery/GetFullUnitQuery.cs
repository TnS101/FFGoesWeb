namespace Application.GameCQ.Heroes.Queries.GetFullUnitQuery
{
    using System.Security.Claims;
    using MediatR;

    public class GetFullUnitQuery : IRequest<UnitFullViewModel>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
