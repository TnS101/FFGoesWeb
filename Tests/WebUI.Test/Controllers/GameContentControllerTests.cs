namespace WebUI.Test.Controllers
{
    using global::Common;
    using MyTested.AspNetCore.Mvc;
    using WebUI.Areas.Administrator.Controllers;
    using Xunit;

    public class GameContentControllerTests
    {
        [Fact]
        public void ControllerShouldBeInAdminArea()
            => MyController<GameContentController>
                .Instance()
                .ShouldHave()
                .Attributes(attrs => attrs
                    .SpecifyingArea(GConst.AdminArea)
                    .RestrictingForAuthorizedRequests(GConst.AdminRole));

        [Fact]
        public void ReturnViewWhenCallingContentAction()
            => MyMvc
                .Controller<GameContentController>()
                .Calling(c => c.Content())
                .ShouldReturn()
                .View();
    }
}
