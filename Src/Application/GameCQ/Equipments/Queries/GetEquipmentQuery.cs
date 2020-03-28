namespace Application.GameCQ.Equipment.Queries
{
    using MediatR;

    public class GetEquipmentQuery : IRequest<EquipmentViewModel>
    {
        public int HeroId { get; set; }

        public string Slot { get; set; }
    }
}
