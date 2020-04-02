namespace Application.Common.Handlers
{
    using Application.CQ.Admin.GameContent.Items.Commands.Create;
    using Application.CQ.Admin.GameContent.Items.Commands.Delete;
    using Application.CQ.Admin.GameContent.Items.Commands.Update;
    using Application.CQ.Admin.GameContent.Items.Queries;
    using Application.CQ.Admin.GameContent.Spells.Queries;
    using Application.CQ.Admin.Moderation.Feedback.Commands.Delete.FeedbackTaskDoneCommand;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery.ToDoList;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetCurrentFeedbackQuery;
    using Application.CQ.Admin.Moderation.Feedbacks.Commands.Delete.DeleteFeedbackCommand;
    using Application.CQ.Admin.Moderation.Feedbacks.Commands.Update;
    using Application.CQ.Admin.Users.Queries.GetOnlineUsersQuery;
    using Application.CQ.Common.Commands;
    using Application.CQ.Forum.Topic.Commands.Create;
    using Application.CQ.Forum.Topic.Commands.Delete;
    using Application.CQ.Forum.Topic.Commands.Update;
    using Application.CQ.Forum.Topic.Queries.GetAllTopicsQuery;
    using Application.CQ.Forum.Topic.Queries.GetCurrentTopicQuery;
    using Application.CQ.Moderator.Commands.Delete;
    using Application.CQ.Moderator.Commands.Update;
    using Application.CQ.Moderator.Queries.GetAllTicketsQuery;
    using Application.CQ.Moderator.Queries.GetCurrentTicketQuery;
    using Application.CQ.Social.Comments.Commands.Create;
    using Application.CQ.Social.FriendRequest.Queries;
    using Application.CQ.Social.FriendRequests.Commands.Create;
    using Application.CQ.Social.FriendRequests.Commands.Delete;
    using Application.CQ.Social.FriendRequests.Commands.Update;
    using Application.CQ.Social.Friends.Queries.GetAllFriendsQuery;
    using Application.CQ.Social.Message.Commands.Create;
    using Application.CQ.Social.Message.Queries;
    using Application.CQ.Users.Queries.Panel;
    using Application.CQ.Users.Statuses.Commands.Update;
    using Application.CQ.Users.Statuses.Queries;
    using Application.GameCQ.Battles.Commands.Update;
    using Application.GameCQ.Equipments.Commands.Update;
    using Application.GameCQ.Equipments.Queries;
    using Application.GameCQ.FightingClasses.Queries.GetAllFightingClassesQuery;
    using Application.GameCQ.Heroes.Commands.Create;
    using Application.GameCQ.Heroes.Commands.Delete;
    using Application.GameCQ.Heroes.Commands.Update.HeroLevelUpCommand;
    using Application.GameCQ.Heroes.Commands.Update.SelectHeroCommand;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetPartialUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetUnitListQuery;
    using Application.GameCQ.Items.Commands.Delete;
    using Application.GameCQ.Items.Commands.Update;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using Application.GameCQ.Monsters.Commands.Create;
    using Application.GameCQ.Monsters.Queries.GetAllMonstersQuery;
    using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;
    using Application.GameCQ.Treasures.Commands.Delete;
    using Application.GameCQ.Treasures.Commands.Update;
    using Application.GameCQ.World.Commands.Update;
    using Application.SeedInitialData;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    public class RegisterHandlers
    {
        public RegisterHandlers(IServiceCollection services)
        {
            this.Register(services);
        }

        public void Register(IServiceCollection services)
        {
            this.AdminCommands(services);
            this.AdminQueries(services);
            this.UserCommands(services);
            this.UserQueries(services);
            this.ModeratorCommands(services);
            this.ModeratorQueries(services);
        }

        private void AdminCommands(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateItemCommand, string>, CreateItemCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteItemCommand, string>, DeleteItemCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateItemCommand, string>, UpdateItemCommandHandler>();
            services.AddScoped<IRequestHandler<CustomLogoutCommand, string>, CustomLogoutCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteFeedbackCommand, string>, DeleteFeedbackCommandHandler>();
            services.AddScoped<IRequestHandler<AcceptFeedbackCommand, string>, AcceptFeedbackCommandHandler>();
            services.AddScoped<IRequestHandler<FeedbackTaskDoneCommand, string>, FeedbackTaskDoneCommandHandler>();
        }

        private void AdminQueries(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<DataSeederCommand, Unit>, DataSeederCommandHandler>();
            services.AddScoped<IRequestHandler<GetOnlineUsersQuery, UserListViewModel>, GetOnlineUsersQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllSpellsQuery, SpellListViewModel>, GetAllSpellsQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllItemsQuery, ItemListViewModel>, GetAllItemsQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllFeedbacksQuery, FeedbacksListViewModel>, GetAllFeedbacksQueryHandler>();
            services.AddScoped<IRequestHandler<GetCurrentFeedbackQuery, FeedbackFullViewModel>, GetCurrentFeedbackQueryHandler>();
            services.AddScoped<IRequestHandler<ToDoList, FeedbackTaskListViewModel>, ToDoListHandler>();
        }

        private void UserCommands(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<BattleOptionsCommand, string>, BattleOptionsCommandHandler>();
            services.AddScoped<IRequestHandler<GenerateMonsterCommand, UnitFullViewModel>, GenerateMonsterCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateEquipmentCommand, string>, UpdateEquipmentCommandHandler>();
            services.AddScoped<IRequestHandler<DiscardItemCommand, string>, DiscardItemCommandHandler>();
            services.AddScoped<IRequestHandler<LootItemCommand>, LootItemCommandHandler>();
            services.AddScoped<IRequestHandler<OpenTreasureCommand, string>, OpenTreasureCommandHandler>();
            services.AddScoped<IRequestHandler<LootTreasureCommand, string>, LootTreasureCommandHandler>();
            services.AddScoped<IRequestHandler<LootTreasureCommand, string>, LootTreasureCommandHandler>();
            services.AddScoped<IRequestHandler<CreateHeroCommand, string>, CreateHeroCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteHeroCommand, string>, DeleteHeroCommandHandler>();
            services.AddScoped<IRequestHandler<HeroLevelUpCommand>, HeroLevelUpCommandHandler>();
            services.AddScoped<IRequestHandler<CreateTopicCommand, string[]>, CreateTopicCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteTopicCommand, string>, DeleteTopicCommandHandler>();
            services.AddScoped<IRequestHandler<EditTopicCommand, string>, EditTopicCommandHandler>();
            services.AddScoped<IRequestHandler<CreateCommentCommand, string>, CreateCommentCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCommentCommand, string>, DeleteCommentCommandHandler>();
            services.AddScoped<IRequestHandler<EditCommentCommand, string>, EditCommentCommandHandler>();
            services.AddScoped<IRequestHandler<SendFriendRequestCommand, string>, SendFriendRequestCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteFriendRequestCommand, string>, DeleteFriendRequestCommandHandler>();
            services.AddScoped<IRequestHandler<AcceptFriendRequestCommand, string>, AcceptFriendRequestCommandHandler>();
            services.AddScoped<IRequestHandler<SendMessageCommand, string>, SendMessageCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteMessageCommand, string>, DeleteMessageCommandHandler>();
            services.AddScoped<IRequestHandler<EditMessageCommand, string>, EditMessageCommandHandler>();
            services.AddScoped<IRequestHandler<SelectHeroCommand, string>, SelectHeroCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStatusCommand, string>, UpdateStatusCommandHandler>();
            services.AddScoped<IRequestHandler<ExploreCommand, string>, ExploreCommandHandler>();
        }

        private void UserQueries(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetEquipmentQuery, EquipmentViewModel>, GetEquipmentQueryHandler>();
            services.AddScoped<IRequestHandler<GetPersonalItemsQuery, ItemListViewModel>, GetPersonalItemsQueryHandler>();
            services.AddScoped<IRequestHandler<GetPersonalSpellsQuery, SpellListViewModel>, GetPersonalSpellsQueryHandler>();
            services.AddScoped<IRequestHandler<GetFullUnitQuery, UnitFullViewModel>, GetFullUnitQueryHandler>();
            services.AddScoped<IRequestHandler<GetPartialUnitQuery, UnitPartialViewModel>, GetPartialUnitQueryHandler>();
            services.AddScoped<IRequestHandler<GetHeroListQuery, HeroListViewModel>, GetHeroListQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllTopicsQuery, TopicListViewModel>, GetAllTopicsQueryHandler>();
            services.AddScoped<IRequestHandler<GetCurrentTopicQuery, TopicFullViewModel>, GetCurrentTopicQueryHandler>();
            services.AddScoped<IRequestHandler<GetPersonalFriendRequestsQuery, FriendRequestListViewModel>, GetPersonalFriendRequestsQueryHandler>();
            services.AddScoped<IRequestHandler<GetPersonalMessagesQuery, MessageListViewModel>, GetPersonalMessagesQueryHandler>();
            services.AddScoped<IRequestHandler<UserPanelQuery, UserPanelViewModel>, UserPanelQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllStatusesQuery, StatusListViewModel>, GetAllStatusesQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllFightingClassesQuery, FightingClassListViewModel>, GetAllFightingClassesQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllMonstersQuery, MonsterListViewModel>, GetAllMonstersQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllFriendsQuery, UserListViewModel>, GetAllFriendsQueryHandler>();
        }

        private void ModeratorCommands(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<DeleteTicketCommand, string>, DeleteTicketCommandHandler>();
            services.AddScoped<IRequestHandler<CloseTicketCommand, string>, CloseTicketCommandHandler>();
        }

        private void ModeratorQueries(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetAllTicketsQuery, TicketsListViewModel>, GetAllTicketsQueryHandler>();
            services.AddScoped<IRequestHandler<GetCurrentTicketQuery, TicketFullViewModel>, GetCurrentTicketQueryHandler>();
        }
    }
}
