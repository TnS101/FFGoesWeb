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
        public async Task<IActionResult> Create([FromForm]string name, [FromForm]double maxHP, [FromForm]double maxMana,
            [FromForm]double healthRegen, [FromForm]double manaRegen, [FromForm]double attackPower, [FromForm]double magicPower,
            [FromForm]double armorValue, [FromForm]double resistanceValue, [FromForm]double critChance, [FromForm]string description)
        {
            return this.Redirect(await this.Mediator.Send(new CreateMonsterCommand
            {
                Name = name,
                MaxHP = maxHP,
                MaxMana = maxMana,
                HealthRegen = healthRegen,
                ManaRegen = manaRegen,
                AttackPower = attackPower,
                MagicPower = magicPower,
                ArmorValue = armorValue,
                ResistanceValue = resistanceValue,
                CritChance = critChance,
                Description = description,
            }));
        }

        [HttpGet("/Administrator/Monster/Update/id")]
        public IActionResult Update()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm]int id, [FromForm]string name, [FromForm]double maxHP, [FromForm]double maxMana,
            [FromForm]double healthRegen, [FromForm]double manaRegen, [FromForm]double attackPower, [FromForm]double magicPower,
            [FromForm]double armorValue, [FromForm]double resistanceValue, [FromForm]double critChance, [FromForm]string description)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateMonsterCommand
            {
                MonsterId = id,
                NewName = name,
                NewMaxHP = maxHP,
                NewMaxMana = maxMana,
                NewHealthRegen = healthRegen,
                NewManaRegen = manaRegen,
                NewAttackPower = attackPower,
                NewMagicPower = magicPower,
                NewArmorValue = armorValue,
                NewResistanceValue = resistanceValue,
                NewCritChance = critChance,
                NewDescription = description,
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteMonsterCommand { MonsterId = id }));
        }
    }
}
