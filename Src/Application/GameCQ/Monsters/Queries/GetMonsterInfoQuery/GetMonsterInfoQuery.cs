namespace Application.GameCQ.Monsters.Queries.GetMonsterInfoQuery
{
    using MediatR;

    public class GetMonsterInfoQuery : IRequest<MonsterFullViewModel>
    {
        public int MonsterId { get; set; }
    }
}
