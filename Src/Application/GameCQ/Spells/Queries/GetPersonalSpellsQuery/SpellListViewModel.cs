namespace Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery
{
    using System.Collections.Generic;

    public class SpellListViewModel
    {
        public IEnumerable<SpellFullViewModel> Spells { get; set; }
    }
}
