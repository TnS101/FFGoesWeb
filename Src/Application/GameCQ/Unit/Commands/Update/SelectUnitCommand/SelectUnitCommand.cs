namespace Application.GameCQ.Unit.Commands.Update.SelectUnitCommand
{
    using MediatR;

    public class SelectUnitCommand : IRequest<string>
    {
        public string UnitId { get; set; }
    }
}
