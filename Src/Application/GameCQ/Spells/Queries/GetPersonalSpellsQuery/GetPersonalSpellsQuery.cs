namespace Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery
{
    using MediatR;

    public class GetPersonalSpellsQuery : IRequest<SpellListViewModel>
    {
        public string ClassType { get; set; }
    }
}
