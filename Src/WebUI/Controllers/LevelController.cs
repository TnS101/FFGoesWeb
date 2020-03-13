namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using global::Application.GameCQ.Unit.Commands.Update;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class LevelController : BaseController
    {
        public LevelController()
        {
        }

        [HttpGet("Level/LevelUp")]
        [Route("Level/LevelUp")]
        public async Task<IActionResult> LevelUp()
        {
            return Ok(await this.Mediator.Send(new UnitLevelUpCommand()));
        }
    }
}
