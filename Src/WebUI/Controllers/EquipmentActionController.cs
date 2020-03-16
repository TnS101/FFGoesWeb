namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using global::Application.GameCQ.Equipment.Queries;
    using global::Application.GameCQ.Equipment.Commands.Update;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using global::Domain.Entities.Common;
    using global::Application.GameCQ.Unit.Queries;

    [Authorize]
    public class EquipmentActionController : BaseController
    {
        [HttpPost("EquipmentAction/Equip")]
        [Route("EquipmentAction/Equip")]
        public async Task<IActionResult> Equip([FromQuery]string itemId, [FromQuery]string command)
        {
            var user = await this.UserManager.GetUserAsync(this.User);

            var unit = await this.Mediator.Send(new GetFullUnitQuery { UserId = user.Id });

            return Ok(await this.Mediator.Send(new UpdateEquipmentCommand { ItemId = itemId, Command = command, UnitId = unit.Id }));
        }

        [HttpPost("EquipmentAction/UnEquip")]
        [Route("EquipmentAction/UnEquip")]
        public async Task<IActionResult> UnEquip([FromQuery] string itemId, [FromQuery]string command)
        {
            var user = await this.UserManager.GetUserAsync(this.User);

            var unit = await this.Mediator.Send(new GetFullUnitQuery { UserId = user.Id });

            return Ok(await this.Mediator.Send(new UpdateEquipmentCommand { ItemId = itemId, Command = command, UnitId = unit.Id }));
        }

        [HttpGet("EquipmentAction/Equipment")]
        [Route("EquipmentAction/Equipment")]
        public async Task<IActionResult> Equipment() 
        {
            var user = await this.UserManager.GetUserAsync(this.User);

            var unit = await this.Mediator.Send(new GetFullUnitQuery { UserId = user.Id });

            return Ok(await this.Mediator.Send(new GetEquipmentQuery { UnitId = unit.Id}));
        }
    }
}
