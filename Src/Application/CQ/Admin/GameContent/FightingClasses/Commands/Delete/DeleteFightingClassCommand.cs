namespace Application.CQ.Admin.GameContent.FightingClasses.Commands.Delete
{
    using MediatR;

    public class DeleteFightingClassCommand : IRequest<string>
    {
        public int FightingClassId { get; set; }
    }
}
