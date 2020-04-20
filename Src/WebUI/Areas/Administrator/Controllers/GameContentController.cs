namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Admin.GameContent.Items.Commands.Create;
    using Application.CQ.Admin.GameContent.Items.Commands.Delete;
    using Application.CQ.Admin.GameContent.Items.Commands.Update;
    using Application.CQ.Admin.GameContent.Items.Queries;
    using Application.CQ.Admin.GameContent.Items.Queries.GetAllItemsQuery;
    using Application.CQ.Admin.GameContent.Items.Queries.GetAllToolsQuery;
    using Application.CQ.Admin.GameContent.Spells.Queries;
    using Application.GameCQ.FightingClasses.Queries.GetAllFightingClassesQuery;
    using Application.GameCQ.Monsters.Queries.GetAllMonstersQuery;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.AdminRole)]
    [Area(GConst.AdminArea)]
    public class GameContentController : BaseController
    {
        [HttpGet]
        public ActionResult Content()
        {
            return this.View();
        }

        [HttpGet("GameContent/Items/slot")]
        public async Task<ActionResult> Items([FromQuery]string slot)
        {
            return this.View(await this.Mediator.Send(new GetAllItemsQuery { Slot = slot }));
        }

        [HttpGet]
        public async Task<ActionResult> CreateItem()
        {
            return this.View(await this.Mediator.Send(new GetAllToolsQuery { }));
        }

        [HttpPost]
        public async Task<ActionResult> CreateItem([FromForm]string name, [FromForm]int level,
            [FromForm]string classType, [FromForm]int stamina, [FromForm]int strength, [FromForm]int agility,
            [FromForm]int intellect, [FromForm]int spirit, [FromForm] double attackPower,
            [FromForm]double armorValue, [FromForm] double resistanceValue, [FromForm]int sellPrice,
            [FromForm]int buyPrice, [FromForm]string rarity, [FromForm]int reward, [FromForm]int fuelCount,
            [FromForm]string relatedMaterials, [FromForm]string materialDiversity, [FromForm]int durability,
            [FromForm]string materialType, [FromForm]int toolId, [FromForm]string slot)
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
                ResistanceValue = resistanceValue,
                BuyPrice = buyPrice,
                SellPrice = sellPrice,
                Durability = durability,
                FuelCount = fuelCount,
                Rarity = rarity,
                MaterialDiversity = materialDiversity,
                MaterialType = materialType,
                RelatedMaterials = relatedMaterials,
                Reward = reward,
                ToolId = toolId,
                Slot = slot,
            }));
        }

        [HttpGet]
        public ActionResult UpdateItem()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateItem([FromForm]string name, [FromForm]int level,
            [FromForm]string classType, [FromForm]int stamina, [FromForm]int strength, [FromForm]int agility,
            [FromForm]int intellect, [FromForm]int spirit, [FromForm] double attackPower,
            [FromForm]double armorValue, [FromForm] double resistanceValue, [FromForm]string slot)
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
                NewResistanceValue = resistanceValue,
            }));
        }

        [HttpPost]
        public async Task<ActionResult> DeleteItem([FromForm]int id)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteItemCommand { ItemId = id }));
        }

        [HttpGet]
        public async Task<ActionResult> Spells()
        {
            return this.View(await this.Mediator.Send(new GetAllSpellsQuery { }));
        }

        [HttpGet]
        public async Task<ActionResult> Monsters()
        {
            return this.View(await this.Mediator.Send(new GetAllMonstersQuery { }));
        }

        [HttpGet]
        public async Task<ActionResult> Classes()
        {
            return this.View(await this.Mediator.Send(new GetAllFightingClassesQuery { }));
        }
    }
}
