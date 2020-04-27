namespace Application.Tests.Infrastructure
{
    using Domain.Entities.Common;
    using Domain.Entities.Game.Units;
    using Domain.Entities.Social;
    using Persistence.Context;
    using System;

    public static class CommandArrangeHelper
    {
        public static string GetHeroId(FFDbContext context)
        {
            var hero = new Hero { Id = Guid.NewGuid().ToString(), };

            context.Heroes.Add(hero);
            context.SaveChanges();

            return context.Heroes.Find(hero.Id).Id;
        }

        public static string GetUserId(FFDbContext context)
        {
            var user = new AppUser { Id = Guid.NewGuid().ToString() };

            context.AppUsers.Add(user);
            context.SaveChanges();

            return context.AppUsers.Find(user.Id).Id;
        }

        public static string GetTopicId(FFDbContext context)
        {
            var topic = new Topic { Id = Guid.NewGuid().ToString() };

            context.Topics.Add(topic);
            context.SaveChanges();

            return context.Topics.Find(topic.Id).Id;
        }

        public static string GetCommentId(FFDbContext context)
        {
            var comment = new Comment { Id = Guid.NewGuid().ToString() };

            context.Comments.Add(comment);
            context.SaveChanges();

            return context.Topics.Find(comment.Id).Id;
        }

        public static string GetMessageId(FFDbContext context)
        {
            var message = new Message { Id = Guid.NewGuid().ToString() };

            context.Messages.Add(message);
            context.SaveChanges();

            return context.Topics.Find(message.Id).Id;
        }

        public static int GetStatusId(FFDbContext context)
        {
            var status = new Status { Id = 1 };

            context.Statuses.Add(status);
            context.SaveChanges();

            return context.Topics.Find(status.Id).Id;
        }
    }
}
