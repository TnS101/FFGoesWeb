namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Admin.Item.Commands.Create;
    using Application.CQ.Admin.Item.Commands.Delete;
    using Application.CQ.Admin.Item.Commands.Update;
    using Application.CQ.Admin.Item.Queries;
    using Application.CQ.Admin.Spell.Queries;
    using Application.CQ.Admin.Treasure.Commands.Create;
    using Application.CQ.Admin.Treasure.Commands.Delete;
    using Application.CQ.Admin.Treasure.Queries.GetAllTreasureQuery;
    using Application.CQ.Admin.TreasureKey.Commands.Create;
    using Application.CQ.Admin.TreasureKey.Commands.Delete;
    using Application.CQ.Admin.TreasureKey.Commands.Queries;
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Area(GConst.AdminArea)]
    public class GameContentController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Items()
        {
            return this.View(await this.Mediator.Send(new GetAllItemsQuery { }));
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
                NewSlot = slot,
            }));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteItem([FromBody]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteItemCommand { ItemId = id }));
        }

        [HttpGet]
        public async Task<ActionResult> Treasures()
        {
            return this.View(await this.Mediator.Send(new GetAllTreasuresQuery { }));
        }

        [HttpGet]
        public ActionResult CreateTreasure()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTreasure([FromForm]string rarity, [FromForm]int reward, [FromForm]string imageURL)
        {
            return this.Redirect(await this.Mediator.Send(new CreateTreasureCommand { Rarity = rarity, Reward = reward, ImageURL = imageURL }));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTreasure([FromForm]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteTreasureCommand { Id = id }));
        }

        [HttpGet]
        public async Task<ActionResult> TreasureKeys()
        {
            return this.View(await this.Mediator.Send(new GetAllTreasureKeysQuery { }));
        }

        [HttpGet]
        public ActionResult CreateTreasureKey()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTreasureKey([FromForm]string rarity, [FromForm]string imageURL)
        {
            return this.Redirect(await this.Mediator.Send(new CreateTreasureKeyCommand { Rarity = rarity, ImageURL = imageURL }));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTreasureKey([FromForm]string id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteTreasureKeyCommand { KeyId = id }));
        }

        [HttpGet]
        public async Task<ActionResult> Spells()
        {
            return this.View(await this.Mediator.Send(new GetAllSpellsQuery { }));
        }
    }
}
