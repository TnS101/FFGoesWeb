namespace Application.GameCQ.Unit.Queries
{
    using MediatR;
    using System.Security.Claims;

    public class GetFullUnitQuery : IRequest<UnitFullViewModel>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
