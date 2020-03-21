namespace Application.GameCQ.Equipment.Commands.Update
{
    using MediatR;
    using System.Security.Claims;

    public class UpdateEquipmentCommand : IRequest<string>
    {
        public string ItemId { get; set; }

        public string Command { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
