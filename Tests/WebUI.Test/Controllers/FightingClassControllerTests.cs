namespace WebUI.Test.Controllers
{
    using global::Common;
    using MyTested.AspNetCore.Mvc;
    using WebUI.Areas.Administrator.Controllers;
    using Xunit;

    public class FightingClassControllerTests
    {
        [Fact]
        public void ControllerShouldBeInAdminArea()
            => MyController<FightingClassController>
                .Instance()
                .ShouldHave()
                .Attributes(attrs => attrs
                    .SpecifyingArea(GConst.AdminArea)
                    .RestrictingForAuthorizedRequests(GConst.AdminRole));

        [Fact]
        public void ReturnViewWhenCallingCreateAction()
            => MyMvc
                .Controller<FightingClassController>()
                .Calling(c => c.Create())
                .ShouldReturn()
                .View();

        [Fact]
        public void ReturnViewWhenCallingUpdateAction()
            => MyMvc
                .Controller<FightingClassController>()
                .Calling(c => c.Update())
                .ShouldReturn()
                .View();
    }
}
