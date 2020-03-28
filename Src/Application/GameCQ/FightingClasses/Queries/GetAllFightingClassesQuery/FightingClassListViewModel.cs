namespace Application.GameCQ.FightingClasses.Queries.GetAllFightingClassesQuery
{
    using System.Collections.Generic;

    public class FightingClassListViewModel
    {
        public IEnumerable<FightingClassMinViewModel> FightingClasses { get; set; }
    }
}
