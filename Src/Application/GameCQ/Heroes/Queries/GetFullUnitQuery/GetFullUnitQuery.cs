namespace Application.GameCQ.Heroes.Queries.GetFullUnitQuery
{
    using MediatR;

    public class GetFullUnitQuery : IRequest<UnitFullViewModel>
    {
        public string UserId { get; set; }

        public long HeroId { get; set; }
    }
}
