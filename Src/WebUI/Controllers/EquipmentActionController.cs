namespace FinalFantasyTryoutGoesWeb.Data.ModelUtilities
{
    using FinalFantasyTryoutGoesWeb.Data.Entities;
    using FinalFantasyTryoutGoesWeb.GameContent.Handlers;
    using FinalFantasyTryoutGoesWeb.GameContent.Utilities.FightingClassUtilites;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class EquipmentActionController : Controller
    {
        private static readonly FFDbContext context = new FFDbContext();
        private readonly Unit player = context.Users.FirstOrDefault().Units.FirstOrDefault();
        private readonly StatSum statSum = new StatSum();
        private readonly EquipmentHandler equipmentHandler = new EquipmentHandler();

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
