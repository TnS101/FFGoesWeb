namespace Application.Common.Mappings
{
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery.ToDoList;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetCurrentFeedbackQuery;
    using Application.CQ.Admin.Users.Queries.GetOnlineUsersQuery;
    using Application.CQ.Forum.Topic.Queries.GetCurrentTopicQuery;
    using Application.CQ.Moderator.Queries.GetAllTicketsQuery;
    using Application.CQ.Moderator.Queries.GetCurrentTicketQuery;
    using Application.CQ.Social.Comments.Queries.GetCurrentCommentQuery;
    using Application.CQ.Social.Message.Queries;
    using Application.CQ.Users.Feedbacks.Queries;
    using Application.CQ.Users.Statuses.Queries;
    using Application.GameCQ.FightingClasses.Queries.GetAllFightingClassesQuery;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetPartialUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetUnitListQuery;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using Application.GameCQ.Monsters.Queries.GetAllMonstersQuery;
    using Application.GameCQ.Monsters.Queries.GetMonsterInfoQuery;
    using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;
    using AutoMapper;
    using Domain.Entities.Common;
    using Domain.Entities.Common.Social;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using Domain.Entities.Moderation;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Armor, ItemMinViewModel>();
            this.CreateMap<Weapon, ItemMinViewModel>();
            this.CreateMap<Trinket, ItemMinViewModel>();
            this.CreateMap<Material, ItemMinViewModel>();
            this.CreateMap<Spell, SpellFullViewModel>();
            this.CreateMap<AppUser, UserPartialViewModel>();
            this.CreateMap<Topic, TopicFullViewModel>();
            this.CreateMap<Message, MessageFullViewModel>();
            this.CreateMap<Feedback, FeedbackFulllViewModel>();
            this.CreateMap<Ticket, TicketPartialViewModel>();
            this.CreateMap<Ticket, TicketFullViewModel>();
            this.CreateMap<Feedback, FeedbackFullViewModel>();
            this.CreateMap<Feedback, FeedbackPartialViewModel>();
            this.CreateMap<Feedback, FeedbackTaskViewModel>();
            this.CreateMap<Status, StatusFullViewModel>();
            this.CreateMap<Hero, HeroMinViewModel>();
            this.CreateMap<Hero, UnitPartialViewModel>();
            this.CreateMap<Hero, UnitFullViewModel>();
            this.CreateMap<FightingClass, FightingClassMinViewModel>();
            this.CreateMap<Monster, MonsterMinViewModel>();
            this.CreateMap<Monster, UnitFullViewModel>();
            this.CreateMap<Comment, CommentMinViewModel>();
            this.CreateMap<Monster, MonsterFullViewModel>();
        }
    }
}