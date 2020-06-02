namespace Application.CQ.Users.Queries.Panel
{
    using System;
    using System.Collections.Generic;
    using Application.CQ.Users.Feedbacks.Command;
    using Domain.Entities.Social;

    public class UserPanelViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string StatusIClass { get; set; }

        public int Stars { get; set; }

        public int Warnings { get; set; }

        public int ForumPoints { get; set; }

        public int MasteryPoints { get; set; }

        public int Units { get; set; }

        public int Feedbacks { get; set; }

        public int Topics { get; set; }

        public int Friends { get; set; }

        public DateTime? LastFeedbackSentOn { get; set; }

        public SendFeedbackCommand Feedback { get; set; }

        public ICollection<Status> Statuses { get; set; }
    }
}
