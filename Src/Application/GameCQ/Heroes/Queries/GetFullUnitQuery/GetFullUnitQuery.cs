namespace Application.GameCQ.Heroes.Queries.GetFullUnitQuery
{
    using System.Security.Claims;
    using MediatR;

    public class GetFullUnitQuery : IRequest<UnitFullViewModel>
    {
        public string UserId { get; set; }

        public string HeroId { get; set; }
    }
}
