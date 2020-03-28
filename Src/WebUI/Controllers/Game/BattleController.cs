namespace WebUI.Controllers.Game
{
    using System.Threading.Tasks;
    using Application.GameCQ.Battles.Commands.Update;
    using Application.GameCQ.Enemies.Commands.Create;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Application.GameCQ.Heroes.Queries.GetPartialUnitQuery;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = "Administrator,Player")]
    public class BattleController : BaseController
    {
        private UnitFullViewModel enemy;
        private bool yourTurn;

        [HttpGet]
        public async Task<ActionResult<string[]>> Battle() // TODO: Change return type if not working
        {
            var playerPVM = await this.Mediator.Send(new GetPartialUnitQuery { User = this.User });
            this.enemy = await this.Mediator.Send(new GenerateEnemyCommand { PlayerLevel = playerPVM.Level });
            this.yourTurn = true;
            return new string[] { playerPVM.Name, this.enemy.Name };
        }

        [HttpGet]
        public ActionResult Action()
        {
            return this.View();
        }

        [HttpPut]
        public async Task<IActionResult> Action([FromQuery]string command, [FromBody]string spellName)
        {
            var playerFullVm = await this.Mediator.Send(new GetFullUnitQuery { User = this.User });

            return this.View(
                await this.Mediator.Send(new BattleOptionsCommand
            { Command = command, Player = playerFullVm, Enemy = this.enemy, YourTurn = this.yourTurn, SpellName = spellName }), this.Stats(playerFullVm));
        }

        private string[] Stats(UnitFullViewModel playerFullVm)
        {
            return new string[]
            {
                playerFullVm.Name, this.enemy.Name, this.enemy.ImageURL,
                playerFullVm.CurrentHP.ToString(), playerFullVm.MaxHP.ToString(), this.enemy.CurrentHP.ToString(), this.enemy.MaxHP.ToString(),
                playerFullVm.CurrentAttackPower.ToString(), this.enemy.CurrentAttackPower.ToString(), playerFullVm.CurrentMana.ToString(),
                playerFullVm.MaxMana.ToString(), this.enemy.CurrentMana.ToString(), this.enemy.MaxMana.ToString(), this.enemy.Race, playerFullVm.MagicPower.ToString(),
                playerFullVm.CurrentMagicPower.ToString(), this.enemy.MagicPower.ToString(), this.enemy.CurrentMagicPower.ToString(),
            };
        }
    }
}
