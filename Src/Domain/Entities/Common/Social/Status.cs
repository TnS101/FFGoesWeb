namespace Domain.Entities.Common.Social
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Status
    {
        public Status()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Users = new HashSet<AppUser>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string DisplayName { get; set; }

        public string IClass { get; set; }

        public ICollection<AppUser> Users { get; set; }
    }
}
