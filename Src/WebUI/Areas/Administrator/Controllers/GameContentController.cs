namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Admin.GameContent.Items.Queries;
    using Application.CQ.Admin.Item.Commands.Delete;
    using Application.CQ.Admin.Items.Commands.Create;
    using Application.CQ.Admin.Items.Commands.Update;
    using Application.CQ.Admin.Spell.Queries;
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Area(GConst.AdminArea)]
    public class GameContentController : BaseController
    {
        [HttpGet]
        public ActionResult Content()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<ActionResult> Items([FromQuery]string id)
        {
            return this.View(await this.Mediator.Send(new GetAllItemsQuery { Slot = id }));
        }

        [HttpGet]
        public ActionResult CreateItem()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateItem([FromForm]string name, [FromForm]int level,
            [FromForm]string classType, [FromForm]int stamina, [FromForm]int strength, [FromForm]int agility,
            [FromForm]int intellect, [FromForm]int spirit, [FromForm] double attackPower,
            [FromForm]double armorValue, [FromForm] double ressistanceValue, [FromForm]string slot)
        {
            return this.Redirect(await this.Mediator.Send(new CreateItemCommand
            {
                Name = name,
                Level = level,
                ClassType = classType,
                Stamina = stamina,
                Strength = strength,
                Agility = agility,
                Intellect = intellect,
                Spirit = spirit,
                AttackPower = attackPower,
                ArmorValue = armorValue,
                RessistanceValue = ressistanceValue,
                Slot = slot,
            }));
        }

        [HttpGet]
        public ActionResult UpdateItem()
        {
            return this.View();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateItem([FromForm]string name, [FromForm]int level,
            [FromForm]string classType, [FromForm]int stamina, [FromForm]int strength, [FromForm]int agility,
            [FromForm]int intellect, [FromForm]int spirit, [FromForm] double attackPower,
            [FromForm]double armorValue, [FromForm] double ressistanceValue, [FromForm]string slot)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateItemCommand
            {
                NewName = name,
                NewLevel = level,
                NewClassType = classType,
                NewStamina = stamina,
                NewStrength = strength,
                NewAgility = agility,
                NewIntellect = intellect,
                NewSpirit = spirit,
                NewAttackPower = attackPower,
                NewArmorValue = armorValue,
                NewRessistanceValue = ressistanceValue,
            }));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteItem([FromBody]int id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteItemCommand { ItemId = id }));
        }

        [HttpGet]
        public async Task<ActionResult> Spells()
        {
            return this.View(await this.Mediator.Send(new GetAllSpellsQuery { }));
        }
    }
}
