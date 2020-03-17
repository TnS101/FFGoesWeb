namespace WebUI.Controllers
{
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    [ApiController]
    [Route("api/[controller]/action")]
    public class BaseController : Controller
    {
        private IMediator mediator;
        private UserManager<User> userManager;

        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected UserManager<User> UserManager => userManager ??= HttpContext.RequestServices.GetService<UserManager<User>>();
    }
}
