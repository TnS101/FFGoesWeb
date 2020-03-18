namespace WebUI.Controllers
{
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
        public async Task<ActionResult> Login([FromForm]string username, [FromForm]string password) 
        {
            return View("/Login", await this.Mediator.Send(new LoginUserCommand { Username = username, Password = password }));
        }

        [HttpGet("/Register")]
        public ActionResult Register() 
        {
            return View(@"\Register");
        }

        [HttpPost("/Register")]
        public async Task <ActionResult> Register([FromForm]string username, [FromForm]string password, [FromForm]string email, [FromForm]string confirmPassword)
        {
            if (!this.ModelState.IsValid)
            {
                return View(@"\Register");
            }

            return View(@"\RegistrationSuccess");
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
