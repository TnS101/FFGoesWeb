namespace Domain.Entities.Common.Social
{
    public class UserStatus
    {
        public UserStatus()
        {
        }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }
    }
}
