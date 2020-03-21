namespace Application.GameCQ.Unit.Commands.Delete
{
    using MediatR;

    public class DeleteUnitCommand : IRequest<string>
    {
        public string UnitId { get; set; }
    }
}
