namespace Application.CQ.Admin.TreasureKey.Commands.Queries
{
    using Application.GameCQ.TreasureKey.Queries;
    using System.Collections.Generic;

    public class TreasureKeyListViewModel
    {
        public IEnumerable<TreasureKeyFullViewModel> Keys { get; set; }
    }
}
