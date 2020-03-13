namespace Application.GameCQ.Unit.Commands.Update
{
    using MediatR;

    public class UnitLevelUpCommand : IRequest
    {
        public int UnitId { get; set; }
    }
}
