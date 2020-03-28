﻿namespace Application.Common.Mappings
{
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery.ToDoList;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetCurrentFeedbackQuery;
    using Application.CQ.Admin.Users.Queries.GetOnlineUsersQuery;
    using Application.CQ.Forum.Topic.Queries.GetCurrentTopicQuery;
    using Application.CQ.Moderator.Queries.GetAllTicketsQuery;
    using Application.CQ.Moderator.Queries.GetCurrentTicketQuery;
    using Application.CQ.Social.Message.Queries;
    using Application.CQ.Users.Feedbacks.Queries;
    using Application.CQ.Users.Statuses.Queries;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetPartialUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetUnitListQuery;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;
    using AutoMapper;
    using Domain.Base;
    using Domain.Entities.Common;
    using Domain.Entities.Common.Social;
    using Domain.Entities.Game.Units;
    using Domain.Entities.Moderation;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Item, ItemMinViewModel>();
            this.CreateMap<Spell, SpellFullViewModel>();
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