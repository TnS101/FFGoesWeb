namespace Application.Common.Mappings
{
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery.ToDoList;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetCurrentFeedbackQuery;
    using Application.CQ.Admin.Users.Queries;
    using Application.CQ.Forum.Message.Queries;
    using Application.CQ.Forum.Topic.Queries.GetCurrentTopicQuery;
    using Application.CQ.Moderator.Queries.GetAllTicketsQuery;
    using Application.CQ.Moderator.Queries.GetCurrentTicketQuery;
    using Application.CQ.User.Feedbacks.Queries;
    using Application.CQ.User.Status.Queries;
    using Application.GameCQ.Item.Queries;
    using Application.GameCQ.Spell.Queries;
    using Application.GameCQ.Treasure.Queries;
    using Application.GameCQ.TreasureKey.Queries;
    using Application.GameCQ.Unit.Queries;
    using Application.GameCQ.Unit.Queries.GetUnitListQuery;
    using AutoMapper;
    using Domain.Base;
    using Domain.Entities.Common;
    using Domain.Entities.Common.Social;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using Domain.Entities.Moderation;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Item, ItemFullViewModel>();
            this.CreateMap<Spell, SpellFullViewModel>();
            this.CreateMap<Treasure, TreasureFullViewModel>();
            this.CreateMap<TreasureKey, TreasureKeyFullViewModel>();
            this.CreateMap<AppUser, UserPartialViewModel>();
            this.CreateMap<Unit, UnitPartialViewModel>();
            this.CreateMap<Unit, UnitFullViewModel>();
            this.CreateMap<Topic, TopicFullViewModel>();
            this.CreateMap<Message, MessageFullViewModel>();
            this.CreateMap<Feedback, FeedbackFulllViewModel>();
            this.CreateMap<Ticket, TicketPartialViewModel>();
            this.CreateMap<Ticket, TicketFullViewModel>();
            this.CreateMap<Feedback, FeedbackFullViewModel>();
            this.CreateMap<Feedback, FeedbackPartialViewModel>();
            this.CreateMap<Feedback, FeedbackTaskViewModel>();
            this.CreateMap<Status, StatusFullViewModel>();
            this.CreateMap<Hero, UnitMinViewModel>();
        }
    }
}