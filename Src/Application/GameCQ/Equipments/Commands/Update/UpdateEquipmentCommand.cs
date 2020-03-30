namespace Application.GameCQ.Equipments.Commands.Update
{
    using System.Security.Claims;
    using MediatR;

    public class UpdateEquipmentCommand : IRequest<string>
    {
        public string ItemId { get; set; }

        public string Command { get; set; }

        public string Slot { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
