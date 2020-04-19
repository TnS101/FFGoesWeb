namespace Domain.Entities.Social
{
    using Domain.Entities.Common;

    public class Friend
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }
    }
}
