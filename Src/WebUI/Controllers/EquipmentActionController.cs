namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using global::Application.GameCQ.Equipment.Queries;
    using global::Application.GameCQ.Equipment.Commands.Update;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class EquipmentActionController : BaseController
    {
        public EquipmentActionController()
        {
        }

        [HttpPost("EquipmentAction/Equip")]
        [Route("EquipmentAction/Equip")]
        public async Task<IActionResult> Equip([FromQuery]string itemId, [FromQuery]string command)
        {
            return Ok(await this.Mediator.Send(new UpdateEquipmentCommand { ItemId = int.Parse(itemId), Command = command, UnitId = 1 }));
        }

        [HttpPost("EquipmentAction/UnEquip")]
        [Route("EquipmentAction/UnEquip")]
        public async Task<IActionResult> UnEquip([FromQuery] string itemId, [FromQuery]string command)
        {
            return Ok(await this.Mediator.Send(new UpdateEquipmentCommand { ItemId = int.Parse(itemId), Command = command, UnitId = 1 }));
        }

        [HttpGet("EquipmentAction/Equipment")]
        [Route("EquipmentAction/Equipment")]
        public async Task<IActionResult> Equipment() 
        {
            return Ok(await this.Mediator.Send(new GetEquipmentQuery { UnitId = 1}));
        }
    }
}
