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

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<User> userManager;
        public RegisterUserCommandHandler(IFFDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Password.Length < 8 || request.Password.Length > 30)
            {
                return string.Format(GConst.LengthException,"Password",8,30);
            }
            if (request.Username.Length < 5 || request.Username.Length > 20)
            {
                return string.Format(GConst.LengthException, "Username", 5, 20);
            }
            if (this.context.Users.Any(u => u.Username == request.Username))
            {
                return string.Format(GConst.IdentityInUse, "Username", "Username");
            }
            if (this.context.Users.Any(u => u.Email == request.Email))
            {
                return string.Format(GConst.IdentityInUse, "E-mail address", "E-mail address");
            }
            else
            {
                var user = new User
                {
                    Username = request.Username,
                    Password = this.Hash(request.Password),
                    Email = request.Email,
                    Units = new List<FinalFantasyTryoutGoesWeb.Domain.Entities.Game.Unit>()
                };

                await this.userManager.CreateAsync(user, user.Password);

                await this.userManager.AddToRoleAsync(user, GConst.UserRole);

                return string.Format(GConst.RegistrationSuccessful,user.Username);
            }
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
