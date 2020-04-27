namespace WebUI.Test.Controllers
{
    using global::Common;
    using MyTested.AspNetCore.Mvc;
    using WebUI.Controllers.Common;
    using Xunit;

    public class GuideControllerTests
    {
        [Fact]
        public void ControllerShouldBeInAdminArea()
            => MyController<GuideController>
                .Instance()
                .ShouldHave()
                .Attributes(attrs => attrs
                    .RestrictingForAuthorizedRequests(GConst.UserRole));

        [Fact]
        public void ReturnViewWhenCallingIndexAction()
            => MyMvc
                .Controller<GuideController>()
                .Calling(c => c.About())
                .ShouldReturn()
                .View();
    }
}
