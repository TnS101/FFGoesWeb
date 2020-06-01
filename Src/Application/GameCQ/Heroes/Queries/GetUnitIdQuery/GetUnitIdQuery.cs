namespace Application.GameCQ.Heroes.Queries.GetUnitIdQuery
{
    using MediatR;

    public class GetUnitIdQuery : IRequest<UnitIdViewModel>
    {
        public string UserId { get; set; }
    }
}
