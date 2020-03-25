namespace WebUI.Controllers.Common
{
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    public class BaseController : Controller
    {
        private IMediator mediator;
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        protected IMediator Mediator => this.mediator ??= this.HttpContext.RequestServices.GetService<IMediator>();

        protected UserManager<AppUser> UserManager => this.userManager ??= this.HttpContext.RequestServices.GetService<UserManager<AppUser>>();

        protected SignInManager<AppUser> SignInManager => this.signInManager ??= this.HttpContext.RequestServices.GetService<SignInManager<AppUser>>();
    }
}
