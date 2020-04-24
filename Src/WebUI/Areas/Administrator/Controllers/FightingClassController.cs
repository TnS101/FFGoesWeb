namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Admin.GameContent.FightingClasses.Commands.Create;
    using Application.CQ.Admin.GameContent.FightingClasses.Commands.Delete;
    using Application.CQ.Admin.GameContent.FightingClasses.Commands.Update;
    using Application.GameCQ.FightingClasses.Queries.GetCurrentFightingClassQuery;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.AdminRole)]
    [Area(GConst.AdminArea)]
    public class FightingClassController : BaseController
    {
        [HttpGet("/Administrator/FightingClass/Current/id")]
        public async Task<ActionResult> Current([FromQuery]int id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentFightingClassQuery { FightingClassId = id }));
        }

        [HttpGet]
        [ResponseCache(CacheProfileName = "Weekly")]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm]string classType, [FromForm]double maxHP, [FromForm]double maxMana,
            [FromForm]double healthRegen, [FromForm]double manaRegen, [FromForm]double attackPower, [FromForm]double magicPower,
            [FromForm]double armorValue, [FromForm]double resistanceValue, [FromForm]double critChance, [FromForm]string description)
        {
            return this.Redirect(await this.Mediator.Send(new CreateFightingClassCommand
            {
                ClassType = classType,
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

        [HttpGet("/Administrator/FightingClass/Update/id")]
        [ResponseCache(CacheProfileName = "Weekly")]
        public ActionResult Update()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Update([FromForm]int id, [FromForm]string classType, [FromForm]double maxHP, [FromForm]double maxMana,
            [FromForm]double healthRegen, [FromForm]double manaRegen, [FromForm]double attackPower, [FromForm]double magicPower,
            [FromForm]double armorValue, [FromForm]double resistanceValue, [FromForm]double critChance, [FromForm]string description)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateFightingClassCommand
            {
                FightingClassId = id,
                NewClassStype = classType,
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
        public async Task<ActionResult> Delete([FromForm]int id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteFightingClassCommand { FightingClassId = id }));
        }
    }
}
