﻿namespace Application.GameCQ.Heroes.Queries.GetUnitListQuery
{
    using System.Collections.Generic;

    public class UnitListViewModel
    {
        public IEnumerable<UnitMinViewModel> Units { get; set; }
    }
}