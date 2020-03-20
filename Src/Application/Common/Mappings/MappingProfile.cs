namespace Application.Common.Mappings
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Application.GameCQ.Image.Queries;
    using Application.GameCQ.Item.Queries;
    using Application.GameCQ.Monster.Queries;
    using Application.GameCQ.Spell.Queries;
    using Application.GameCQ.Treasure.Queries;
    using Application.GameCQ.TreasureKey.Queries;
    using AutoMapper;
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
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}