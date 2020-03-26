namespace Application.GameCQ.Unit.Commands.Update
{
    using MediatR;

    public class UnitLevelUpCommand : IRequest
    {
        public string UnitId { get; set; }
    }
}
