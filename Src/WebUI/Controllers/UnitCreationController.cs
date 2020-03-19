namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using global::Application.GameCQ.Unit.Commands.Create;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using global::Application.GameCQ.Image.Queries;
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "Administrator,User")]
    public class UnitCreationController : BaseController
    {

        [HttpGet("UnitCreation/Create")]
        [Route("UnitCreation/Create")]
        public async Task<IActionResult> Create()
        {
            return View(await this.Mediator.Send(new GetFightingClassImagesQuery ()));
        }

        [HttpPost("UnitCreation/SubmittedCreate")]
        [Route("UnitCreation/SubmittedCreate")]
        public async Task<IActionResult> Create([FromQuery]string fightingClass, [FromForm]string race, [FromForm]string name)
        {
            await this.Mediator.Send(new CreateUnitCommand { ClassType = fightingClass, Race = race, Name = name, UserId = 1});
            return Redirect("/World/Home");
        }
    }
}
