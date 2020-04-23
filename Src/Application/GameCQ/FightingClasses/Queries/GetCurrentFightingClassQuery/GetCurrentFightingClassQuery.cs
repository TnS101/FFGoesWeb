namespace Application.GameCQ.FightingClasses.Queries.GetCurrentFightingClassQuery
{
    using MediatR;

    public class GetCurrentFightingClassQuery : IRequest<FightingClassFullViewModel>
    {
        public int FightingClassId { get; set; }
    }
}
