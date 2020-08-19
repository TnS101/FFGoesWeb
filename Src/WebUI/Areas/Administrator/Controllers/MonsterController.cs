namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Admin.GameContent.Monsters.Commands.Create;
    using Application.CQ.Admin.GameContent.Monsters.Commands.Delete;
    using Application.CQ.Admin.GameContent.Monsters.Commands.Update;
    using Application.GameCQ.Monsters.Queries.GetCurrentMonsterQuery;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.AdminRole)]
    [Area(GConst.AdminArea)]
    public class MonsterController : BaseController
    {
        [HttpGet("/Administrator/Monster/Current/id")]
        public async Task<IActionResult> Current([FromQuery]int id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentMonsterQuery { MonsterId = id }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMonsterCommand monster)
        {
            return this.Redirect(await this.Mediator.Send(new CreateMonsterCommand
            {
                Name = monster.Name,
                MaxHP = monster.MaxHP,
                MaxMana = monster.MaxMana,
                HealthRegen = monster.HealthRegen,
                ManaRegen = monster.ManaRegen,
                AttackPower = monster.AttackPower,
                MagicPower = monster.MagicPower,
                ArmorValue = monster.ArmorValue,
                ResistanceValue = monster.ResistanceValue,
                CritChance = monster.CritChance,
                Description = monster.Description,
                Zone = monster.Zone,
            }));
        }

        [HttpGet("/Administrator/Monster/Update/id")]
        public async Task<IActionResult> Update([FromQuery]int id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentMonsterQuery { MonsterId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMonsterCommand monster, int id)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateMonsterCommand
            {
                MonsterId = id,
                Name = monster.Name,
                MaxHP = monster.MaxHP,
                MaxMana = monster.MaxMana,
                HealthRegen = monster.HealthRegen,
                ManaRegen = monster.ManaRegen,
                AttackPower = monster.AttackPower,
                MagicPower = monster.MagicPower,
                ArmorValue = monster.ArmorValue,
                ResistanceValue = monster.ResistanceValue,
                CritChance = monster.CritChance,
                Description = monster.Description,
                Zone = monster.Zone,
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteMonsterCommand { MonsterId = id }));
        }
    }
}
