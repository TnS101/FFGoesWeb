namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Admin.GameContent.Spells.Commands.Create;
    using Application.CQ.Admin.GameContent.Spells.Commands.Delete;
    using Application.CQ.Admin.GameContent.Spells.Commands.Update;
    using Application.CQ.Admin.GameContent.Spells.Queries.GetCurrentSpellQuery;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.AdminRole)]
    [Area(GConst.AdminArea)]
    public class SpellController : BaseController
    {
        [HttpGet("/Administrator/Spell/Current/id")]
        public async Task<IActionResult> Current([FromQuery]int id)
        {
            return this.View(await this.Mediator.Send(new GetCurrentSpellQuery { SpellId = id }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]string name, [FromForm]string type, [FromForm]string classType,
            [FromForm]double power, [FromForm]double secondaryPower, [FromForm]double manaRequirment, [FromForm]string additionalEffect,
            [FromForm]double effectPower, [FromForm]string buffOrEffectTarget, [FromForm]double resistanceAffect)
        {
            return this.Redirect(await this.Mediator.Send(new CreateSpellCommand
            {
                Name = name,
                Type = type,
                ClassType = classType,
                Power = power,
                SecondaryPower = secondaryPower,
                ManaRequirement = manaRequirment,
                AdditionalEffect = additionalEffect,
                EffectPower = effectPower,
                BuffOrEffectTarget = buffOrEffectTarget,
                ResistanceAffect = resistanceAffect,
            }));
        }

        [HttpGet("/Administrator/Spell/Update/id")]
        public IActionResult Update()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm]int id, [FromForm]string name, [FromForm]string type, [FromForm]string classType,
            [FromForm]double power, [FromForm]double secondaryPower, [FromForm]double manaRequirment, [FromForm]string additionalEffect,
            [FromForm]double effectPower, [FromForm]string buffOrEffectTarget, [FromForm]double resistanceAffect)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateSpellCommand
            {
                SpellId = id,
                NewName = name,
                NewType = type,
                NewClassType = classType,
                NewPower = power,
                NewSecondaryPower = secondaryPower,
                NewManaRequirement = manaRequirment,
                NewAdditionalEffect = additionalEffect,
                NewEffectPower = effectPower,
                NewBuffOrEffectTarget = buffOrEffectTarget,
                NewResistanceAffect = resistanceAffect,
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteSpellCommand { SpellId = id }));
        }
    }
}
