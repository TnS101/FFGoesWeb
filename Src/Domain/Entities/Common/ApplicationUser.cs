namespace Domain.Entities.Common
{
    using global::Domain.Entities.Game;
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;
    using Domain.Entities.Common.Social;
    using Domain.Entities.Moderation;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Units = new HashSet<Unit>();
            this.Friends = new HashSet<ApplicationUser>();
            this.FriendRequests = new HashSet<FriendRequest>();
            this.Messages = new HashSet<Message>();
            this.UserTopics = new HashSet<UserTopics>();
            this.Id = Guid.NewGuid().ToString();
            this.Comments = new HashSet<Comment>();
            this.Notifications = new HashSet<Notification>();
            this.Feedbacks = new HashSet<Feedback>();

            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        public override string Id { get; set; }

        public string FriendId { get; set; }

        [ForeignKey("FriendId")]
        public virtual ApplicationUser Friend { get; set; }

        public override string UserName { get; set; }

        public string Password { get; set; }

        public override string Email { get; set; }

        public bool IsLoggedIn { get; set; }

        public int Stars { get; set; }

        public DateTime? LastLogin { get; set; }

        public ICollection<Unit> Units { get; set; }

        public ICollection<FriendRequest> FriendRequests { get; set; }

        public ICollection<Message> Messages { get; set; }

        public ICollection<UserTopics> UserTopics { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<ApplicationUser> Friends { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
