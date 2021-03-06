﻿namespace WebUI.Test.Controllers
{
    using global::Common;
    using MyTested.AspNetCore.Mvc;
    using WebUI.Areas.Administrator.Controllers;
    using Xunit;

    public class AdminControllerTests
    {
        [Fact]
        public void ControllerShouldBeInAdminArea()
            => MyController<AdminController>
                .Instance()
                .ShouldHave()
                .Attributes(attrs => attrs
                    .SpecifyingArea(GConst.AdminArea)
                    .RestrictingForAuthorizedRequests(GConst.AdminRole));

        [Fact]
        public void ReturnViewWhenCallingIndexAction()
            => MyMvc
                .Controller<AdminController>()
                .Calling(c => c.Index())
                .ShouldReturn()
                .View();

        [Fact]
        public void ReturnViewWhenCallingAboutAction()
            => MyMvc
                .Controller<AdminController>()
                .Calling(c => c.About())
                .ShouldReturn()
                .View();

        [Fact]
        public void ReturnViewWhenCallingLogoutAction()
            => MyMvc
                .Controller<AdminController>()
                .Calling(c => c.Logout())
                .ShouldReturn()
                .View();
    }
}
