namespace Application.GameCQ.Equipment.Commands.Update
{
    using MediatR;

    public class UpdateEquipmentCommand : IRequest
    {
        public int ItemId { get; set; }

        public int UnitId { get; set; }

        public string Command { get; set; }
    }
}
