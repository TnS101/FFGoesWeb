namespace Application.CQ.Admin.GameContent.Spells.Queries
{
    using Application.GameCQ.Spell.Queries;
    using MediatR;

    public class GetAllSpellsQuery : IRequest<SpellListViewModel>
    {
    }
}
