namespace Application.CQ.Admin.GameContent.Spells.Commands.Delete
{
    using MediatR;

    public class DeleteSpellCommand : IRequest<string>
    {
        public int SpellId { get; set; }
    }
}
