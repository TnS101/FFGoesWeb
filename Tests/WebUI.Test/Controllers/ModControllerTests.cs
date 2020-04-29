using Common;
using MyTested.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebUI.Areas.Moderator.Controllers;
using Xunit;

namespace WebUI.Tests.Controllers
{
    public class ModControllerTests
    {
        [Fact]
        public void ControllerShouldBeInModeratorArea()
            => MyController<ModController>
                .Instance()
                .ShouldHave()
                .Attributes(attrs => attrs
                    .SpecifyingArea(GConst.ModeratorArea)
                    .RestrictingForAuthorizedRequests(GConst.ModeratorRole));

        [Fact]
        public void ReturnViewWhenCallingTicketsAction()
            => MyMvc
                .Controller<ModController>()
                .Calling(c => c.Tickets())
                .ShouldReturn()
                .View();
    }
}
