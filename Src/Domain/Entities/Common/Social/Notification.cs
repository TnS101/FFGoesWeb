namespace Domain.Entities.Common.Social
{
    using System;

    public class Notification
    {
        public Notification()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Type { get; set; }

        public string ApplicationSection { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public string CauserName { get; set; }
    }
}
