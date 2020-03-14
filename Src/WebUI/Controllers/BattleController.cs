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

    public class BattleController : BaseController
    {
        private readonly EnemyGenerator enemyGenerator;
        private Unit enemy;

        public BattleController(EnemyGenerator enemyGenerator)
        {
            this.enemyGenerator = enemyGenerator;
        }

        [HttpPost("Battle/Battle")]
        [Route("Battle/Battle")]
        public async Task<IActionResult> Battle()
        {
            var player = await this.Mediator.Send(new GetUnitQuery { UnitId = 1 });
            enemy = enemyGenerator.Generate(player);
            return View(new string[] { player.Name, enemy.Name });
        }

        [HttpGet("Battle/Action")]
        [Route("Battle/Action")]
        public async Task<IActionResult> Action([FromQuery]string action, CancellationToken cancellationToken)
        {
            var player = await this.Mediator.Send(new GetFullUnitQuery { UnitId = 1 });

            var stats = new string[] { player.Name, enemy.Name, enemy.ImageURL,
                player.CurrentHP.ToString(),player.MaxHP.ToString(), enemy.CurrentHP.ToString() , enemy.MaxHP.ToString()
                , player.CurrentAttackPower.ToString(), enemy.CurrentAttackPower.ToString(), player.CurrentMana.ToString()
                ,player.MaxMana.ToString(),enemy.CurrentMana.ToString(),enemy.MaxMana.ToString(), enemy.Race, player.MagicPower.ToString(),
                player.CurrentMagicPower.ToString(), enemy.MagicPower.ToString(), enemy.CurrentMagicPower.ToString()};

            await ExecuteAction(action, cancellationToken);
            
            if (enemy.CurrentHP <= 0)
            {
                enemy.CurrentHP = 0;
                return Redirect(@"\End");
            }

            return View(stats);
        }

        [HttpPost("Battle/SpellOption")]
        [Route("Battle/SpellOption")]
        public IActionResult SpellList()
        {
            return View(@"\Action", context.Spells.Where(s => s.ClassType == player.ClassType));
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
            if (yourTurn)
            {
                if (action == "attack")
                {
                    battleHandler.AttackOption.Attack(player, enemy);
                }
                if (action == "defend")
                {
                    battleHandler.DefendOption.Defend(player);
                }
                if (action == "spellCast")
                {
                    SpellList();
                }
                if (action == "escape")
                {
                    await Escape();
                }
                battleHandler.TurnCheck.Check(player, enemy, battleHandler, context, yourTurn, cancellationToken);
                yourTurn = false;
            }
            if (!yourTurn)
            {
                battleHandler.TurnCheck.Check(player, enemy, battleHandler, context, yourTurn, cancellationToken);
            }
        }
    }
}
