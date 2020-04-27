using Common;
using MyTested.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebUI.Controllers.Game;
using Xunit;

namespace WebUI.Test.Controllers
{
    public class WorldControllerTests
    {
        [Fact]
        public void ControllerShouldBeInAuthorizedByUser()
            => MyController<WorldController>
                .Instance()
                .ShouldHave()
                .Attributes(attrs => attrs
                    .RestrictingForAuthorizedRequests(GConst.UserRole));

        [Fact]
        public void ReturnViewWhenCallingIndexAction()
            => MyMvc
                .Controller<WorldController>()
                .Calling(c => c.EnemyEncounter())
                .ShouldReturn()
                .View();
    }
}
