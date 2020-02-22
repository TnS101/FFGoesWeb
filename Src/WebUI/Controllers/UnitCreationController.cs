namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using FinalFantasyTryoutGoesWeb.Data;
    using FinalFantasyTryoutGoesWeb.Data.Entities;
    using FinalFantasyTryoutGoesWeb.GameContent.Handlers;
    using FinalFantasyTryoutGoesWeb.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    public class UnitCreationController : Controller
    {
        private static readonly FFDbContext context = new FFDbContext();
        private static readonly User user = context.Users.FirstOrDefault();
        private Unit player = new Unit { Type = "Player", Equipment = new Equipment(), UserId = user.Id, GoldAmount = 100, Level = 1, XPCap = 100 };
        private readonly ValidatorHandler validatorHandler = new ValidatorHandler();

        [HttpPost("UnitCreation/Create")]
        [Route("UnitCreation/Create")]
        public IActionResult Create()
        {
            return View(context.Images.Where(i => i.Description.Contains("Main Stat:")).ToList());
        }

        [HttpGet("UnitCreation/SubmittedCreate")]
        [Route("UnitCreation/SubmittedCreate")]
        public async Task<IActionResult> SubmittedCreate(string fightingClass, string race)
        {
            fightingClass = HttpContext.Request.Query["id"];
            race = Request.Form["race"];
            player.UserId = user.Id;

            //Fighting Class Check

            await context.Units.AddAsync(validatorHandler.FightingClassCheck.Check(player,fightingClass));

            //Race Check
            validatorHandler.RaceCheck.Check(player, race);
            await context.Units.AddAsync(player);
            return View();
        }

        [HttpGet("UnitCreation/NamePick")]
        [Route("UnitCreation/NamePick")]
        public async Task<IActionResult> NamePick(string name)
        {
            name = Request.Form["name"];
            player.Name = name;
            await context.SaveChangesAsync();
            return View();
        }
    }
}
