namespace WebUI.Areas.Administrator.Controllers
{
    using Application.CQ.Admin.Item.Commands.Create;
    using Application.CQ.Admin.Item.Commands.Delete;
    using Application.CQ.Admin.Item.Commands.Update;
    using Application.CQ.Admin.Item.Queries;
    using Application.CQ.Admin.Treasure.Commands.Create;
    using Application.CQ.Admin.Treasure.Commands.Delete;
    using Application.CQ.Admin.Treasure.Queries.GetAllTreasureQuery;
    using Application.CQ.Admin.TreasureKey.Commands.Create;
    using Application.CQ.Admin.TreasureKey.Commands.Delete;
    using Application.CQ.Admin.TreasureKey.Commands.Queries;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebUI.Controllers;

    [Authorize(Roles = GConst.AdminRole)]
    [Area(GConst.AdminArea)]
    public class ContentController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Items()
        {
            return View(await this.Mediator.Send(new GetAllItemsQuery { }));
        }

        [HttpGet]
        public ActionResult CreateItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateItem([FromForm]string name, [FromForm]int level
            , [FromForm]string classType, [FromForm]int stamina, [FromForm]int strength, [FromForm]int agility
            , [FromForm]int intellect, [FromForm]int spirit, [FromForm] double attackPower
            , [FromForm]double armorValue, [FromForm] double ressistanceValue, [FromForm]string slot)
        {
            await this.Mediator.Send(new CreateItemCommand
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
                Slot = slot
            });

            return Redirect("/Items");
        }

        [HttpGet]
        public ActionResult UpdateItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateItem([FromForm]string name, [FromForm]int level
            , [FromForm]string classType, [FromForm]int stamina, [FromForm]int strength, [FromForm]int agility
            , [FromForm]int intellect, [FromForm]int spirit, [FromForm] double attackPower
            , [FromForm]double armorValue, [FromForm] double ressistanceValue, [FromForm]string slot)
        {
            await this.Mediator.Send(new UpdateItemCommand
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
                NewSlot = slot
            });

            return View("/Items");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteItem([FromBody]string id)
        {
            await this.Mediator.Send(new DeleteItemCommand { ItemId = id });

            return Redirect("/Items");
        }

        [HttpGet]
        public async Task<ActionResult> Treasures()
        {
            return View(await this.Mediator.Send(new GetAllTreasuresQuery { }));
        }

        [HttpGet]
        public ActionResult CreateTreasure()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTreasure([FromForm]string rarity, [FromForm]int reward, [FromForm]string imageURL)
        {
            await this.Mediator.Send(new CreateTreasureCommand { Rarity = rarity, Reward = reward, ImageURL = imageURL });

            return View("/Treasures");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteTreasure([FromForm]string id)
        {
            await this.Mediator.Send(new DeleteTreasureCommand { Id = id });

            return Redirect("/Treasures");
        }

        [HttpGet]
        public async Task<ActionResult> TreasureKeys() 
        {
            return View(await this.Mediator.Send(new GetAllTreasureKeysQuery{ }));
        }

        [HttpGet]
        public ActionResult CreateTreasureKey() 
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTreasureKey([FromForm]string rarity, [FromForm]string imageURL) 
        {
            await this.Mediator.Send(new CreateTreasureKeyCommand { Rarity = rarity, ImageURL = imageURL });

            return Redirect("/TreasureKeys");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteTreasureKey([FromForm]string id) 
        {
            await this.Mediator.Send(new DeleteTreasureKeyCommand { KeyId = id });

            return Redirect("/TreasureKeys");
        }
    }
}
