namespace WebUI.Controllers
{
    using Application.CQ.Users.Commands.Create;
    using Application.CQ.Users.Commands.Update;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class UserController : BaseController
    {

        [HttpGet("User/Login")]
        [Route("User/Login")]
        public ActionResult Login() 
        {
            return View();
        }

        [HttpPost("User/Login")]
        [Route("User/Login")]
        public async Task<ActionResult> Login(string username, string password) 
        {
            return View(@"/Login", await this.Mediator.Send(new LoginUserCommand { Username = username, Password = password }));
        }

        [HttpGet("User/Register")]
        [Route("User/Register")]
        public ActionResult Register() 
        {
            return View();
        }

        [HttpPost("User/Register")]
        [Route("User/Register")]
        public async Task <ActionResult> Register(string username, string password, string email, string confirmPassword)
        {
            return View("/Register",await this.Mediator.Send(new RegisterUserCommand { Username = username, Password = password, Email = email, ConfirmPassword = confirmPassword }));
        }

        [HttpPost("User/Logout")]
        [Route("User/Logout")]
        public async Task <ActionResult> Logout() 
        {
            await this.Mediator.Send(new LogoutUserCommand { });
            return Redirect("/Home");
        }
    }
}
