namespace Application.GameCQ.Monsters.Queries.GetCurrentMonsterQuery
{
    using MediatR;

    public class GetCurrentMonsterQuery : IRequest<MonsterFullViewModel>
    {
        public int MonsterId { get; set; }
    }
}
