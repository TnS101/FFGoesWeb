namespace Application.GameCQ.Equipment.Commands.Update
{
    using System.Security.Claims;
    using MediatR;

    public class UpdateEquipmentCommand : IRequest<string>
    {
        public int ItemId { get; set; }

        public string Command { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
