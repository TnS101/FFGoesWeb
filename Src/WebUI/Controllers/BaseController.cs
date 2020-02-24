namespace WebUI.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    public class BaseController : Controller
    {
        private IMediator mediator;

        protected IMediator Mediator => mediator = HttpContext.RequestServices.GetService<>();
    }
}
