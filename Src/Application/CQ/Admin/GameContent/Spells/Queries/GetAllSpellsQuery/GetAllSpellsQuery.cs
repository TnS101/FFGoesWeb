namespace Application.CQ.Admin.GameContent.Spells.Queries.GetAllSpellsQuery
{
    using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;
    using MediatR;

    public class GetAllSpellsQuery : IRequest<SpellListViewModel>
    {
        public string ClassType { get; set; }
    }
}
