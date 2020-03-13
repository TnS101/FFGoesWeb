namespace FinalFantasyTryoutGoesWeb.WebUI.Controllers
{
    using FinalFantasyTryoutGoesWeb.Persistence;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class BattleController : BaseController
    {
        private static readonly FFDbContext context = new FFDbContext();
        private readonly BattleHandler battleHandler = new BattleHandler();
        private static readonly EnemyGenerator enemyGenerator= new EnemyGenerator();
        private readonly Loot loot = new Loot();
        private Unit player = context.Units.FirstOrDefault();
        private static Unit enemy = enemyGenerator.Generate(context);
        private Image image = context.Images.FirstOrDefault(i => i.Name == string.Concat(enemy.Name, enemy.Race));
        private readonly Random rng = new Random();
        private bool yourTurn = true;

        [HttpPost("Battle/Battle")]
        [Route("Battle/Battle")]
        public IActionResult Battle()
        {
            player.CurrentHP = player.MaxHP;
            enemy = enemyGenerator.Generate(context);
            var statistics = new string[] { player.Name, enemy.Name };
            return View(statistics);
        }

        [HttpGet("Battle/Action")]
        [Route("Battle/Action")]
        public async Task<IActionResult> Action([FromQuery]string action, CancellationToken cancellationToken)
        {
            var stats = new string[] { player.Name, enemy.Name, image.Path,
                player.CurrentHP.ToString(),player.MaxHP.ToString(), enemy.CurrentHP.ToString() , enemy.MaxHP.ToString()
                , player.CurrentAttackPower.ToString(), enemy.CurrentAttackPower.ToString(), player.CurrentMana.ToString()
                ,player.MaxMana.ToString(),enemy.CurrentMana.ToString(),enemy.MaxMana.ToString(), enemy.Race};

            await ExecuteAction(action, cancellationToken);
            
            if (enemy.CurrentHP <= 0)
            {
                enemy.CurrentHP = 0;
                return View(@"\End");
            }
            await context.SaveChangesAsync();
            return View(stats);
        }

        [HttpPost("Battle/SpellOption")]
        [Route("Battle/SpellOption")]
        public IActionResult SpellList()
        {
            return View(@"\Action", context.Spells.Where(s => s.ClassType == player.ClassType));
        }

        [HttpPost("Battle/Escape")]
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
