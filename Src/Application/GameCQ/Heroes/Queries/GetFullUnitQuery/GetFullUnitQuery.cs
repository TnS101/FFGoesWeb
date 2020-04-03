namespace Application.GameCQ.Heroes.Queries.GetFullUnitQuery
{
    using MediatR;

    public class GetFullUnitQuery : IRequest<UnitFullViewModel>
    {
        public string HeroId { get; set; }
    }
}
