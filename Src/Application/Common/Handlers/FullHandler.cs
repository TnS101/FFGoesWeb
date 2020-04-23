namespace Application.Common.Handlers
{
    using Application.Common.Interfaces;
    using AutoMapper;
    using Domain.Entities.Common;
    using Microsoft.AspNetCore.Identity;

    public abstract class FullHandler
    {
        public FullHandler(IFFDbContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            this.Context = context;
            this.UserManager = userManager;
            this.Mapper = mapper;
        }

        protected IFFDbContext Context { get; }

        protected UserManager<AppUser> UserManager { get; }

        protected IMapper Mapper { get; }
    }
}
