namespace Application.GameCQ.Equipment.Commands.Update
{
    using MediatR;

    public class UpdateEquipmentCommand : IRequest
    {
        public string ItemId { get; set; }

        public string UnitId { get; set; }

        public string Command { get; set; }
    }
}
