namespace Application.GameCQ.Spell.Queries
{
    using MediatR;

    public class GetPersonalSpellsQuery : IRequest<SpellListViewModel>
    {
        public string ClassType { get; set; }
    }
}
