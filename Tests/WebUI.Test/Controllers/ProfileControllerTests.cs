using Common;
using MyTested.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebUI.Controllers.Common;
using Xunit;

namespace WebUI.Tests.Controllers
{
    public class ProfileControllerTests
    {
        [Fact]
        public void ControllerShouldBeInAdminArea()
            => MyController<ProfileController>
                .Instance()
                .ShouldHave()
                .Attributes(attrs => attrs
                    .RestrictingForAuthorizedRequests(GConst.UserRole));

        [Fact]
        public void ReturnViewWhenCallingStatusAction()
            => MyMvc
                .Controller<ProfileController>()
                .Calling(c => c.Status())
                .ShouldReturn()
                .PartialView("_Statuses");
    }
}
