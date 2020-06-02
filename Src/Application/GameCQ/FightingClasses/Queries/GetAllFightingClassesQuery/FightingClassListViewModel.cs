namespace Application.GameCQ.FightingClasses.Queries.GetAllFightingClassesQuery
{
    using System.Collections.Generic;
    using Application.GameCQ.Heroes.Commands.Create;

    public class FightingClassListViewModel
    {
        public CreateHeroCommand Hero { get; set; }

        public IEnumerable<FightingClassMinViewModel> FightingClasses { get; set; }
    }
}
