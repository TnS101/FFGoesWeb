
namespace Application.CQ.Admin.GameContent.Spells.Queries.GetCurrentSpellQuery
{
    using MediatR;

    public class GetCurrentSpellQuery : IRequest<SpellFullViewModel>
    {
        public int SpellId { get; set; }
    }
}
