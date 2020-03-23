namespace Application.Common.Mappings
{
    using Application.CQ.Admin.Users.Queries;
    using Application.CQ.Forum.Message.Queries;
    using Application.CQ.Forum.Topic.Queries.GetCurrentTopicQuery;
    using Application.GameCQ.Image.Queries;
    using Application.GameCQ.Item.Queries;
    using Application.GameCQ.Monster.Queries;
    using Application.GameCQ.Spell.Queries;
    using Application.GameCQ.Treasure.Queries;
    using Application.GameCQ.TreasureKey.Queries;
    using Application.GameCQ.Unit.Queries;
    using AutoMapper;
    using Domain.Entities.Common;
    using Domain.Entities.Common.Social;
    using Domain.Entities.Game;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
            CreateMap<Image,ImageFullViewModel>();
            CreateMap<Image, MonsterImageViewModel>();
            CreateMap<Item, ItemFullViewModel>();
            CreateMap<Spell, SpellFullViewModel>();
            CreateMap<Treasure, TreasureFullViewModel>();
            CreateMap<TreasureKey, TreasureKeyFullViewModel>();
            CreateMap<ApplicationUser, UserPartialViewModel>();
            CreateMap<Unit, UnitPartialViewModel>();
            CreateMap<Unit, UnitFullViewModel>();
            CreateMap<Topic,TopicFullViewModel>();
            CreateMap<Message,MessageFullViewModel>();
        }
    }
}