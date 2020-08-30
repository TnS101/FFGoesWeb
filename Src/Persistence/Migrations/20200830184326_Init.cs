using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmorValue = table.Column<double>(nullable: false),
                    ResistanceValue = table.Column<double>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Level = table.Column<int>(nullable: false),
                    ClassType = table.Column<string>(maxLength: 30, nullable: false),
                    Stamina = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Agility = table.Column<int>(nullable: false),
                    Intellect = table.Column<int>(nullable: false),
                    Spirit = table.Column<int>(nullable: false),
                    BuyPrice = table.Column<int>(nullable: false),
                    SellPrice = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    IsCraftable = table.Column<bool>(nullable: false),
                    MaterialType = table.Column<string>(maxLength: 30, nullable: false),
                    Slot = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consumeables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<string>(maxLength: 30, nullable: false),
                    Stat = table.Column<string>(nullable: true),
                    StatReplenish = table.Column<double>(nullable: false),
                    HungerReplenish = table.Column<int>(nullable: false),
                    ThirstReplenish = table.Column<int>(nullable: false),
                    Effect = table.Column<string>(nullable: true),
                    EffectPower = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    DroppedFrom = table.Column<string>(nullable: true),
                    IsRefineable = table.Column<bool>(nullable: false),
                    IsCraftable = table.Column<bool>(nullable: false),
                    RelatedMaterials = table.Column<string>(nullable: true),
                    BuyPrice = table.Column<int>(nullable: false),
                    SellPrice = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 50, nullable: false),
                    Slot = table.Column<string>(nullable: true, defaultValue: "Consumeable")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumeables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FightingClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 20, nullable: false),
                    MaxHP = table.Column<double>(nullable: false),
                    MaxMana = table.Column<double>(nullable: false),
                    HealthRegen = table.Column<double>(nullable: false),
                    ManaRegen = table.Column<double>(nullable: false),
                    AttackPower = table.Column<double>(nullable: false),
                    ArmorValue = table.Column<double>(nullable: false),
                    ResistanceValue = table.Column<double>(nullable: false),
                    MagicPower = table.Column<double>(nullable: false),
                    CritChance = table.Column<double>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    IconPath = table.Column<string>(maxLength: 50, nullable: false),
                    ImagePath = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FightingClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LootBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    RewardAmplifier = table.Column<int>(nullable: false),
                    RequiresKey = table.Column<bool>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Slot = table.Column<string>(nullable: true, defaultValue: "Loot Box")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LootBoxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LootKeys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Slot = table.Column<string>(nullable: true, defaultValue: "Loot Key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LootKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonstersRarities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonsterName = table.Column<string>(nullable: true),
                    StatAmplifier = table.Column<double>(nullable: false),
                    Rarity = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonstersRarities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 20, nullable: false),
                    Bonus = table.Column<double>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    ProfessionZone = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Slot = table.Column<string>(nullable: true, defaultValue: "Relic"),
                    Level = table.Column<int>(nullable: false),
                    ClassType = table.Column<string>(nullable: false, defaultValue: "Any"),
                    Effect = table.Column<string>(maxLength: 50, nullable: false),
                    EffectPower = table.Column<double>(nullable: false),
                    Agility = table.Column<int>(nullable: false),
                    Stamina = table.Column<int>(nullable: false),
                    Intellect = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Spirit = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    MaterialType = table.Column<string>(maxLength: 30, nullable: false),
                    BuyPrice = table.Column<int>(nullable: false),
                    SellPrice = table.Column<int>(nullable: false),
                    IsPositive = table.Column<bool>(nullable: false),
                    IsUsed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(maxLength: 20, nullable: false),
                    IClass = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Durability = table.Column<int>(nullable: false),
                    IsCraftable = table.Column<bool>(nullable: false),
                    BuyPrice = table.Column<int>(nullable: false),
                    SellPrice = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    Slot = table.Column<string>(nullable: true, defaultValue: "Tool")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Charges = table.Column<int>(nullable: false),
                    HappinessReplenish = table.Column<int>(nullable: false),
                    BuyPrice = table.Column<int>(nullable: false),
                    SellPrice = table.Column<int>(nullable: false),
                    IsCraftable = table.Column<bool>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Slot = table.Column<string>(nullable: true, defaultValue: "Toy")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trinkets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Level = table.Column<int>(nullable: false),
                    ClassType = table.Column<string>(nullable: true, defaultValue: "Any"),
                    Effect = table.Column<string>(maxLength: 50, nullable: false),
                    EffectPower = table.Column<double>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    IsPositive = table.Column<bool>(nullable: false),
                    Stamina = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Agility = table.Column<int>(nullable: false),
                    Intellect = table.Column<int>(nullable: false),
                    Spirit = table.Column<int>(nullable: false),
                    SellPrice = table.Column<int>(nullable: false),
                    BuyPrice = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    IsCraftable = table.Column<bool>(nullable: false),
                    MaterialType = table.Column<string>(maxLength: 30, nullable: false),
                    Slot = table.Column<string>(nullable: true, defaultValue: "Trinket")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trinkets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    AttackPower = table.Column<double>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    ClassType = table.Column<string>(maxLength: 30, nullable: false),
                    Stamina = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Agility = table.Column<int>(nullable: false),
                    Intellect = table.Column<int>(nullable: false),
                    Spirit = table.Column<int>(nullable: false),
                    BuyPrice = table.Column<int>(nullable: false),
                    SellPrice = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    IsCraftable = table.Column<bool>(nullable: false),
                    MaterialType = table.Column<string>(maxLength: 30, nullable: false),
                    Slot = table.Column<string>(nullable: true, defaultValue: "Weapon")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonsterRarityId1 = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Zone = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(maxLength: 100, nullable: false),
                    MaxHP = table.Column<double>(nullable: false),
                    HealthRegen = table.Column<double>(nullable: false),
                    MaxMana = table.Column<double>(nullable: false),
                    ManaRegen = table.Column<double>(nullable: false),
                    AttackPower = table.Column<double>(nullable: false),
                    MagicPower = table.Column<double>(nullable: false),
                    ArmorValue = table.Column<double>(nullable: false),
                    ResistanceValue = table.Column<double>(nullable: false),
                    CritChance = table.Column<double>(nullable: false),
                    IsConfused = table.Column<bool>(nullable: false),
                    IsProvoked = table.Column<bool>(nullable: false),
                    IsSilenced = table.Column<bool>(nullable: false),
                    IsStunned = table.Column<bool>(nullable: false),
                    IsBlinded = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monsters_MonstersRarities_MonsterRarityId1",
                        column: x => x.MonsterRarityId1,
                        principalTable: "MonstersRarities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserStatusId = table.Column<int>(nullable: false),
                    Stars = table.Column<int>(nullable: false),
                    Warnings = table.Column<int>(nullable: false),
                    MasteryPoints = table.Column<int>(nullable: false),
                    ForumPoints = table.Column<int>(nullable: false),
                    AllowedHeroes = table.Column<int>(nullable: false, defaultValue: 4),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsOnline = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastLogin = table.Column<DateTime>(nullable: true),
                    LastFeedbackSentOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToolId = table.Column<int>(nullable: true),
                    FuelCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<string>(nullable: true),
                    RelatedMaterials = table.Column<string>(nullable: true),
                    IsRefineable = table.Column<bool>(nullable: false),
                    IsDisolveable = table.Column<bool>(nullable: false),
                    IsCraftable = table.Column<bool>(nullable: false),
                    BuyPrice = table.Column<int>(nullable: false),
                    SellPrice = table.Column<int>(nullable: false),
                    Slot = table.Column<string>(nullable: true, defaultValue: "Material"),
                    DroppedFrom = table.Column<string>(maxLength: 100, nullable: false),
                    Rarity = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FightingClassId = table.Column<int>(nullable: true),
                    MonsterId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    BuffOrEffectTarget = table.Column<string>(maxLength: 20, nullable: true),
                    Power = table.Column<double>(nullable: false),
                    ManaRequirement = table.Column<double>(nullable: false),
                    AdditionalEffect = table.Column<string>(maxLength: 50, nullable: true),
                    EffectPower = table.Column<double>(nullable: false),
                    ResistanceAffect = table.Column<double>(nullable: false),
                    SecondaryPower = table.Column<double>(nullable: false),
                    Condition = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spells_FightingClasses_FightingClassId",
                        column: x => x.FightingClassId,
                        principalTable: "FightingClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spells_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    Content = table.Column<string>(maxLength: 100, nullable: false),
                    Stars = table.Column<int>(nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    IsAccepted = table.Column<bool>(nullable: false),
                    SentOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    SenderName = table.Column<string>(maxLength: 20, nullable: false),
                    SentOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FightingClassId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ProfessionId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Race = table.Column<string>(maxLength: 15, nullable: false),
                    Level = table.Column<int>(nullable: false, defaultValue: 1),
                    InventoryCapacity = table.Column<int>(nullable: false),
                    WeaponSlot = table.Column<bool>(nullable: false),
                    TrinketSlot = table.Column<bool>(nullable: false),
                    RelicSlot = table.Column<bool>(nullable: false),
                    HelmetSlot = table.Column<bool>(nullable: false),
                    ShoulderSlot = table.Column<bool>(nullable: false),
                    BracerSlot = table.Column<bool>(nullable: false),
                    BootsSlot = table.Column<bool>(nullable: false),
                    LeggingsSlot = table.Column<bool>(nullable: false),
                    ChestplateSlot = table.Column<bool>(nullable: false),
                    GlovesSlot = table.Column<bool>(nullable: false),
                    CardSlots = table.Column<int>(nullable: false),
                    ProfessionLevel = table.Column<int>(nullable: false),
                    ProfessionEnergy = table.Column<int>(nullable: false, defaultValue: 10),
                    ProffesionXP = table.Column<double>(nullable: false),
                    ProffesionXPCap = table.Column<double>(nullable: false),
                    XP = table.Column<double>(nullable: false),
                    XPCap = table.Column<double>(nullable: false, defaultValue: 100.0),
                    MaxHP = table.Column<double>(nullable: false),
                    CurrentHP = table.Column<double>(nullable: false),
                    HealthRegen = table.Column<double>(nullable: false),
                    CurrentHealthRegen = table.Column<double>(nullable: false),
                    MaxMana = table.Column<double>(nullable: false),
                    CurrentMana = table.Column<double>(nullable: false),
                    ManaRegen = table.Column<double>(nullable: false),
                    CurrentManaRegen = table.Column<double>(nullable: false),
                    AttackPower = table.Column<double>(nullable: false),
                    CurrentAttackPower = table.Column<double>(nullable: false),
                    MagicPower = table.Column<double>(nullable: false),
                    CurrentMagicPower = table.Column<double>(nullable: false),
                    ArmorValue = table.Column<double>(nullable: false),
                    CurrentArmorValue = table.Column<double>(nullable: false),
                    ResistanceValue = table.Column<double>(nullable: false),
                    CurrentResistanceValue = table.Column<double>(nullable: false),
                    CritChance = table.Column<double>(nullable: false),
                    CurrentCritChance = table.Column<double>(nullable: false),
                    ConfusionDuration = table.Column<int>(nullable: false),
                    ProvokeDuration = table.Column<int>(nullable: false),
                    SilenceDuration = table.Column<int>(nullable: false),
                    StunDuration = table.Column<int>(nullable: false),
                    BlindDuration = table.Column<int>(nullable: false),
                    CoinAmount = table.Column<int>(nullable: false, defaultValue: 100),
                    Mastery = table.Column<int>(nullable: false),
                    Hunger = table.Column<int>(nullable: false),
                    Thirst = table.Column<int>(nullable: false),
                    Happiness = table.Column<int>(nullable: false),
                    IconPath = table.Column<string>(maxLength: 50, nullable: false),
                    ImagePath = table.Column<string>(maxLength: 50, nullable: false),
                    IsSelected = table.Column<bool>(nullable: false, defaultValue: false),
                    Energy = table.Column<int>(nullable: false, defaultValue: 30),
                    PvPEnergy = table.Column<int>(nullable: false, defaultValue: 15),
                    PvPPoints = table.Column<int>(nullable: false),
                    EquipmentScore = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: false, defaultValue: "Player")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_FightingClasses_FightingClassId",
                        column: x => x.FightingClassId,
                        principalTable: "FightingClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Heroes_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Heroes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Content = table.Column<string>(maxLength: 200, nullable: false),
                    SenderName = table.Column<string>(maxLength: 20, nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    SentOn = table.Column<DateTime>(nullable: false),
                    EditedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Type = table.Column<string>(maxLength: 40, nullable: false),
                    ApplicationSection = table.Column<string>(maxLength: 40, nullable: false),
                    Content = table.Column<string>(maxLength: 200, nullable: false),
                    RecievedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Category = table.Column<string>(maxLength: 20, nullable: false),
                    Content = table.Column<string>(maxLength: 200, nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    EditedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserStatuses",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatuses", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserStatuses_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStatuses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpellId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Slot = table.Column<string>(nullable: true, defaultValue: "Card"),
                    Level = table.Column<int>(nullable: false),
                    ClassType = table.Column<string>(maxLength: 30, nullable: false),
                    Condition = table.Column<string>(maxLength: 150, nullable: false),
                    Agility = table.Column<int>(nullable: false),
                    Stamina = table.Column<int>(nullable: false),
                    Intellect = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Spirit = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    MaterialType = table.Column<string>(maxLength: 50, nullable: false),
                    BuyPrice = table.Column<int>(nullable: false),
                    SellPrice = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Talents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FightingClassId = table.Column<int>(nullable: false),
                    SpellId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Decsription = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talents_FightingClasses_FightingClassId",
                        column: x => x.FightingClassId,
                        principalTable: "FightingClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Talents_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArmorsEquipments",
                columns: table => new
                {
                    ArmorId = table.Column<long>(type: "bigint", nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorsEquipments", x => new { x.ArmorId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_ArmorsEquipments_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmorsEquipments_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArmorsInventories",
                columns: table => new
                {
                    ArmorId = table.Column<long>(type: "bigint", nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorsInventories", x => new { x.ArmorId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_ArmorsInventories_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmorsInventories_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumeableInventory",
                columns: table => new
                {
                    ConsumeableId = table.Column<int>(nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumeableInventory", x => new { x.ConsumeableId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_ConsumeableInventory_Consumeables_ConsumeableId",
                        column: x => x.ConsumeableId,
                        principalTable: "Consumeables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumeableInventory_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnergyChanges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroId = table.Column<long>(nullable: false),
                    Type = table.Column<string>(maxLength: 15, nullable: false),
                    LastChangedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnergyChanges_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LootBoxesInventories",
                columns: table => new
                {
                    LootBoxId = table.Column<int>(nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LootBoxesInventories", x => new { x.LootBoxId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_LootBoxesInventories_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LootBoxesInventories_LootBoxes_LootBoxId",
                        column: x => x.LootBoxId,
                        principalTable: "LootBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LootKeysInventories",
                columns: table => new
                {
                    LootKeyId = table.Column<int>(nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LootKeysInventories", x => new { x.LootKeyId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_LootKeysInventories_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LootKeysInventories_LootKeys_LootKeyId",
                        column: x => x.LootKeyId,
                        principalTable: "LootKeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialsInventories",
                columns: table => new
                {
                    MaterialId = table.Column<int>(nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialsInventories", x => new { x.MaterialId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_MaterialsInventories_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialsInventories_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelicsEquipments",
                columns: table => new
                {
                    RelicId = table.Column<long>(type: "bigint", nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelicsEquipments", x => new { x.RelicId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_RelicsEquipments_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelicsEquipments_Relics_RelicId",
                        column: x => x.RelicId,
                        principalTable: "Relics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelicsInventories",
                columns: table => new
                {
                    RelicId = table.Column<long>(type: "bigint", nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelicsInventories", x => new { x.RelicId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_RelicsInventories_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelicsInventories_Relics_RelicId",
                        column: x => x.RelicId,
                        principalTable: "Relics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToolsInventories",
                columns: table => new
                {
                    ToolId = table.Column<int>(nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolsInventories", x => new { x.ToolId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_ToolsInventories_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToolsInventories_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToyInventories",
                columns: table => new
                {
                    ToyId = table.Column<int>(nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToyInventories", x => new { x.ToyId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_ToyInventories_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToyInventories_Toys_ToyId",
                        column: x => x.ToyId,
                        principalTable: "Toys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrinketEquipments",
                columns: table => new
                {
                    TrinketId = table.Column<long>(type: "bigint", nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrinketEquipments", x => new { x.TrinketId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_TrinketEquipments_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrinketEquipments_Trinkets_TrinketId",
                        column: x => x.TrinketId,
                        principalTable: "Trinkets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrinketsInventories",
                columns: table => new
                {
                    TrinketId = table.Column<long>(type: "bigint", nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrinketsInventories", x => new { x.TrinketId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_TrinketsInventories_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrinketsInventories_Trinkets_TrinketId",
                        column: x => x.TrinketId,
                        principalTable: "Trinkets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeaponsEquipments",
                columns: table => new
                {
                    WeaponId = table.Column<long>(type: "bigint", nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponsEquipments", x => new { x.WeaponId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_WeaponsEquipments_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeaponsEquipments_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeaponsInventories",
                columns: table => new
                {
                    WeaponId = table.Column<long>(type: "bigint", nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponsInventories", x => new { x.WeaponId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_WeaponsInventories_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeaponsInventories_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ReplyId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    TopicId = table.Column<string>(nullable: false),
                    Content = table.Column<string>(maxLength: 200, nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EditedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ReplyId",
                        column: x => x.ReplyId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CardsEquipments",
                columns: table => new
                {
                    CardId = table.Column<long>(type: "bigint", nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardsEquipments", x => new { x.CardId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_CardsEquipments_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardsEquipments_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardsInventories",
                columns: table => new
                {
                    CardId = table.Column<long>(type: "bigint", nullable: false),
                    HeroId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardsInventories", x => new { x.CardId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_CardsInventories_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardsInventories_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeroesTalents",
                columns: table => new
                {
                    HeroId = table.Column<long>(type: "bigint", nullable: false),
                    TalentId = table.Column<int>(nullable: false),
                    Condition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroesTalents", x => new { x.HeroId, x.TalentId });
                    table.ForeignKey(
                        name: "FK_HeroesTalents_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeroesTalents_Talents_TalentId",
                        column: x => x.TalentId,
                        principalTable: "Talents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    TopicId = table.Column<string>(nullable: true),
                    CommentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicId = table.Column<string>(nullable: true),
                    CommentId = table.Column<string>(nullable: true),
                    MessageId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    Category = table.Column<string>(maxLength: 20, nullable: false),
                    Type = table.Column<string>(maxLength: 15, nullable: false),
                    Content = table.Column<string>(maxLength: 200, nullable: false),
                    ReportedUserId = table.Column<string>(nullable: false),
                    AdditionalInformation = table.Column<string>(maxLength: 100, nullable: true),
                    Stars = table.Column<int>(nullable: false),
                    SentOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmorsEquipments_HeroId",
                table: "ArmorsEquipments",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmorsInventories_HeroId",
                table: "ArmorsInventories",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_SpellId",
                table: "Cards",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_CardsEquipments_HeroId",
                table: "CardsEquipments",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_CardsInventories_HeroId",
                table: "CardsInventories",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReplyId",
                table: "Comments",
                column: "ReplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TopicId",
                table: "Comments",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumeableInventory_HeroId",
                table: "ConsumeableInventory",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyChanges_HeroId",
                table: "EnergyChanges",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_UserId",
                table: "FriendRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserId",
                table: "Friends",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_FightingClassId",
                table: "Heroes",
                column: "FightingClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_ProfessionId",
                table: "Heroes",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_UserId",
                table: "Heroes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroesTalents_TalentId",
                table: "HeroesTalents",
                column: "TalentId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CommentId",
                table: "Likes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_TopicId",
                table: "Likes",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LootBoxesInventories_HeroId",
                table: "LootBoxesInventories",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_LootKeysInventories_HeroId",
                table: "LootKeysInventories",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ToolId",
                table: "Materials",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsInventories_HeroId",
                table: "MaterialsInventories",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_MonsterRarityId1",
                table: "Monsters",
                column: "MonsterRarityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RelicsEquipments_HeroId",
                table: "RelicsEquipments",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_RelicsInventories_HeroId",
                table: "RelicsInventories",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_FightingClassId",
                table: "Spells",
                column: "FightingClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_MonsterId",
                table: "Spells",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_FightingClassId",
                table: "Talents",
                column: "FightingClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_SpellId",
                table: "Talents",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CommentId",
                table: "Tickets",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MessageId",
                table: "Tickets",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TopicId",
                table: "Tickets",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolsInventories_HeroId",
                table: "ToolsInventories",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UserId",
                table: "Topics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToyInventories_HeroId",
                table: "ToyInventories",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_TrinketEquipments_HeroId",
                table: "TrinketEquipments",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_TrinketsInventories_HeroId",
                table: "TrinketsInventories",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusId",
                table: "Users",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStatuses_StatusId",
                table: "UserStatuses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponsEquipments_HeroId",
                table: "WeaponsEquipments",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponsInventories_HeroId",
                table: "WeaponsInventories",
                column: "HeroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmorsEquipments");

            migrationBuilder.DropTable(
                name: "ArmorsInventories");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CardsEquipments");

            migrationBuilder.DropTable(
                name: "CardsInventories");

            migrationBuilder.DropTable(
                name: "ConsumeableInventory");

            migrationBuilder.DropTable(
                name: "EnergyChanges");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "HeroesTalents");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "LootBoxesInventories");

            migrationBuilder.DropTable(
                name: "LootKeysInventories");

            migrationBuilder.DropTable(
                name: "MaterialsInventories");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "RelicsEquipments");

            migrationBuilder.DropTable(
                name: "RelicsInventories");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "ToolsInventories");

            migrationBuilder.DropTable(
                name: "ToyInventories");

            migrationBuilder.DropTable(
                name: "TrinketEquipments");

            migrationBuilder.DropTable(
                name: "TrinketsInventories");

            migrationBuilder.DropTable(
                name: "UserStatuses");

            migrationBuilder.DropTable(
                name: "WeaponsEquipments");

            migrationBuilder.DropTable(
                name: "WeaponsInventories");

            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Consumeables");

            migrationBuilder.DropTable(
                name: "Talents");

            migrationBuilder.DropTable(
                name: "LootBoxes");

            migrationBuilder.DropTable(
                name: "LootKeys");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Relics");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Toys");

            migrationBuilder.DropTable(
                name: "Trinkets");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "FightingClasses");

            migrationBuilder.DropTable(
                name: "Monsters");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MonstersRarities");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
