namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Handlers;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.FightingClassUtilites;
    using FinalFantasyTryoutGoesWeb.Persistence;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class EquipmentActionController : BaseController
    {
        private readonly FFDbContext context;
        private readonly Unit player;
        private readonly StatSum statSum = new StatSum();
        private readonly EquipmentHandler equipmentHandler = new EquipmentHandler();

        public EquipmentActionController(FFDbContext context)
        {
            this.context = context;
            player = context.Users.FirstOrDefault().Units.FirstOrDefault();
        }

        [HttpGet("EquipmentAction/Equip")]
        [Route("EquipmentAction/Equip")]
        public IActionResult Equip([FromQuery]string itemName)
        {
            return View(equipmentHandler.EquipOption.Equip(player, item, statSum));
        }

        [HttpGet("EquipmentAction/UnEquip")]
        [Route("EquipmentAction/UnEquip")]
        public IActionResult UnEquip([FromQuery] string itemName)
        {
            return View(equipmentHandler.UnEquipOption.UnEquip(player,item,statSum));
        }
    }
}
