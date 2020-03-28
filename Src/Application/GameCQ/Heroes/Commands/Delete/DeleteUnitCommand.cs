namespace Application.GameCQ.Unit.Commands.Delete
{
    using MediatR;

    public class DeleteUnitCommand : IRequest<string>
    {
        public int UnitId { get; set; }
    }
}
