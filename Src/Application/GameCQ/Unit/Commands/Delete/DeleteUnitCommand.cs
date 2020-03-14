namespace Application.GameCQ.Unit.Commands.Delete
{
    using MediatR;

    public class DeleteUnitCommand : IRequest
    {
        public int UnitId { get; set; }
    }
}
