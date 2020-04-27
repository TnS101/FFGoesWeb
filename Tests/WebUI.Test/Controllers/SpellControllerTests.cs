namespace WebUI.Test.Controllers
{
    using global::Common;
    using MyTested.AspNetCore.Mvc;
    using WebUI.Areas.Administrator.Controllers;
    using Xunit;

    public class SpellControllerTests
    {
        [Fact]
        public void ControllerShouldBeInAdminArea()
            => MyController<SpellController>
                .Instance()
                .ShouldHave()
                .Attributes(attrs => attrs
                    .SpecifyingArea(GConst.AdminArea)
                    .RestrictingForAuthorizedRequests(GConst.AdminRole));

        [Fact]
        public void ReturnViewWhenCallingCreateAction()
            => MyMvc
                .Controller<SpellController>()
                .Calling(c => c.Create())
                .ShouldReturn()
                .View();

        [Fact]
        public void ReturnViewWhenCallingUpdateAction()
           => MyMvc
               .Controller<SpellController>()
               .Calling(c => c.Update())
               .ShouldReturn()
               .View();
    }
}
