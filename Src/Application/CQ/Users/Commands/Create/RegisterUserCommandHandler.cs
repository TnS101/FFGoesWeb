namespace Application.CQ.Users.Commands.Create
{
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
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
                return "Password Length must be between 8 and 30 characters";
            }
            if (request.Username.Length < 5 || request.Username.Length > 20)
            {
                return "Username length must be between 5 and 20 characters";
            }
            if (this.context.Users.Any(u => u.Username == request.Username))
            {
                return "Username is already taken, please choose another email address";
            }
            if (this.context.Users.Any(u => u.Email == request.Email))
            {
                return "Email address is in use, please choose another email address";
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
                
                return "Succsefuly registered! Redirecting to the login page.";
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
