using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
using Common;
using MyTested.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebUI.Controllers.Common;
using WebUI.Controllers.Game;
using Xunit;

namespace WebUI.Tests.Controllers
{
    public class HeroControllerTests : BaseController
    {
        [Fact]
        public void ControllerShouldBeInAdminArea()
            => MyController<HeroController>
                .Instance()
                .ShouldHave()
                .Attributes(attrs => attrs
                    .RestrictingForAuthorizedRequests(GConst.UserRole));
    }
}
