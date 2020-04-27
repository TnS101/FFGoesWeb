namespace WebUI.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using Application.CQ.Admin.GameContent.Items.Commands.Create;
    using Application.CQ.Admin.GameContent.Items.Commands.Delete;
    using Application.CQ.Admin.GameContent.Items.Commands.Update;
    using Application.CQ.Admin.GameContent.Items.Queries.GetAllToolsQuery;
    using Application.CQ.Admin.GameContent.Items.Queries.GetCurrentItemQuery;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.AdminRole)]
    [Area(GConst.AdminArea)]
    public class ItemController : BaseController
    {
        [HttpGet("/Administrator/Item/Current/id&slot")]
        public async Task<IActionResult> Current([FromQuery]string id, [FromQuery]string slot)
        {
            return this.View(await this.Mediator.Send(new GetCurrentItemQuery { ItemId = id, Slot = slot }));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return this.View(await this.Mediator.Send(new GetAllToolsQuery { }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]string name, [FromForm]int level,
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

        [HttpGet("Administrator/Item/Update/id&slot")]
        public async Task<IActionResult> Update()
        {
            return this.View(await this.Mediator.Send(new GetAllToolsQuery { }));
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm]string id, [FromForm]string name, [FromForm]int level,
            [FromForm]string classType, [FromForm]int stamina, [FromForm]int strength, [FromForm]int agility,
            [FromForm]int intellect, [FromForm]int spirit, [FromForm] double attackPower,
            [FromForm]double armorValue, [FromForm] double resistanceValue, [FromForm]int sellPrice,
            [FromForm]int buyPrice, [FromForm]string rarity, [FromForm]int reward, [FromForm]int fuelCount,
            [FromForm]string relatedMaterials, [FromForm]string materialDiversity, [FromForm]int durability,
            [FromForm]string materialType, [FromForm]int toolId, [FromForm]string slot)
        {
            return this.Redirect(await this.Mediator.Send(new UpdateItemCommand
            {
                Id = id,
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
                NewSellPrice = sellPrice,
                NewBuyPrice = buyPrice,
                NewRarity = rarity,
                NewReward = reward,
                NewFuelCount = fuelCount,
                NewRelatedMaterials = relatedMaterials,
                NewMaterialDiversity = materialDiversity,
                NewDurability = durability,
                NewMaterialType = materialType,
                NewToolId = toolId,
                Slot = slot,
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]string id, [FromForm]string slot)
        {
            return this.Redirect(await this.Mediator.Send(new DeleteItemCommand { ItemId = id, Slot = slot }));
        }
    }
}
