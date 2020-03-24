﻿namespace Domain.Entities.Common
{
    using global::Domain.Entities.Game;
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;
    using Domain.Entities.Common.Social;
    using Domain.Entities.Moderation;
    using Domain.Common;

    public class AppUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public AppUser()
        {
            this.Units = new HashSet<Unit>();
            this.Friends = new HashSet<AppUser>();
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

        public string FriendId { get; set; }

        [ForeignKey("FriendId")]
        public virtual AppUser Friend { get; set; }

        public bool IsLoggedIn { get; set; }

        public int Stars { get; set; }

        public int Warnings { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? LastLogin { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<Unit> Units { get; set; }

        public ICollection<FriendRequest> FriendRequests { get; set; }

        public ICollection<Message> Messages { get; set; }

        public ICollection<UserTopics> UserTopics { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<AppUser> Friends { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}