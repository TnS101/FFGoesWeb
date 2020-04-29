using Common;
using MyTested.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebUI.Areas.Administrator.Controllers;
using Xunit;

namespace WebUI.Tests.Controllers
{
    public class ToDoControllerTests
    {
        [Fact]
        public void ControllerShouldBeInAdminArea()
            => MyController<ToDoController>
                .Instance()
                .ShouldHave()
                .Attributes(attrs => attrs
                    .SpecifyingArea(GConst.AdminArea)
                    .RestrictingForAuthorizedRequests(GConst.AdminRole));

        [Fact]
        public void ReturnViewWhenCallingList()
            => MyMvc
                .Controller<ToDoController>()
                .Calling(c => c.List())
                .ShouldReturn()
                .View();
    }
}
