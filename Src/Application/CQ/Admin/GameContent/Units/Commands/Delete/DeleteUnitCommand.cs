namespace Application.CQ.Admin.GameContent.Units.Commands.Delete
{
    using MediatR;

    public class DeleteUnitCommand : IRequest<string>
    {
        public string UnitType { get; set; }

        public int UnitId { get; set; }
    }
}
