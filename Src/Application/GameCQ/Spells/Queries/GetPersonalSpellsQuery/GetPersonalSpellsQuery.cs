namespace Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery
{
    using MediatR;

    public class GetPersonalSpellsQuery : IRequest<SpellListViewModel>
    {
        public int FightingClassId { get; set; }
    }
}
