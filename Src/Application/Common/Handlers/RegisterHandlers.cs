namespace Application.Common.Handlers
{
    using Microsoft.Extensions.DependencyInjection;
    using Application.CQ.Admin.Item.Commands.Create;
    using Application.CQ.Admin.Item.Commands.Delete;
    using Application.CQ.Admin.Item.Commands.Update;
    using Application.CQ.Admin.Item.Queries;
    using Application.CQ.Admin.Treasure.Commands.Create;
    using Application.CQ.Admin.Treasure.Commands.Delete;
    using Application.CQ.Admin.Treasure.Queries.GetAllTreasureQuery;
    using Application.CQ.Admin.TreasureKey.Commands.Create;
    using Application.CQ.Admin.TreasureKey.Commands.Delete;
    using Application.CQ.Admin.TreasureKey.Commands.Queries;
    using Application.CQ.Admin.Users.Queries;
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
        }

        private void AdminCommands(IServiceCollection services) 
        {
            services.AddScoped<IRequestHandler<CreateItemCommand>, CreateItemCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteItemCommand>, DeleteItemCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateItemCommand>, UpdateItemCommandHandler>();
            services.AddScoped<IRequestHandler<CreateTreasureCommand>, CreateTreasureCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteTreasureCommand>, DeleteTreasureCommandHandler>();
            services.AddScoped<IRequestHandler<CreateTreasureKeyCommand>, CreateTreasureKeyCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteTreasureKeyCommand>, DeleteTreasureKeyCommandHandler>();
        }

        private void AdminQueries(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<DataSeederCommand, Unit>, DataSeederCommandHandler>();
            services.AddScoped<IRequestHandler<GetOnlineUsersQuery, UserListViewModel>, GetOnlineUsersQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllItemsQuery, ItemListViewModel>, GetAllItemsQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllTreasuresQuery, TreasureListViewModel>, GetAllTreasuresQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllTreasureKeysQuery, TreasureKeyListViewModel>, GetAllTreasureKeysQueryHandler>();
        }

        private void UserCommands(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<BattleOptionsCommand, string>, BattleOptionsCommandHandler>();
            services.AddScoped<IRequestHandler<GenerateEnemyCommand, UnitFullViewModel>, GenerateEnemyCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateEquipmentCommand>, UpdateEquipmentCommandHandler>();
            services.AddScoped<IRequestHandler<DiscardItemCommand>, DiscardItemCommandHandler>();
            services.AddScoped<IRequestHandler<LootItemCommand>, LootItemCommandHandler>();
            services.AddScoped<IRequestHandler<OpenTreasureCommand>, OpenTreasureCommandHandler>();
            services.AddScoped<IRequestHandler<LootTreasureCommand>, LootTreasureCommandHandler>();
            services.AddScoped<IRequestHandler<LootTreasureCommand>, LootTreasureCommandHandler>();
            services.AddScoped<IRequestHandler<CreateUnitCommand>, CreateUnitCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUnitCommand>, DeleteUnitCommandHandler>();
            services.AddScoped<IRequestHandler<UnitLevelUpCommand>, UnitLevelUpCommandHandler>();
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
        }
    }
}
