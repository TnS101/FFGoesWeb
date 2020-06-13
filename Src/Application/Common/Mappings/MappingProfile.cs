namespace Application.Common.Mappings
{
    using Application.CQ.Admin.GameContent.Items.Queries.GetAllToolsQuery;
    using Application.CQ.Admin.GameContent.Spells.Queries.GetCurrentSpellQuery;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery.ToDoList;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetCurrentFeedbackQuery;
    using Application.CQ.Moderator.Queries.GetAllTicketsQuery;
    using Application.CQ.Moderator.Queries.GetCurrentTicketQuery;
    using Application.CQ.Social.Comments.Queries.GetCurrentCommentQuery;
    using Application.CQ.Social.FriendRequests.Queries;
    using Application.CQ.Social.Friends.Queries.GetAllFriendsQuery;
    using Application.CQ.Social.Likes.Queries;
    using Application.CQ.Social.Messages.Queries;
    using Application.CQ.Social.Notifications.Queries.GetPersonalNotificationsQuery;
    using Application.CQ.Social.Topics.Queries.GetCurrentTopicQuery;
    using Application.CQ.Users.Feedbacks.Queries;
    using Application.CQ.Users.Statuses.Commands.Update;
    using Application.CQ.Users.Statuses.Queries;
    using Application.GameCQ.Battles.Queries.GetBattleUnitsQuery;
    using Application.GameCQ.FightingClasses.Queries.GetAllFightingClassesQuery;
    using Application.GameCQ.FightingClasses.Queries.GetCurrentFightingClassQuery;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetPartialUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetUnitListQuery;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using Application.GameCQ.Monsters.Queries.GetAllMonstersQuery;
    using Application.GameCQ.Monsters.Queries.GetCurrentMonsterQuery;
    using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;
    using AutoMapper;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using Domain.Entities.Moderation;
    using Domain.Entities.Social;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Armor, ItemMinViewModel>();
            this.CreateMap<Weapon, ItemMinViewModel>();
            this.CreateMap<Trinket, ItemMinViewModel>();
            this.CreateMap<Material, ItemMinViewModel>();
            this.CreateMap<Spell, SpellMinViewModel>();
            this.CreateMap<AppUser, UserPartialViewModel>().ForMember(u => u.Friends, opt => opt.Ignore());
            this.CreateMap<Topic, TopicFullViewModel>();
            this.CreateMap<Message, MessageFullViewModel>();
            this.CreateMap<Feedback, FeedbackFulllViewModel>();
            this.CreateMap<Ticket, TicketPartialViewModel>();
            this.CreateMap<Ticket, TicketFullViewModel>();
            this.CreateMap<Feedback, FeedbackFullViewModel>();
            this.CreateMap<Feedback, FeedbackTaskViewModel>();
            this.CreateMap<Status, StatusFullViewModel>();
            this.CreateMap<Hero, HeroMinViewModel>();
            this.CreateMap<Hero, UnitPartialViewModel>();
            this.CreateMap<Hero, UnitFullViewModel>().ForMember(h => h.Spells, opt => opt.Ignore());
            this.CreateMap<FightingClass, FightingClassMinViewModel>();
            this.CreateMap<Monster, MonsterMinViewModel>();
            this.CreateMap<Monster, UnitFullViewModel>();
            this.CreateMap<Comment, CommentMinViewModel>();
            this.CreateMap<Monster, MonsterFullViewModel>();
            this.CreateMap<Notification, NotificationFullViewModel>();
            this.CreateMap<Material, ItemMinViewModel>();
            this.CreateMap<Tool, ItemMinViewModel>();
            this.CreateMap<TreasureKey, ItemMinViewModel>();
            this.CreateMap<Treasure, ItemMinViewModel>();
            this.CreateMap<FriendRequest, FriendRequestFullViewModel>();
            this.CreateMap<Tool, ToolMinViewModel>();
            this.CreateMap<Spell, SpellFullViewModel>();
            this.CreateMap<FightingClass, FightingClassFullViewModel>();
            this.CreateMap<Like, LikeFullViewModel>();
            this.CreateMap<Hero, BattleUnitViewModel>();
            this.CreateMap<Monster, BattleUnitViewModel>();
            this.CreateMap<Status, UpdateStatusJsonResult>();
        }
    }
}