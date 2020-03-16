namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using global::Application.GameCQ.Unit.Commands.Update;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    public class LevelController : BaseController
    {
        [HttpGet("Level/LevelUp")]
        [Route("Level/LevelUp")]
        public async Task<IActionResult> LevelUp()
        {
            return Ok(await this.Mediator.Send(new UnitLevelUpCommand()));
        }
    }
}
