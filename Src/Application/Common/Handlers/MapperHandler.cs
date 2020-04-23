namespace Application.Common.Handlers
{
    using Application.Common.Interfaces;
    using AutoMapper;

    public abstract class MapperHandler
    {
        public MapperHandler(IFFDbContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        protected IFFDbContext Context { get; }

        protected IMapper Mapper { get; }
    }
}
