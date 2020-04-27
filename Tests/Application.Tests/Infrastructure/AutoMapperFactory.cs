namespace Application.Tests.Infrastructure
{
    using Application.Common.Mappings;
    using AutoMapper;

    public static class AutoMapperFactory
    {
        public static IMapper Create()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            return mappingConfig.CreateMapper();
        }
    }
}
