namespace Application.CQ.Admin.Spell.Queries
{
    using Application.GameCQ.Spell.Queries;
    using MediatR;

    public class GetAllSpellsQuery : IRequest<SpellListViewModel>
    {
    }
}
