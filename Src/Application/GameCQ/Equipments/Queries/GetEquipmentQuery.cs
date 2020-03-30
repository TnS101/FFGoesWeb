namespace Application.GameCQ.Equipments.Queries
{
    using MediatR;

    public class GetEquipmentQuery : IRequest<EquipmentViewModel>
    {
        public string HeroId { get; set; }

        public string Slot { get; set; }
    }
}
