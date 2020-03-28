namespace Application.GameCQ.Enemy.Commands.Create
{
    using Application.GameCQ.Unit.Queries;
    using MediatR;

    public class GenerateEnemyCommand : IRequest<UnitFullViewModel>
    {
        public int PlayerLevel { get; set; }
    }
}
