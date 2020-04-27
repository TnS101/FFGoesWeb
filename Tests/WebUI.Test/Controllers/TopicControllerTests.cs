namespace WebUI.Test.Controllers
{
    using global::Common;
    using MyTested.AspNetCore.Mvc;
    using WebUI.Controllers.Social;
    using Xunit;

    public class TopicControllerTests
    {
        [Fact]
        public void ControllerShouldBeAuthorizedByUser()
            => MyController<TopicController>
                .Instance()
                .ShouldHave()
                .Attributes(attrs => attrs
                    .RestrictingForAuthorizedRequests(GConst.UserRole));

        [Fact]
        public void ReturnViewWhenCallingCreateAction()
           => MyMvc
           .Controller<TopicController>()
           .Calling(c => c.Create())
           .ShouldReturn()
           .View();

        [Fact]
        public void ReturnViewWhenCallingInModerationAction()
           => MyMvc
           .Controller<TopicController>()
           .Calling(c => c.InModeration())
           .ShouldReturn()
           .View();
    }
}
