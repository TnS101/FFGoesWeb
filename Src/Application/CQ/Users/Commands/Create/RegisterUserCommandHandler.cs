namespace Application.CQ.Users.Commands.Create
{
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,string[]>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        public RegisterUserCommandHandler(IFFDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<string[]> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = new string[] { "","" };
            var sb = new StringBuilder();

            if (request.Password.Length < 8 || request.Password.Length > 30)
            {
                result[0] = @"\Register";
                sb.AppendLine(string.Format(GConst.LengthException, "Password", 8, 30));
            }
            if (request.Username.Length < 5 || request.Username.Length > 20)
            {
                result[0] = @"\Register";
                sb.AppendLine(string.Format(GConst.LengthException, "Username", 5, 20));
            }
            if (this.context.Users.Any(u => u.UserName == request.Username))
            {
                result[0] = @"\Register";
                sb.AppendLine(string.Format(GConst.IdentityInUse, "Username", "Username"));
            }
            if (this.context.Users.Any(u => u.Email == request.Email))
            {
                result[0] = @"\Register";
                sb.AppendLine(string.Format(GConst.IdentityInUse, "E-mail address", "E-mail address"));
            }
            else
            {
                var user = new ApplicationUser
                {
                    UserName = request.Username,
                    Password = this.Hash(request.Password),
                    Email = request.Email,
                    Units = new List<FinalFantasyTryoutGoesWeb.Domain.Entities.Game.Unit>(),
                    PasswordHash = this.Hash(request.Password)
                };

                await this.userManager.CreateAsync(user, user.Password);

                await this.userManager.AddToRoleAsync(user, GConst.UserRole);

                result[0] = @"\RegistrtationSuccess";
                result[1] = string.Format(GConst.RegistrationSuccessful, user.UserName);

                return result;
            }

            result[1] = sb.ToString();
            return result;
        }

        private string Hash(string password)
        {
            if (password == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }

    }
}
