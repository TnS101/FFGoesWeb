namespace WebUI.Controllers
{
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    public class BaseController : Controller
    {
        private IMediator mediator;

        protected IMediator Mediator => mediator = HttpContext.RequestServices.GetService<>();

        protected UserManager<User> UserManager => HttpContext.RequestServices.GetService<>();
    }
}
