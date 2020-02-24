namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.FightingClassUtilites;
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
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

        [HttpPost("EquipmentAction/Equip")]
        [Route("EquipmentAction/Equip")]
        public IActionResult Equip(Item item)
        {
            return View(equipmentHandler.EquipOption.Equip(player, item, statSum));
        }

        [HttpPost("EquipmentAction/UnEquip")]
        [Route("EquipmentAction/UnEquip")]
        public IActionResult UnEquip(Item item)
        {
            return View(equipmentHandler.UnEquipOption.UnEquip(player,item,statSum));
        }
    }
}
