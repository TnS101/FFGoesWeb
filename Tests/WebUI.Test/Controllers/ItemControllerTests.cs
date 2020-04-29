using Common;
using MyTested.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebUI.Areas.Administrator.Controllers;
using Xunit;

namespace WebUI.Tests.Controllers
{
    public class ItemControllerTests
    {
        [Fact]
        public void ControllerShouldBeInAdminArea()
            => MyController<ItemController>
                .Instance()
                .ShouldHave()
                .Attributes(attrs => attrs
                    .SpecifyingArea(GConst.AdminArea)
                    .RestrictingForAuthorizedRequests(GConst.AdminRole));

        [Fact]
        public void ReturnViewWhenCallingCreate()
            => MyMvc
                .Controller<ItemController>()
                .Calling(c => c.Create())
                .ShouldReturn()
                .View();

        [Fact]
        public void ReturnRedirectWhenCallingCreate()
            => MyMvc
                .Controller<ItemController>()
                .Calling(c => c.Create("p",1, "p", 1, 1, 1, 1, 1, 1,1 ,1 ,1 ,1 ,"1", 1 ,1 ,"1"
                    ,"1",1,"1",1,"1"))
                .ShouldReturn()
                .Redirect();

        [Fact]
        public void ReturnViewWhenCallingUpdate()
            => MyMvc
                .Controller<ItemController>()
                .Calling(c => c.Update())
                .ShouldReturn()
                .View();
    }
}
