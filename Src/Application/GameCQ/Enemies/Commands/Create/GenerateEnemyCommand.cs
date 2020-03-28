namespace Application.GameCQ.Enemies.Commands.Create
{
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using MediatR;

    public class GenerateEnemyCommand : IRequest<UnitFullViewModel>
    {
        public int PlayerLevel { get; set; }
    }
}
