namespace Application.CQ.Admin.GameContent.Spells.Queries
{
    using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;
    using MediatR;

    public class GetAllSpellsQuery : IRequest<SpellListViewModel>
    {
    }
}
