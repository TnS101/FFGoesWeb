namespace FinalFantasyTryoutGoesWeb.Controllers
{
    using FinalFantasyTryoutGoesWeb.Persistence;
    using global::WebUI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    public class UnitCreationController : BaseController
    {
        private readonly FFDbContext context;
        private readonly User user;
        private readonly Unit player;
        private readonly ValidatorHandler validatorHandler;

        public UnitCreationController(FFDbContext context)
        {
            this.context = context;
            validatorHandler = new ValidatorHandler();
            user = context.Users.FirstOrDefault();
            player = new Unit { Type = "Player", Equipment = new Equipment(), UserId = user.Id, GoldAmount = 100, Level = 1, XPCap = 100 };
        }

        [HttpGet("UnitCreation/Create")]
        [Route("UnitCreation/Create")]
        public IActionResult Create()
        {
            return View(context.Images.Where(i => i.Description.Contains("Main Stat:")).ToList());
        }

        [HttpPost("UnitCreation/SubmittedCreate")]
        [Route("UnitCreation/SubmittedCreate")]
        public async Task<IActionResult> Create([FromQuery]string fightingClass, [FromForm]string race)
        {
            player.UserId = user.Id;

            //Fighting Class Check

            await context.Units.AddAsync(validatorHandler.FightingClassCheck.Check(player, fightingClass));

            //Race Check
            validatorHandler.RaceCheck.Check(player, race);
            await context.Units.AddAsync(player);
            return Redirect("/NamePick");
        }

        [HttpGet("UnitCreation/NamePick")]
        [Route("UnitCreation/NamePick")]
        public IActionResult NamePick() 
        {
            return View();
        }

        [HttpPost("UnitCreation/NamePick")]
        [Route("UnitCreation/NamePick")]
        public async Task<IActionResult> NamePick([FromForm]string name)
        {
            player.Name = name;
            await context.SaveChangesAsync();
            return Redirect("/World/Explore");
        }
    }
}
