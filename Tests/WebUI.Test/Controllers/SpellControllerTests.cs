namespace WebUI.Test.Controllers
{
    using Application.CQ.Admin.GameContent.Spells.Queries.GetCurrentSpellQuery;
    using global::Common;
    using MyTested.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebUI.Areas.Administrator.Controllers;
    using WebUI.Controllers.Common;
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

        [Fact]
        public async Task ReturnViewWhenCallingCurrent()
            => MyMvc
            .Controller<SpellController>()
            .Calling(c => c.Current(1))
            .ShouldReturn()
            .View();

        [Fact]
        public async Task ReturnRedirectWhenCreatingSpell()
            => MyMvc
            .Controller<SpellController>()
            .Calling(c => c.Create("p", "p", "p", 1, 1, 1 , "p", 1 , "p", 1))
            .ShouldReturn()
            .Redirect();
       
    }
}
