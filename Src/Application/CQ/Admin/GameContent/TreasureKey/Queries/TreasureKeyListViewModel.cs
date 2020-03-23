namespace Application.CQ.Admin.TreasureKey.Commands.Queries
{
    using System.Collections.Generic;
    using Application.GameCQ.TreasureKey.Queries;

    public class TreasureKeyListViewModel
    {
        public IEnumerable<TreasureKeyFullViewModel> Keys { get; set; }
    }
}
