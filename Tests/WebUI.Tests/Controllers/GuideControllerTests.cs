using Common;
using MyTested.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebUI.Controllers.Common;
using Xunit;

namespace WebUI.Tests.Controllers
{
    public class GuideControllerTests
    {
        [Fact]
        public void ControllerShouldBeInUserArea()
            => MyController<GuideController>
            .Instance()
            .ShouldHave()
            .Attributes(att => att
            .RestrictingForAuthorizedRequests(GConst.UserRole));

        [Fact]
        public void ReturnViewWhenCallingAboutAction()
            => MyMvc
                .Controller<GuideController>()
                .Calling(c => c.About())
                .ShouldReturn()
                .View();
    }
}
