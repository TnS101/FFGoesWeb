namespace Domain.Entities.Common.Social
{
    using System.Collections.Generic;

    public class Status
    {
        public Status()
        {
            this.Users = new HashSet<AppUser>();
        }

        public int Id { get; set; }

        public string DisplayName { get; set; }

        public string IClass { get; set; }

        public ICollection<AppUser> Users { get; set; }
    }
}
