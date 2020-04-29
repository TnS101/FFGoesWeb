using MyTested.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using WebUI.Controllers.Common;
using Xunit;

namespace WebUI.Test.Controllers
{
    public class HomeControllerTests : BaseController
    {
        [Fact]
        public void ReturnViewWhenCallingPrivacyPolicyAction()
            => MyMvc
            .Controller<HomeController>()
            .Calling(c => c.PrivacyPolicy())
            .ShouldReturn()
            .View();

        [Fact]
        public void ReturnViewWhenCallingIndexAction()
            => MyMvc
            .Controller<HomeController>()
            .Calling(c => c.Index())
            .ShouldReturn()
            .View();

        [Fact]
        public void ReturnViewWhenCallingMonsterCatalogAction()
            => MyMvc
            .Controller<HomeController>()
            .Calling(c => c.MonsterCatalog())
            .ShouldReturn()
            .View();
    }
}
