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

        [Fact]
        public void ReturnViewWhenCallingItemsAction()
            => MyMvc
                .Controller<GameContentController>()
                .Calling(c => c.Items("Material"))
                .ShouldReturn()
                .View();

        [Fact]
        public void ReturnViewWhenCallingSpellsAction()
            => MyMvc
                .Controller<GameContentController>()
                .Calling(c => c.Spells("Hunter"))
                .ShouldReturn()
                .View();

        [Fact]
        public void ReturnViewWhenCallingMonstersAction()
            => MyMvc
                .Controller<GameContentController>()
                .Calling(c => c.Monsters())
                .ShouldReturn()
                .View();
        [Fact]
        public void ReturnViewWhenCallingFightingClassesAction()
            => MyMvc
                .Controller<GameContentController>()
                .Calling(c => c.FightingClasses())
                .ShouldReturn()
                .View();
    }
}
