namespace WebUI.Controllers.Social
{
    using System.Threading.Tasks;
    using Application.CQ.Users.Queries.GetCurrentUser;
    using Application.CQ.Users.Tickets.Commands.Create;
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Data.SqlClient;
    using Persistence;
    using WebUI.Controllers.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class SocialController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Home()
        {
            return this.View(await this.UserManager.GetUserAsync(this.User));
        }

        [HttpPost]
        public async Task<ActionResult> ReportContent([FromForm]string id, [FromForm]string contentType, [FromForm]string category, [FromForm]string additionalInformation)
        {
            return this.Redirect(await this.Mediator.Send(new OpenTicketCommand
            {
                ContentId = id,
                ContentType = contentType,
                Category = category,
                AdditionalInformation = additionalInformation,
                Sender = this.User,
            }));
        }

        [HttpGet]
        public ActionResult TicketSent()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<ActionResult> Search([FromQuery] string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return this.View(@"\Home");
            }

            string userId = await this.SqlInjectionPrevention(userName);

            if (userId == null)
            {
                return this.View(@"\Search", new string[] { string.Format(GConst.UserNotFound, userName) });
            }

            var user = await this.Mediator.Send(new GetCurrentUserQuery { UserId = userId });

            return this.View(@"\Search", new string[] { user.Id, user.UserName });
        }

        private async Task<string> SqlInjectionPrevention(string userName)
        {
            var constring = new Connection();

            SqlConnection con = new SqlConnection(constring.String);

            string query = "select Id from Users where UserName=@UserName";

            SqlCommand cmd = new SqlCommand(query, con);

            SqlParameter param = new SqlParameter("@UserName", userName);

            cmd.Parameters.Add(param);

            await con.OpenAsync();

            var result = await cmd.ExecuteScalarAsync();

            await con.CloseAsync();

            if (result == null)
            {
                return null;
            }
            else
            {
                return result.ToString();
            }
        }
    }
}
