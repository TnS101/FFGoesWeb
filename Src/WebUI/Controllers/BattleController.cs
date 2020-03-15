namespace FinalFantasyTryoutGoesWeb.WebUI.Controllers
{
    using global::Application.GameCQ.Unit.Queries;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Generators;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using global::Application.GameCQ.Spell.Queries;
    using global::Application.GameCQ.Battle.Commands.Update;

    public class BattleController : BaseController
    {
        private readonly EnemyGenerator enemyGenerator;
        private UnitFullViewModel enemy;
        private bool yourTurn;

        public BattleController()
        {
            this.yourTurn = true;
        }

        public BattleController(EnemyGenerator enemyGenerator)
        {
            this.enemyGenerator = enemyGenerator;
        }

        [HttpPost("Battle/Battle")]
        [Route("Battle/Battle")]
        public async Task<IActionResult> Battle()
        {
            var playerPVM = await this.Mediator.Send(new GetPartialUnitQuery { UnitId = 1 });
            enemy = enemyGenerator.Generate(playerPVM);
            return View(new string[] { playerPVM.Name, enemy.Name });
        }

        [HttpGet("Battle/Action")]
        [Route("Battle/Action")]
        public async Task<IActionResult> Action([FromQuery]string command)
        {
            var playerFullVm = await this.Mediator.Send(new GetFullUnitQuery { UnitId = 1 });

            return View(await this.Mediator.Send(new BattleOptionsCommand 
            { Command = command, Player = playerFullVm, Enemy = this.enemy, YourTurn = this.yourTurn }), this.Stats(playerFullVm));
        }

        [HttpPost("Battle/SpellOption")]
        [Route("Battle/SpellOption")]
        public async Task<IActionResult> SpellOption()
        {
            var playerPVM = await this.Mediator.Send(new GetPartialUnitQuery { UnitId = 1 });

            return View(@"\Action", await this.Mediator.Send(new GetPersonalSpellsQuery { ClassType = playerPVM.ClassType}));
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
