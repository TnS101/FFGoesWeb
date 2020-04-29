namespace WebUI.Tests.Controllers
{
    using global::Common;
    using MyTested.AspNetCore.Mvc;
    using WebUI.Controllers.Game;
    using Xunit;

    public class BattleControllerTests
    {
        [Fact]
        public void ControllerShouldBeAuthorizedByUser()
            => MyController<BattleController>
                .Instance()
                .ShouldHave()
                .Attributes(attrs => attrs
                    .RestrictingForAuthorizedRequests(GConst.UserRole));

        [Fact]
        public void ReturnViewWhenCallingKilledAction()
            => MyMvc
                .Controller<BattleController>()
                .Calling(c => c.Killed())
                .ShouldReturn()
                .View();

    }
}
