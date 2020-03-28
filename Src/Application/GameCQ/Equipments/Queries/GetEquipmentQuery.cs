namespace Application.GameCQ.Equipment.Queries
{
    using MediatR;

    public class GetEquipmentQuery : IRequest<EquipmentViewModel>
    {
        public int UnitId { get; set; }
    }
}
