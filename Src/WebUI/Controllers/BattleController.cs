namespace FinalFantasyTryoutGoesWeb.WebUI.Controllers
{
    using global::Application.GameCQ.Unit.Queries;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Generators;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Application.GameCQ.Spell.Queries;

    public class BattleController : BaseController
    {
        private readonly EnemyGenerator enemyGenerator;
        private Unit enemy;
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
        public async Task<IActionResult> Action([FromQuery]string action)
        {
            var playerFullVm = await this.Mediator.Send(new GetFullUnitQuery { UnitId = 1 });

            var stats = new string[] { playerFullVm.Name, enemy.Name, enemy.ImageURL,
                playerFullVm.CurrentHP.ToString(),playerFullVm.MaxHP.ToString(), enemy.CurrentHP.ToString() , enemy.MaxHP.ToString()
                , playerFullVm.CurrentAttackPower.ToString(), enemy.CurrentAttackPower.ToString(), playerFullVm.CurrentMana.ToString()
                ,playerFullVm.MaxMana.ToString(),enemy.CurrentMana.ToString(),enemy.MaxMana.ToString(), enemy.Race, playerFullVm.MagicPower.ToString(),
                playerFullVm.CurrentMagicPower.ToString(), enemy.MagicPower.ToString(), enemy.CurrentMagicPower.ToString()};
            
            if (enemy.CurrentHP <= 0)
            {
                enemy.CurrentHP = 0;
                return Redirect(@"\End");
            }

            return View(stats);
        }

        [HttpPost("Battle/SpellOption")]
        [Route("Battle/SpellOption")]
        public async Task<IActionResult> SpellOption()
        {
            var playerPVM = await this.Mediator.Send(new GetPartialUnitQuery { UnitId = 1 });

            return View(@"\Action", await this.Mediator.Send(new GetPersonalSpellsQuery { ClassType = playerPVM.ClassType}));
        }

        [HttpGet("Battle/Escape")]
        [Route("Battle/Escape")]
        public async Task<IActionResult> Escape()
        {
            battleHandler.EscapeOption.Escape(player);
            await context.SaveChangesAsync();
            return View();
        }

        [HttpGet("Battle/End")]
        [Route("Battle/End")]
        public async Task<IActionResult> End()
        {
            battleHandler.EndOption.End(player, enemy, loot);
            await context.SaveChangesAsync();
            return View();
        }

        private async Task ExecuteAction(string action, CancellationToken cancellationToken)
        {
            
        }
    }
}
