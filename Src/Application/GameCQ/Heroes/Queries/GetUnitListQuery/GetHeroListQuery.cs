namespace Application.GameCQ.Heroes.Queries.GetUnitListQuery
{
    using System.Security.Claims;
    using MediatR;

    public class GetHeroListQuery : IRequest<HeroListViewModel>
    {
        public string UserId { get; set; }
    }
}
