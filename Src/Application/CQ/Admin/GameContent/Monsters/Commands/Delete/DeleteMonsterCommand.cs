namespace Application.CQ.Admin.GameContent.Monsters.Commands.Delete
{
    using MediatR;

    public class DeleteMonsterCommand : IRequest<string>
    {
        public int MonsterId { get; set; }
    }
}
