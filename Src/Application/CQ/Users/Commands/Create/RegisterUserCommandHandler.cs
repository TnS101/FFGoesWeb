namespace Application.CQ.Users.Commands.Create
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Linq;
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
                await this.userManager.CreateAsync(new User
                {
                    Username = request.Username,
                    Password = request.Password,
                    Email = request.Email,
                    Units = new List<FinalFantasyTryoutGoesWeb.Domain.Entities.Game.Unit>()
                });
                return "Succsefuly registered! Redirecting to the login page.";
            }
        }
    }
}
