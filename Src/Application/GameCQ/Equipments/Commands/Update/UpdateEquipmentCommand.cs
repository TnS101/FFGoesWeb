namespace Application.GameCQ.Equipments.Commands.Update
{
    using MediatR;

    public class UpdateEquipmentCommand : IRequest<long>
    {
        public long ItemId { get; set; }

        public string Command { get; set; }

        public string Slot { get; set; }

        public long HeroId { get; set; }

        public string UserId { get; set; }
    }
}
