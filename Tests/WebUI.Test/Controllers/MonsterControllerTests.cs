namespace WebUI.Test.Controllers
{
    using global::Common;
    using MyTested.AspNetCore.Mvc;
    using WebUI.Areas.Administrator.Controllers;
    using Xunit;

    public class MonsterControllerTests
    {
        [Fact]
        public void ControllerShouldBeInAdminArea()
            => MyController<MonsterController>
                .Instance()
                .ShouldHave()
                .Attributes(attrs => attrs
                    .SpecifyingArea(GConst.AdminArea)
                    .RestrictingForAuthorizedRequests(GConst.AdminRole));

        [Fact]
        public void ReturnViewWhenCallingCreateAction()
            => MyMvc
                .Controller<MonsterController>()
                .Calling(c => c.Create())
                .ShouldReturn()
                .View();

        [Fact]
        public void ReturnRedirectWhenCallingCreateAction()
            => MyMvc
                .Controller<MonsterController>()
                .Calling(c => c.Create("1",1,1,1,1,1,1,1,1,1,"1"))
                .ShouldReturn()
                .Redirect();

        [Fact]
        public void ReturnViewWhenCallingUpdateAction()
            => MyMvc
                .Controller<MonsterController>()
                .Calling(c => c.Update())
                .ShouldReturn()
                .View();
    }
}
