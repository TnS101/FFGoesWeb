using MediatR;

namespace WebUI.Controllers.Game
{
    internal class DeleteUnitCommand : IRequest<string>
    {
        public int UnitId { get; set; }
    }
}