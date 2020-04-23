namespace Application.CQ.Admin.GameContent.FightingClasses.Commands.Delete
{
    using MediatR;

    public class DeleteFightingClassCommand : IRequest<string>
    {
        public int UnitId { get; set; }
    }
}
