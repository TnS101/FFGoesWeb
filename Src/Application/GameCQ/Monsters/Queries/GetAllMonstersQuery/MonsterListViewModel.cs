namespace Application.GameCQ.Monsters.Queries.GetAllMonstersQuery
{
    using System.Collections.Generic;

    public class MonsterListViewModel
    {
        public IEnumerable<MonsterMinViewModel> Monsters { get; set; }
    }
}
