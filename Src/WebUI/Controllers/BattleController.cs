namespace FinalFantasyTryoutGoesWeb.WebUI.Controllers
{
    using global::Application.GameCQ.Unit.Queries;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using global::Application.GameCQ.Battle.Commands.Update;
    using global::Application.GameCQ.Enemy.Commands.Create;
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "Administrator,Player")]
    public class BattleController : BaseController
    {
        private UnitFullViewModel enemy;
        private bool yourTurn;
        
        [HttpGet]
        public async Task<ActionResult<string[]>> Battle() //TODO: Change return type if not working
        {
            var playerPVM = await this.Mediator.Send(new GetPartialUnitQuery { User = this.User });
            enemy = await this.Mediator.Send(new GenerateEnemyCommand { PlayerLevel = playerPVM.Level });
            this.yourTurn = true;
            return new string[] { playerPVM.Name, enemy.Name };
        }

        [HttpGet]
        public ActionResult Action() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Action([FromQuery]string command, [FromBody]string spellName)
        {
            var playerFullVm = await this.Mediator.Send(new GetFullUnitQuery { User = this.User });

            return View(await this.Mediator.Send(new BattleOptionsCommand 
            { Command = command, Player = playerFullVm, Enemy = this.enemy, YourTurn = this.yourTurn, SpellName = spellName }), this.Stats(playerFullVm));
        }

        private string[] Stats(UnitFullViewModel playerFullVm) 
        {
            return new string[] { playerFullVm.Name, enemy.Name, enemy.ImageURL,
                playerFullVm.CurrentHP.ToString(),playerFullVm.MaxHP.ToString(), enemy.CurrentHP.ToString() , enemy.MaxHP.ToString()
                , playerFullVm.CurrentAttackPower.ToString(), enemy.CurrentAttackPower.ToString(), playerFullVm.CurrentMana.ToString()
                ,playerFullVm.MaxMana.ToString(),enemy.CurrentMana.ToString(),enemy.MaxMana.ToString(), enemy.Race, playerFullVm.MagicPower.ToString(),
                playerFullVm.CurrentMagicPower.ToString(), enemy.MagicPower.ToString(), enemy.CurrentMagicPower.ToString()};
        }
    }
}
