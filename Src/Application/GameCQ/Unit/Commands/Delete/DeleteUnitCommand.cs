namespace Application.GameCQ.Unit.Commands.Delete
{
    using MediatR;

    public class DeleteUnitCommand : IRequest
    {
        public string UnitId { get; set; }
    }
}
