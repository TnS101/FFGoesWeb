namespace WebUI.Controllers.Common
{
    using Microsoft.AspNetCore.Mvc;

    public class ErrorController : BaseController
    {
        [Route("Error/{statusCode}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult HttpStatusCodeHandler(int statusCode)
        {
            return statusCode switch
            {
                400 => this.View("Default"),
                401 => this.View("Unauthorized"),
                403 => this.View("Forbidden"),
                404 => this.View("NotFound"),
                405 => this.View("Default"),
                414 => this.View("URITooLong"),
                429 => this.View("TooManyRequests"),
                500 => this.View("Internal"),
                502 => this.View("Default"),
                503 => this.View("Unavailable"),
                504 => this.View("Default"),
                _ => this.View("Default"),
            };
        }
    }
}
