namespace Application.Common.Handlers
{
    using Application.CQ.Admin.Item.Commands.Create;
    using Application.CQ.Admin.Item.Commands.Delete;
    using Application.CQ.Admin.Item.Commands.Update;
    using Application.CQ.Admin.Item.Queries;
    using Application.CQ.Admin.Spell.Queries;
    using Application.CQ.Admin.Treasure.Commands.Create;
    using Application.CQ.Admin.Treasure.Commands.Delete;
    using Application.CQ.Admin.Treasure.Queries.GetAllTreasureQuery;
    using Application.CQ.Admin.TreasureKey.Commands.Create;
    using Application.CQ.Admin.TreasureKey.Commands.Delete;
    using Application.CQ.Admin.TreasureKey.Commands.Queries;
    using Application.CQ.Admin.Users.Queries;
    using Application.CQ.Common.Commands;
    using Application.CQ.Forum.Comment.Create;
    using Application.CQ.Forum.Comment.Delete;
    using Application.CQ.Forum.Comment.Update;
    using Application.CQ.Forum.FriendRequest.Commands.Create;
    using Application.CQ.Forum.FriendRequest.Commands.Delete;
    using Application.CQ.Forum.FriendRequest.Commands.Update;
    using Application.CQ.Forum.FriendRequest.Queries;
    using Application.CQ.Forum.Message.Commands.Create;
    using Application.CQ.Forum.Message.Commands.Delete;
    using Application.CQ.Forum.Message.Commands.Update;
    using Application.CQ.Forum.Message.Queries;
    using Application.CQ.Forum.Topic.Commands.Create;
    using Application.CQ.Forum.Topic.Commands.Delete;
    using Application.CQ.Forum.Topic.Commands.Update;
    using Application.CQ.Forum.Topic.Queries.GetAllTopicsQuery;
    using Application.CQ.Forum.Topic.Queries.GetCurrentTopicQuery;
    using Application.GameCQ.Battle.Commands.Update;
    using Application.GameCQ.Enemy.Commands.Create;
    using Application.GameCQ.Equipment.Commands.Update;
    using Application.GameCQ.Equipment.Queries;
    using Application.GameCQ.Image.Queries;
    using Application.GameCQ.Item.Commands.Delete;
    using Application.GameCQ.Item.Commands.Update;
    using Application.GameCQ.Item.Queries;
    using Application.GameCQ.Monster.Queries;
    using Application.GameCQ.Spell.Queries;
    using Application.GameCQ.Treasure.Commands.Delete;
    using Application.GameCQ.Treasure.Commands.Update;
    using Application.GameCQ.Treasure.Queries;
    using Application.GameCQ.TreasureKey.Queries;
    using Application.GameCQ.Unit.Commands.Create;
    using Application.GameCQ.Unit.Commands.Delete;
    using Application.GameCQ.Unit.Commands.Update;
    using Application.GameCQ.Unit.Queries;
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
            services.AddScoped<IRequestHandler<CreateTreasureCommand, string>, CreateTreasureCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteTreasureCommand, string>, DeleteTreasureCommandHandler>();
            services.AddScoped<IRequestHandler<CreateTreasureKeyCommand, string>, CreateTreasureKeyCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteTreasureKeyCommand, string>, DeleteTreasureKeyCommandHandler>();
            services.AddScoped<IRequestHandler<CustomLogoutCommand, string>, CustomLogoutCommandHandler>();
        }

        private void AdminQueries(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<DataSeederCommand, Unit>, DataSeederCommandHandler>();
            services.AddScoped<IRequestHandler<GetOnlineUsersQuery, UserListViewModel>, GetOnlineUsersQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllItemsQuery, ItemListViewModel>, GetAllItemsQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllTreasuresQuery, TreasureListViewModel>, GetAllTreasuresQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllTreasureKeysQuery, TreasureKeyListViewModel>, GetAllTreasureKeysQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllSpellsQuery, SpellListViewModel>, GetAllSpellsQueryHandler>();
        }

        private void UserCommands(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<BattleOptionsCommand, string>, BattleOptionsCommandHandler>();
            services.AddScoped<IRequestHandler<GenerateEnemyCommand, UnitFullViewModel>, GenerateEnemyCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateEquipmentCommand, string>, UpdateEquipmentCommandHandler>();
            services.AddScoped<IRequestHandler<DiscardItemCommand, string>, DiscardItemCommandHandler>();
            services.AddScoped<IRequestHandler<LootItemCommand>, LootItemCommandHandler>();
            services.AddScoped<IRequestHandler<OpenTreasureCommand, string>, OpenTreasureCommandHandler>();
            services.AddScoped<IRequestHandler<LootTreasureCommand, string>, LootTreasureCommandHandler>();
            services.AddScoped<IRequestHandler<LootTreasureCommand, string>, LootTreasureCommandHandler>();
            services.AddScoped<IRequestHandler<CreateUnitCommand, string>, CreateUnitCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUnitCommand, string>, DeleteUnitCommandHandler>();
            services.AddScoped<IRequestHandler<UnitLevelUpCommand>, UnitLevelUpCommandHandler>();
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
        }

        private void UserQueries(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetFightingClassImagesQuery, ImageListViewModel>, GetFightingClassImagesQueryHandler>();
            services.AddScoped<IRequestHandler<GetMonstersImagesQuery, MonsterImageListViewModel>, GetMonstersImagesQueryHandler>();
            services.AddScoped<IRequestHandler<GetEquipmentQuery, EquipmentViewModel>, GetEquipmentQueryHandler>();
            services.AddScoped<IRequestHandler<GetFightingClassImagesQuery, ImageListViewModel>, GetFightingClassImagesQueryHandler>();
            services.AddScoped<IRequestHandler<GetMonstersImagesQuery, MonsterImageListViewModel>, GetMonstersImagesQueryHandler>();
            services.AddScoped<IRequestHandler<GetPersonalItemsQuery, ItemListViewModel>, GetPersonalItemsQueryHandler>();
            services.AddScoped<IRequestHandler<GetPersonalSpellsQuery, SpellListViewModel>, GetPersonalSpellsQueryHandler>();
            services.AddScoped<IRequestHandler<GetPersonalTreasureQuery, TreasureListViewModel>, GetPersonalTreasureQueryHandler>();
            services.AddScoped<IRequestHandler<GetPersonalTreasureKeysQuery, TreasureKeyListViewModel>, GetPersonalTreasureKeysQueryHandler>();
            services.AddScoped<IRequestHandler<GetFullUnitQuery, UnitFullViewModel>, GetFullUnitQueryHandler>();
            services.AddScoped<IRequestHandler<GetPartialUnitQuery, UnitPartialViewModel>, GetPartialUnitQueryHandler>();
            services.AddScoped<IRequestHandler<GetUnitListQuery, UnitListViewModel>, GetUnitListQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllTopicsQuery, TopicListViewModel>, GetAllTopicsQueryHandler>();
            services.AddScoped<IRequestHandler<GetCurrentTopicQuery, TopicFullViewModel>, GetCurrentTopicQueryHandler>();
            services.AddScoped<IRequestHandler<GetPersonalFriendRequestsQuery, FriendRequestListViewModel>, GetPersonalFriendRequestsQueryHandler>();
            services.AddScoped<IRequestHandler<GetPersonalMessagesQuery, MessageListViewModel>, GetPersonalMessagesQueryHandler>();
        }

        private void ModeratorCommands(IServiceCollection services)
        {
        }

        private void ModeratorQueries(IServiceCollection services)
        {
        }
    }
}
