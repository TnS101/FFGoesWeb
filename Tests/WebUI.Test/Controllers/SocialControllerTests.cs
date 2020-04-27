namespace WebUI.Test.Controllers
{
    using global::Common;
    using MyTested.AspNetCore.Mvc;
    using WebUI.Controllers.Social;
    using Xunit;

    public class SocialControllerTests
    {
        [Fact]
        public void ControllerShouldBeAuthorizedByUser()
            => MyController<SocialController>
                .Instance()
                .ShouldHave()
                .Attributes(attrs => attrs
                    .RestrictingForAuthorizedRequests(GConst.UserRole));

        [Fact]
        public void ReturnViewWhenCallingIndexAction()
            => MyMvc
                .Controller<SocialController>()
                .Calling(c => c.Home())
                .ShouldReturn()
                .View();

        [Fact]
        public void ReturnViewWhenCallingTicketSentAction()
            => MyMvc
                .Controller<SocialController>()
                .Calling(c => c.TicketSent())
                .ShouldReturn()
                .View();
    }
}
