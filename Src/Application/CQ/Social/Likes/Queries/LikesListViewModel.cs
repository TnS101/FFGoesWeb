namespace Application.CQ.Social.Likes.Queries
{
    using System.Collections.Generic;

    public class LikesListViewModel
    {
        public IEnumerable<LikeFullViewModel> Likes { get; set; }
    }
}
