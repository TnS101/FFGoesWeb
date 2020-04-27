namespace WebUI.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using WebUI.Controllers.Common;
    using Xunit;

    public class ErrorControllerTests
    {
        [Fact]
        public void ReturnViewWhenStatusCodeIs400()
            => MyMvc
                .Controller<ErrorController>()
                .Calling(c => c.HttpStatusCodeHandler(400))
                .ShouldReturn()
                .View("Default");

        [Fact]
        public void ReturnViewWhenStatusCodeIs401()
            => MyMvc
                .Controller<ErrorController>()
                .Calling(c => c.HttpStatusCodeHandler(401))
                .ShouldReturn()
                .View("Unauthorized");

        [Fact]
        public void ReturnViewWhenStatusCodeIs403()
            => MyMvc
                .Controller<ErrorController>()
                .Calling(c => c.HttpStatusCodeHandler(403))
                .ShouldReturn()
                .View("Forbidden");

        [Fact]
        public void ReturnViewWhenStatusCodeIs404()
            => MyMvc
                .Controller<ErrorController>()
                .Calling(c => c.HttpStatusCodeHandler(404))
                .ShouldReturn()
                .View("NotFound");

        [Fact]
        public void ReturnViewWhenStatusCodeIs405()
            => MyMvc
                .Controller<ErrorController>()
                .Calling(c => c.HttpStatusCodeHandler(405))
                .ShouldReturn()
                .View("Default");

        [Fact]
        public void ReturnViewWhenStatusCodeIs414()
            => MyMvc
                .Controller<ErrorController>()
                .Calling(c => c.HttpStatusCodeHandler(414))
                .ShouldReturn()
                .View("URITooLong");

        [Fact]
        public void ReturnViewWhenStatusCodeIs429()
            => MyMvc
                .Controller<ErrorController>()
                .Calling(c => c.HttpStatusCodeHandler(429))
                .ShouldReturn()
                .View("TooManyRequests");

        [Fact]
        public void ReturnViewWhenStatusCodeIs500()
            => MyMvc
                .Controller<ErrorController>()
                .Calling(c => c.HttpStatusCodeHandler(500))
                .ShouldReturn()
                .View("Internal");

        [Fact]
        public void ReturnViewWhenStatusCodeIs502()
            => MyMvc
                .Controller<ErrorController>()
                .Calling(c => c.HttpStatusCodeHandler(502))
                .ShouldReturn()
                .View("Default");

        [Fact]
        public void ReturnViewWhenStatusCodeIs503()
            => MyMvc
                .Controller<ErrorController>()
                .Calling(c => c.HttpStatusCodeHandler(503))
                .ShouldReturn()
                .View("Unavailable");

        [Fact]
        public void ReturnViewWhenStatusCodeIs504()
            => MyMvc
                .Controller<ErrorController>()
                .Calling(c => c.HttpStatusCodeHandler(504))
                .ShouldReturn()
                .View("Default");
    }
}
