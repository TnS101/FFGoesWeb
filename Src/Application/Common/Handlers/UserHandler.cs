namespace Application.Common.Handlers
{
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Microsoft.AspNetCore.Identity;

    public abstract class UserHandler
    {
        public UserHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.Context = context;
            this.UserManager = userManager;
        }

        protected IFFDbContext Context { get; }

        protected UserManager<AppUser> UserManager { get; }
    }
}
